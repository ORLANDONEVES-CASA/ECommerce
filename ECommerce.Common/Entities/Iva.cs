using System.ComponentModel.DataAnnotations;

namespace ECommerce.Common.Entities
{
    public partial class Iva
    {
        [Key]
        public int Ivaid { get; set; }
        public string Descripcion { get; set; }
        public decimal Tarifa { get; set; }
        public int? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
