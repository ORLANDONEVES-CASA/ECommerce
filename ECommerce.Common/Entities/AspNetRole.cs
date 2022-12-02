using System;
using System.Collections.Generic;

namespace ECommerce.Common.Entities
{
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            AspNetUserRoles = new HashSet<AspNetUserRole>();
        }

        public Guid RolId { get; set; }
        public string Rnombre { get; set; }
        public string NormalizedName { get; set; }
        public int? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
    }
}
