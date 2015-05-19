using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MSACommon
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Users
    {
        [DataMember(Name="Id")]
        public int Id { get; set; }
        
        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }
}
