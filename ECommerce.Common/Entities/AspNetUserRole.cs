using System;
using System.Collections.Generic;

namespace ECommerce.Common.Entities
{
    public partial class AspNetUserRole
    {
        public int UserRolId { get; set; }
        public Guid UserId { get; set; }
        public Guid RolId { get; set; }

        public virtual AspNetRole Rol { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
