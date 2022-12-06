using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ECommerce.Common.Models.Dtos
{
    public class BodegaDto
    {
        public int BodegaId { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Descripcion { get; set; }
        [Display(Name = "Está activo")]
        public int? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
