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
    public class AplicationController : Controller
    {
        private SeguridadEntities db = new SeguridadEntities();

        [Authorize]
        public ActionResult Index()
        {
            var aplication = db.Aplications.ToList().OrderBy(x => x.Name);
            return View(aplication);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aplication aplication)
        {
            if (ModelState.IsValid)
            {
                db.Aplications.Add(aplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aplication);
        }

        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplication aplication = db.Aplications.Find(id);

            if (aplication == null)
            {
                return HttpNotFound();
            }
            return View(aplication);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aplication aplication, FormCollection value)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aplication).State = EntityState.Modified;                  
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aplication);
        }

        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplication aplication = db.Aplications.Find(id);

            if (aplication.Elements.Count > 0)
                ViewBag.ElementAsociation = "Existe Elemento/s asociados a la aplicación. No es posible eliminar la aplicación.";

            if (aplication == null)
            {
                return HttpNotFound();
            }
            return View(aplication);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Aplication aplication = db.Aplications.Include("Groups").Include("Elements").Include("Roles").Where(x => x.Id == id).FirstOrDefault();
            db.Aplications.Remove(aplication);
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
