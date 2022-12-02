﻿using System;
using System.Collections.Generic;

namespace ECommerce.Common.Entities
{
    public partial class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Descripcion { get; set; }
        public int? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
