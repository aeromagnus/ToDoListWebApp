namespace ListingApp.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("toDoList")]
    public partial class toDoList
    {
        public int toDoListID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public int usersID { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? modified_On { get; set; }

        public bool is_Deleted { get; set; }

        public virtual users users { get; set; }
    }
}
