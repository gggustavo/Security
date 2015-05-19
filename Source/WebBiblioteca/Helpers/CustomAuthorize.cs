using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBiblioteca.Helpers
{
    public class CustomAuthorize : ActionFilterAttribute
    {

        public CustomAuthorize(){}

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string module = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            string permission = HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();

            MSACommon.Result list = MSACommon.SecurityUtil.GetListResult(ConfigurationManager.AppSettings["uri"], HttpContext.Current.Session[0].ToString());

            Boolean valuepermission = false;
            foreach (var item in list.Rol[0].Elements)
            {
                if (item.Name == module)
                {
                    foreach (var per in item.Permissions)
                    {
                        if (per.Name == permission)
                        {
                            valuepermission = true;
                        }
                    }
                }
            }
            if (!(valuepermission))
            {
                string notAuthorizedPage = ConfigurationManager.AppSettings["NotView"];
                UrlHelper url = new UrlHelper(filterContext.RequestContext);
                string notAuthorizedUrl = url.Content(notAuthorizedPage);
                filterContext.HttpContext.Response.Redirect(notAuthorizedUrl, true);
            }          
        }
    }
}