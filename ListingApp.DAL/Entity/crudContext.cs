using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ListingApp.DAL.Entity
{
    public partial class crudContext : DbContext
    {
        public crudContext()
            : base("name=crudContext")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<toDoList> toDoList { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<toDoList>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.password)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<ListingApp.BusinessObjects.usersVM> usersVMs { get; set; }
    }
}
