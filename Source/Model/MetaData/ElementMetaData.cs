using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [MetadataType(typeof(ElementMetaData))]
    public partial class Element
    {
    }

    public class ElementMetaData
    {

        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre")]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Aplicacion")]
        public string Aplications_Id { get; set; }
    }
}
