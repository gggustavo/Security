using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBiblioteca.Controllers
{
    public class AbmLibrosController : Controller
    {
        //
        // GET: /Libros/
        [Authorize]
        public ActionResult AbmLibros()
        {
            return View();
        }

        //GET
        [HttpGet]
        [Authorize]
        [Helpers.CustomAuthorize()]
        public ActionResult Alta()
        {
            return View();
        }

        //POST
        [HttpPost]
        [Authorize]
        public ActionResult Alta(string values)
        {
            return View();
        }

        //GET
        [HttpGet]
        [Authorize]
        [Helpers.CustomAuthorize()]
        public ActionResult Baja()
        {
            return View();
        }

        //GET
        [HttpGet]
        [Authorize]
        [Helpers.CustomAuthorize()]
        public ActionResult Modificacion()
        {
            return View();
        }


	}
}