using System;
using System.Collections.Generic;

namespace ECommerce.Common.Entities
{
    public partial class Medidum
    {
        public Medidum()
        {
            Productos = new HashSet<Producto>();
        }

        public int MedidaId { get; set; }
        public string Descripcion { get; set; }
        public string Escala { get; set; }
        public int? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
