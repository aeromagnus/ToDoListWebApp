using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.BusinessObjects
{
    public class CategoryVM
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name name must be between 2 and 50 characters.")]
        [Display(Name = "Display Name")]
        public string Name { get; set; }
        //[Display(Name = "Created On")]
        public Nullable<System.DateTime> created_On { get; set; }
    }
}
