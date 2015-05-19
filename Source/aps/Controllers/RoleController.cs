using MSA.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MSA.Controllers
{
    public class RoleController : Controller
    {
        private SeguridadEntities db = new SeguridadEntities();

        [Authorize]
        public ActionResult Index()
        {
            return View(db.Roles.ToList().OrderBy(x => x.Name));
        }

        [Authorize]
        public ActionResult Create()
        {            
            ViewBag.Object = null;
            ViewBag.Permission = new SelectList(db.Permissions.ToList(), "Id", "Name");
            ViewBag.Aplications = new SelectList(db.Aplications.ToList().OrderBy(x => x.Name).ToList(), "Id", "Name");

            return View();
        }

        public JsonResult FilterByIdApp(string idApp)
        {            
            if (!string.IsNullOrEmpty(idApp))
            {
                var objects = db.Elements.Where(x => x.Aplications_Id == idApp);
                return Json(new SelectList(objects.ToArray(), "Id", "Name"), JsonRequestBehavior.AllowGet);   
            }
            return null;
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role role, FormCollection value)
        {
            
            if (ModelState.IsValid)
            {
                if (value["Activos"] != null)
                {
                    this.AddGroupsRole(role, value);                   
                }                
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {

            Role role = db.Roles.Include("Aplication").Where(x => x.Id == id).FirstOrDefault();
            string idapp = role.Aplications_Id;
          
            if (!string.IsNullOrEmpty(idapp))
            {
                List<Element> listobject = new List<Element>();
                listobject = db.Elements.Where(x => x.Aplications_Id == idapp).ToList();
                List<Element> objectselect = new List<Element>();
                List<Permission> objgroups = db.Permissions.ToList();
                foreach (var item in role.Elements)
                {
                    if (!objectselect.Contains(item))
                    {
                        listobject.Remove(listobject.Where(x => x.Id == item.Id).FirstOrDefault());
                    }
                    item.Name += " -";

                    foreach (var permission in item.Permissions)
                    {
                        Permission groups = objgroups.Where(x => x.Id == permission.Id).FirstOrDefault();
                        item.Name += "/" + groups.Id; 
                    }
                    objectselect.Add(item);
                }
                ViewBag.ObjectSelect = new SelectList(objectselect, "Id", "Name");
                ViewBag.Object = new SelectList(listobject, "Id", "Name");
            }
            else
            {
                ViewBag.ObjectSelect = null;
                ViewBag.Object = null;
            }

            ViewBag.Permission = new SelectList(db.Permissions.ToList(), "Id", "Name");
            ViewBag.Aplications = new SelectList(db.Aplications.ToList().OrderBy(x => x.Name).ToList(), "Id", "Name", idapp);

            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role, FormCollection value)
        {
            if (ModelState.IsValid)
            {
                this.DeleteRol(role.Id);
                if (value["Activos"] != null)
                {    
                    this.AddGroupsRole(role, value);                                                  
                }
                Group group = db.Groups.Where(x => x.Aplication.Id == role.Aplications_Id).FirstOrDefault();
                role.Groups.Add(group);

                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Role role = db.Roles.Find(id);
            Role aspnetroleactual = db.Roles.Include("Groups").Where(x => x.Id == id).FirstOrDefault();

            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            this.DeleteRol(id);            
            return RedirectToAction("Index");
        }

        private void AddGroupsRole(Role role, FormCollection value)
        {
            string objactive = value["Activos"]; 
            List<Element> listElement = db.Elements.ToList();
            List<Permission> listpermissions = db.Permissions.ToList();
            role.Elements = new List<Element>();
            foreach (var objper in objactive.Split(",".ToCharArray()))
            {
                Element objectsvalue = null;
                string nameElement = objper.Split("-".ToCharArray())[0].ToString();
                objectsvalue = listElement.Where(a => a.Name.ToUpper() == nameElement.Trim().ToUpper()).FirstOrDefault();

                foreach (var item in objper.Split("/".ToCharArray()))
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        Permission permission = listpermissions.ToList().Find(x => x.Id.ToString() == item.Trim());
                        
                        if (permission != null)
                        {                                                        
                            objectsvalue.Permissions.Add(permission);
                        }
                    }
                }                
                role.Elements.Add(objectsvalue);               
            }
        }

        private void DeleteRol(int id)
        {
            Role role = db.Roles.Include("Elements").Include("Groups").Where(x => x.Id == id).FirstOrDefault();
            foreach (var item in role.Elements)
            {
                Element element = db.Elements.Where(x => x.Id == item.Id).FirstOrDefault();
                element.Permissions.Clear();
                db.Entry(element).State = EntityState.Modified;
                db.SaveChanges();
            }
            role.Groups.Clear();
            db.Roles.Remove(role);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
