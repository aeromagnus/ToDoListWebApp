using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ListingApp.BusinessObjects
{
    public class usersVM
    {
        [Key]
        public int usersID { get; set; }
        [Required]
        [StringLength(20)]
        public string userName { get; set; }
        [Required]
        [StringLength(20)]
        public string pass { get; set; }
        public string hashedPass { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }

        public List<usersVM> listUsers { get; set; }
    }
}
