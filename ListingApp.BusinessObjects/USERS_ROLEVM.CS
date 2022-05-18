using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.BusinessObjects
{
   public class USERS_ROLEVM
    {[Key]
        public int USERS_ROLEID { get; set; }
        [StringLength(15)]
        [Display(Name="Role Name")]
        public string Name { get; set; }
        [StringLength(50)]
        [Display(Name ="Role Description")]
        public string Description { get; set; }
        public Nullable<System.DateTime> created_On { get; set; }

        public virtual ICollection<usersVM> usersVM { get; set; }
    }
}
