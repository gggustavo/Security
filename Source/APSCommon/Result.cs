using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MSACommon
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Result
    {
        [DataMember(Name = "IdApp")]
        public string IdApp { get; set; }

        [DataMember(Name = "NameApp")]
        public string NameApp { get; set; }

        [DataMember(Name = "Rol")]
        public List<Role> Rol { get; set; }

        [DataMember(Name = "Group")]
        public List<Group> Group { get; set; }

        public Result()
        {
            Group = new List<Group>();
            Rol = new List<Role>();                   
        }

    }

    public class Group
    {
        public int IdGroup { get; set; }
        public string NameGroup { get; set; }
    }

    public class Role
    {
        public int IdRol { get; set; }
        public string NameRol { get; set; }
        public List<Element> Elements { get; set; }
        
    }

    public class Element
    {
        public int IdElement { get; set; }
        public string Name { get; set; }
        public List<Permission> Permissions { get; set; }
    }

    public class Permission
    {
        public int IdPermission { get; set; }
        public string Name { get; set; }
    }
}
