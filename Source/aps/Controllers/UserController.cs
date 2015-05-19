using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSA.Models;
using Model;

namespace MSA.Controllers
{
    public class UserController : Controller
    {
        private SeguridadEntities db = new SeguridadEntities();

        [Authorize]
        public ActionResult Index()
        {
            return View(db.UserDomains.ToList().OrderBy(x => x.Name));
        }

        [Authorize]
        public ActionResult Create()
        {            
            ViewBag.Groups = string.Empty;
            ViewBag.Aplications = new SelectList(db.Aplications.ToList().OrderBy(x => x.Name).ToList(), "Id", "Name");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDomain userdomain, FormCollection value)
        {            
            if (ModelState.IsValid)
            {
                UserDomain userexist = db.UserDomains.Where(x => x.Name.Contains(userdomain.Name)).FirstOrDefault();
                if (userexist != null)
                {
                    ViewBag.UserExist = "El nombre usuario ya existe.";
                    ViewBag.Groups = string.Empty;
                    ViewBag.Aplications = new SelectList(db.Aplications.ToList().OrderBy(x => x.Name).ToList(), "Id", "Name");
                    return View(userdomain);
                }
                if (value["duallistbox"] != null)
                {
                    Group groupselect = null;
                    string[] idgroup = value["duallistbox"].Split(",".ToCharArray());
                    userdomain.Groups = new List<Group>();                    
                    foreach (var item in idgroup)
                    {
                        groupselect = db.Groups.Where(x => x.Id.ToString() == item).FirstOrDefault();
                        userdomain.Groups.Add(groupselect);
                    }
                }
                if (!userdomain.IsUserAd)
                {
                    if (!string.IsNullOrEmpty(userdomain.Password))
                        userdomain.Password = MSACommon.SecurityUtil.Encrypt(userdomain.Password);
                    else
                    {
                        ViewBag.PasswordUser = "Ingrese una password";
                        ViewBag.Groups = string.Empty;
                        ViewBag.Aplications = new SelectList(db.Aplications.ToList().OrderBy(x => x.Name).ToList(), "Id", "Name");
                        return View(userdomain);
                    }
                }                
                db.UserDomains.Add(userdomain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userdomain);
        }

        public JsonResult FilterByIdApp(string idApp)
        {
            if (!string.IsNullOrEmpty(idApp))
            {
                var objects = db.Groups.Where(x => x.Aplication_Id == idApp);
                return Json(new SelectList(objects.ToArray(), "Id", "Name"), JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public JsonResult FilterByIdAppEdit(string idApp, int idUsr)
        {
            UserDomain user = db.UserDomains.Include("Groups").Where(x => x.Id == idUsr).FirstOrDefault();
            List<Group> groupselect = new List<Group>();
            List<Group> groupnotselect = new List<Group>();
            foreach (var item in db.Groups.Where(x => x.Aplication_Id == idApp).ToList())
            {
                if (item.UserDomains.Contains(user))
                {
                    groupselect.Add(new Group { Id = item.Id, Name = item.Name });
                }
                else
                {
                    groupnotselect.Add(item);
                }
            }
            SelectList listaRoles = new SelectList(groupselect, "Id", "Name");
            foreach (var item in listaRoles)
            {
                item.Selected = true;
            }
       
            return Json(new { Success = true, result1 = new SelectList(groupnotselect, "Id", "Name"), result2 = groupselect }, JsonRequestBehavior.AllowGet);

        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDomain userdomain = db.UserDomains.Include("Groups").Where(x => x.Id == id).FirstOrDefault();
            string appid = string.Empty;
            if (userdomain != null && userdomain.Groups != null)
            {
                appid = userdomain.Groups.FirstOrDefault().Aplication_Id;
                ViewBag.Aplications = new SelectList(db.Aplications.ToList().OrderBy(x => x.Name).ToList(), "Id", "Name", appid);
            }
            else
                ViewBag.Aplications = new SelectList(db.Aplications.ToList().OrderBy(x => x.Name).ToList(), "Id", "Name");
            
            ViewBag.GroupsSelect = string.Empty;

            if (userdomain == null)
            {
                return HttpNotFound();
            }
            return View(userdomain);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserDomain userdomain, FormCollection value)
        {
            if (ModelState.IsValid)
            {
                int userexist = db.UserDomains.Where(x => x.Name.Contains(userdomain.Name)).Count();
                if (userexist > 1)
                {
                    ViewBag.UserExist = "El nombre usuario ya existe.";
                    ViewBag.Groups = string.Empty;
                    ViewBag.GroupsSelect = string.Empty;
                    ViewBag.Aplications = new SelectList(db.Aplications.ToList().OrderBy(x => x.Name).ToList(), "Id", "Name");
                    return View(userdomain);
                }

                UserDomain user = db.UserDomains.Include("Groups").Where(x => x.Id == userdomain.Id).FirstOrDefault();
                db.UserDomains.Remove(user);
                db.SaveChanges();

                if (value["duallistbox"] != null)
                {
                    Group groupselect = null;
                    string[] idgroup = value["duallistbox"].Split(",".ToCharArray());
                    userdomain.Groups = new List<Group>();
                    foreach (var item in idgroup)
                    {
                        groupselect = db.Groups.Where(x => x.Id.ToString() == item).FirstOrDefault();
                        userdomain.Groups.Add(groupselect);
                    }
                }
                ViewBag.GroupsSelect = string.Empty;
                db.UserDomains.Add(userdomain); 
                db.SaveChanges();  
                return RedirectToAction("Index");
            }
            ViewBag.GroupsSelect = string.Empty;
            return View(userdomain);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDomain aspnetuserdomain = db.UserDomains.Find(id);
            if (aspnetuserdomain == null)
            {
                return HttpNotFound();
            }
            return View(aspnetuserdomain);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDomain user = db.UserDomains.Include("Groups").Where(x => x.Id == id).FirstOrDefault();              
            db.UserDomains.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
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
