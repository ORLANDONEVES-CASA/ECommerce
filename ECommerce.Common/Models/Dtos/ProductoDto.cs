using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ECommerce.Common.Models.Dtos
{
    public class ProductoDto
    {
        public int IdProducto { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        public string Nombre { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        public string Descripcion { get; set; }


        public int DepartamentoId { get; set; }


        public int IVAId { get; set; }


        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(3, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        public double Precio { get; set; } 


        [Display(Name = "Notas")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(600, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        public string Notas { get; set; }


        [Display(Name = "Imagen")]
        public byte Imagen { get; set; }


        [Display(Name = "PathImagen")]
        [MaxLength(600)]
        public string PathImagen { get; set; }


        [Display(Name = "GuidImagen")]
        public Guid GuidImagen { get; set; }


        public int MedidaId { get; set; }


        [Display(Name = "Medida")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public double Medida { get; set; }


        [Display(Name = "Pieza")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Pieza { get; set; }


        [Display(Name = "Está activo")]
        public int? IsActive { get; set; }


        public DateTime? RegistrationDate { get; set; }

    }
}
