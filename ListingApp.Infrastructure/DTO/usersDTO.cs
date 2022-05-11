using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.DTO
{
    public class usersDTO
    {
        public int usersID { get; set; }
        [Required]
        [StringLength(20)]
        public string userName { get; set; }
        [Required]
        [StringLength(20)]
        public string password { get; set; }
        public string hashedPassword { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
    }
}
