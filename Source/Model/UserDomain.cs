//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserDomain
    {
        public UserDomain()
        {
            this.Groups = new HashSet<Group>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsUserAd { get; set; }
    
        public virtual ICollection<Group> Groups { get; set; }
    }
}
