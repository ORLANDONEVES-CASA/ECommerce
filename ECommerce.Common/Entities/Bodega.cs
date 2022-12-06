﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.Common.Entities
{
    public partial class Bodega
    {
        [Key]
        public int BodegaId { get; set; }
        public string Descripcion { get; set; }
        public int? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
