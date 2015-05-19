using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBiblioteca.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult Index()
        {

            if (Request.IsAuthenticated && HttpContext.Session["validateMenu"] == null && HttpContext.Session["usuarioLogueado"] != null)
            {
                MSACommon.Result list = MSACommon.SecurityUtil.GetListResult(ConfigurationManager.AppSettings["uri"], HttpContext.Session["usuarioLogueado"].ToString());

                string menu = string.Empty;
                string menulista = string.Empty;

                if (list != null && list.Rol.Count > 0)
                {
                    if (list.Rol[0].Elements.Count > 0)
                    {
                        foreach (var item in list.Rol[0].Elements)
                        {
                            menulista += "<li><a href='" + System.Web.VirtualPathUtility.ToAbsolute("~/" + item.Name + "/" + item.Name) + "'>" + item.Name + "</a></li>";
                        }
                    }                    
                }
                ViewBag.menu = menulista;
                HttpContext.Session.Add("validateMenu", menulista);
            }
            else
            {
                ViewBag.menu = HttpContext.Session["validateMenu"];
            }

            return PartialView("Menu");
        }
	}
}