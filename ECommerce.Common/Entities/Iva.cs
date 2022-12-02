using System;
using System.Collections.Generic;

namespace ECommerce.Common.Entities
{
    public partial class Iva
    {
        public int Ivaid { get; set; }
        public string Descripcion { get; set; }
        public decimal Tarifa { get; set; }
        public int? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
