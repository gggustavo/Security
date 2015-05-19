using Model;
using MSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace MSA.Controllers
{
    public class AccountUserController : Controller
    {
        //
        // GET: /Account/Manage
        public ActionResult ManageUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManageUser(ManageUserViewModel model)
        {            
            using (SeguridadEntities db = new SeguridadEntities())
	        {
                model.OldPassword = MSACommon.SecurityUtil.Encrypt(model.OldPassword);
                model.NewPassword = MSACommon.SecurityUtil.Encrypt(model.NewPassword);
                Model.UserDomain user = db.UserDomains.Where(x => x.Password.Contains(model.OldPassword)).FirstOrDefault();
                if (user != null)
                {
                    user.Password = model.NewPassword;
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.UserNotFound = "No se encuentra el usuario.";
                    return View(model);
                }
	        }
            ViewBag.UserNotification = "La password fue modificada correctamente";
            return View(model);
 
        }
	}
}