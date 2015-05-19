using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MSA.Controllers
{
    public class GroupController : Controller
    {
        private SeguridadEntities db = new SeguridadEntities();

        // GET: /Group/
        public ActionResult Index()
        {
            return View(db.Groups.ToList());
        }

        // GET: /Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server, Duration = 10, VaryByParam = "*")]
        public JsonResult FilterByIdApp(string idApp)
        {
            if (!string.IsNullOrEmpty(idApp))
            {
                var objects = db.Roles.Where(x => x.Aplications_Id == idApp);
                return Json(new SelectList(objects.ToArray(), "Id", "Name"), JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        // GET: /Group/Create
        public ActionResult Create()
        {
            ViewBag.Rols = string.Empty;            
            ViewBag.Aplications = new SelectList(db.Aplications.ToList().OrderBy(x => x.Name).ToList(), "Id", "Name");
            return View();
        }

        // POST: /Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Status,Aplication_Id")] Group group, FormCollection value)
        {
            if (ModelState.IsValid)
            {
                if (value["duallistbox"] != null)
                {
                    if (value["duallistbox"] != null)
                    {
                        Role rolselect = null;
                        string[] idrol = value["duallistbox"].Split(",".ToCharArray());
                        group.Roles = new List<Role>();
                        foreach (var item in idrol)
                        {
                            rolselect = db.Roles.Where(x => x.Id.ToString().Contains(item)).FirstOrDefault();
                            group.Roles.Add(rolselect);
                        }
                    }
                }
                group.Status = true;
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: /Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);

            ViewBag.Aplications = new SelectList(db.Aplications.ToList().OrderBy(x => x.Name).ToList(), "Id", "Name", group.Aplication_Id);

            ViewBag.Rols = string.Empty;
            ViewBag.RoleSelect = string.Empty;

            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server,Duration = 10, VaryByParam = "*")]
        public JsonResult FilterByIdAppEdit(string idApp, int idGroup)
        {
            List<Role> rolbyApp = db.Roles.Where(x => x.Aplications_Id == idApp).ToList();
            List<Role> rolselect = new List<Role>();
            List<Role> rolnotselect = new List<Role>();
            Group group = db.Groups.Find(idGroup);
            foreach (var item in rolbyApp)
            {
                if (item.Groups.Contains(group))
                {
                    rolselect.Add(item);
                }
                else
                {
                    rolnotselect.Add(item);
                }
            }
            SelectList listaRoles = new SelectList(rolselect, "Id", "Name");
            foreach (var item in listaRoles)
            {
                item.Selected = true;
            }

            return Json(new { Success = true, result1 = new SelectList(rolnotselect, "Id", "Name"), result2 = listaRoles }, JsonRequestBehavior.AllowGet);
        }

        // POST: /Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Status")] Group group, FormCollection value)
        {
            if (ModelState.IsValid)
            {
                string idApp = string.Empty;
                Group groupde = db.Groups.Include("Roles").Include("UserDomains").Where(x => x.Id == group.Id).FirstOrDefault();
                List<UserDomain> listuser = groupde.UserDomains.ToList();
                idApp = groupde.Aplication_Id;
                db.Groups.Remove(groupde);
                db.SaveChanges();

                if (value["duallistbox"] != null)
                {
                    Role rolselect = null;
                    string[] idrol = value["duallistbox"].Split(",".ToCharArray());
                    group.Roles = new List<Role>();
                    foreach (var item in idrol)
                    {
                        rolselect = db.Roles.Where(x => x.Id.ToString().Contains(item)).FirstOrDefault();
                        group.Roles.Add(rolselect);                        
                    } 
                }

                if (value[4] != "")
                    idApp = value[4];

                group.UserDomains = listuser;
                group.Aplication_Id = idApp;
                db.Groups.Add(group);
                db.SaveChanges();
                                
                
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: /Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Include("UserDomains").Where(x => x.Id == id.Value).FirstOrDefault();
            if (group == null)
            {
                return HttpNotFound();
            }
            if (group.UserDomains.Count > 0)
            {
                ViewBag.UserExist = "Existen Usuario/s asociados al grupo. No es posible eliminar el grupo.";                
            }
            return View(group);
        }

        // POST: /Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Include("Roles").Include("UserDomains").Where(x => x.Id == id).FirstOrDefault();
            db.Groups.Remove(group);
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
