using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Common.Entities
{
    public partial class Genero
    {
        public Genero()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }
        [Key]
        public int GenderId { get; set; }
        public string GeneroName { get; set; }
        public string Description { get; set; }
        public int? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
