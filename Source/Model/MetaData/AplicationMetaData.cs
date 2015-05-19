using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [MetadataType(typeof(AplicationMetaData))]
    public partial class Aplication
    {
    }

    public class AplicationMetaData
    {
        [Required(ErrorMessage = "Ingrese un Id")]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required(ErrorMessage="Ingrese un nombre")]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}
