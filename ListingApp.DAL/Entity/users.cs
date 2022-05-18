namespace ListingApp.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class users
    {
        public int usersID { get; set; }

        [StringLength(20)]
        public string userName { get; set; }

        [StringLength(64)]
        public string password { get; set; }

        public DateTime? createdOn { get; set; }

        public bool? is_Deleted { get; set; }
    }
}
