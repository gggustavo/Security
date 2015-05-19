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
    public class PermissionController : Controller
    {
        private SeguridadEntities db = new SeguridadEntities();

        // GET: /Permission/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Permissions.ToList().OrderBy(x => x.Name));
        }

        // GET: /Permission/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Permission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Permissions.Add(permission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(permission);
        }

        // GET: /Permission/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: /Permission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(permission);
        }

        // GET: /Permission/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: /Permission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Permission permission = db.Permissions.Find(id);
            db.Permissions.Remove(permission);
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
