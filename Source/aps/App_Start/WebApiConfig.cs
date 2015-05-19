using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MSA
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			//config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Get",
                routeTemplate: "api/{controller}/Get/{idApp}/{idUser}",
                defaults: new { idApp = RouteParameter.Optional, idUser = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetUsers",
                routeTemplate: "api/{controller}/GetUsers/{idApp}/{idRol}",
                defaults: new { idApp = RouteParameter.Optional, idRol = RouteParameter.Optional }
            );

                config.Routes.MapHttpRoute(
                name: "GetPasswordByIdUser",
                routeTemplate: "api/{controller}/GetPasswordByIdUser/{user}",
                defaults: new { idApp = RouteParameter.Optional, idRol = RouteParameter.Optional }
            );

            

            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            //config.Formatters.Remove(config.Formatters.XmlFormatter);
         
        }
    }
}
