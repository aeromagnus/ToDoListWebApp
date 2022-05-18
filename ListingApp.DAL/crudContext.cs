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
        public virtual DbSet<USERS_ROLE> USERS_ROLE { get; set; }

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

            modelBuilder.Entity<users>()
                .HasMany(e => e.toDoList)
                .WithRequired(e => e.users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERS_ROLE>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<USERS_ROLE>()
                .Property(e => e.Descpt)
                .IsUnicode(false);

            modelBuilder.Entity<USERS_ROLE>()
                .HasMany(e => e.users)
                .WithOptional(e => e.USERS_ROLE)
                .HasForeignKey(e => e.USER_ROLEID);
        }
    }
}
