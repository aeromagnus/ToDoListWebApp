namespace ListingApp.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public users()
        {
            toDoList = new HashSet<toDoList>();
        }

        public int usersID { get; set; }

        [StringLength(20)]
        public string userName { get; set; }

        [StringLength(64)]
        public string password { get; set; }

        public DateTime? createdOn { get; set; }

        public bool? is_Deleted { get; set; }

        public DateTime? Modified_Date { get; set; }

        public int? USER_ROLEID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<toDoList> toDoList { get; set; }

        public virtual USERS_ROLE USERS_ROLE { get; set; }
    }
}
