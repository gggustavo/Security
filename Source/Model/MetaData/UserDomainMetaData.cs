using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [MetadataType(typeof(UserDomainMetaData))]
    public partial class UserDomain
    {
    }

    public class UserDomainMetaData
    {
        [Required(ErrorMessage = "Ingrese un Id")]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre")]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [MaxLength(100)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [Display(Name = "Usuario AD?")]
        public string IsUserAd { get; set; }
    }
}
