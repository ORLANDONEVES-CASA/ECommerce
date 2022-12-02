using System;
using System.Collections.Generic;

namespace ECommerce.Common.Entities
{
    public partial class TipoDocumento
    {
        public int TipoDocumentoId { get; set; }
        public string Descripcion { get; set; }
        public int? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
