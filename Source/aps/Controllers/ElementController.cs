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
    public class ElementController : Controller
    {
        private SeguridadEntities db = new SeguridadEntities();

        [Authorize]
        public ActionResult Index()
        {
            return View(db.Elements.ToList().OrderBy(x => x.Name));
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Aplications = new SelectList(db.Aplications.ToList().OrderBy(x => x.Name).ToList(), "Id", "Name"); ;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Element element)
        {
            if (ModelState.IsValid)
            {                             
                db.Elements.Add(element);
                db.SaveChanges();
                               
                return RedirectToAction("Index");
            }

            return View(element);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Element Element = db.Elements.Find(id);
            ViewBag.Aplications = new SelectList(db.Aplications.ToList().OrderBy(x => x.Name).ToList(), "Id", "Name");

            if (Element == null)
            {
                return HttpNotFound();
            }
            return View(Element);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Element element, FormCollection value)
        {
            if (ModelState.IsValid)
            {                                
                db.Entry(element).State = EntityState.Modified;                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(element);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Element Element = db.Elements.Find(id);
            return View(Element);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Element Element = db.Elements.Include("Permissions").Include("Roles").Where(x => x.Id == id).FirstOrDefault();
            db.Elements.Remove(Element);
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
