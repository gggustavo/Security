using MSACommon;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace MSA.API
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public Result Get(string idApp, string idUser)
        {
            using (SeguridadEntities context = new SeguridadEntities())
            {
                Aplication aplication = context.Aplications.Where(x => x.Id == idApp).FirstOrDefault();
                if (aplication != null)
                {
                    Result result = new Result() { NameApp = aplication.Name, IdApp = aplication.Id };
                    result.NameApp = aplication.Name;
                    result.IdApp = aplication.Id;

                    UserDomain userdomain = context.UserDomains.Where(x => x.Name == idUser).FirstOrDefault();

                    userdomain.Groups = userdomain.Groups.Where(x => x.Aplication_Id.ToUpper() == idApp.ToUpper() && x.Status == true).ToList();
                    List<MSACommon.Element> listelement = new List<MSACommon.Element>();
                    List<MSACommon.Permission> listpermission = new List<MSACommon.Permission>();

                    if (userdomain != null && userdomain.Groups.Count > 0)
                    {
                        foreach (var gr in userdomain.Groups)
                        {
                            foreach (var role in gr.Roles)
                            {
                                MSACommon.Element elementValue;
                                foreach (var valueelement in role.Elements)
                                {
                                    elementValue = new MSACommon.Element() { IdElement = valueelement.Id, Name = valueelement.Name };
                                    MSACommon.Permission Permission;

                                    elementValue.Permissions = new List<MSACommon.Permission>();
                                    foreach (var perm in valueelement.Permissions)
                                    {
                                        Permission = new MSACommon.Permission() { IdPermission = perm.Id, Name = perm.Name };
                                        elementValue.Permissions.Add(Permission);
                                    }
                                    listelement.Add(elementValue);

                                }
                                result.Rol.Add(new MSACommon.Role() { IdRol = role.Id, NameRol = role.Name, Elements = listelement });
                            }
                            result.Group.Add(new MSACommon.Group() { IdGroup = gr.Id, NameGroup = gr.Name });
                        }
                    }
                    return result;
                }
                return null;
            }
        }

        [HttpGet]
        public List<Users> GetUsers(string idApp)
        {
            using (SeguridadEntities context = new SeguridadEntities())
            {
                Aplication aplication = context.Aplications.Include("Groups").Where(x => x.Id == idApp.ToUpper()).FirstOrDefault();
                List<Users> listUser = new List<Users>();
                foreach (var item in aplication.Groups)
                {
                   List<UserDomain> user = context.UserDomains.Where(x => x.Groups.Contains(item)).ToList();
                   foreach (var us in user)
                       listUser.Add(new Users() { Id = us.Id , Name = us.Name });
                }         
                return listUser;
            }
        }

        [HttpGet]
        public string GetPasswordByIdUser(string user)
        {
            using (SeguridadEntities context = new SeguridadEntities())
            {
                UserDomain userdomain = context.UserDomains.Where(x => x.Name.ToUpper() == user.ToUpper()).FirstOrDefault();
                if (userdomain != null)                
                    return userdomain.Password;
                
                return null;
            }
   
        }

    }
}