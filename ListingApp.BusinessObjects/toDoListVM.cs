using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ListingApp.BusinessObjects
{
    public class toDoListVM
    {
        [Key]
        public int toDoListID { get; set; }
        [Required]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name name must be between 2 and 50 characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public bool is_Deleted { get; set; }

        public List<toDoListVM> ListingData { get; set; }

        public virtual usersVM usersVM { get; set; }
    }
}
