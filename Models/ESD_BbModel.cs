using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ESD_Project.Models
{
    public partial class ESD_BbModel : DbContext
    {
        public ESD_BbModel()
            : base("name=ESD_BbModel")
        {
        }

        public virtual DbSet<AcademicYear> AcademicYear { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Chart> Chart { get; set; }
        public virtual DbSet<GroupMember> GroupMember { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chart>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<GroupMember>()
                .Property(e => e.GroupId)
                .IsFixedLength();

            modelBuilder.Entity<GroupMember>()
                .HasMany(e => e.Role)
                .WithMany(e => e.GroupMember)
                .Map(m => m.ToTable("Credencial").MapLeftKey("GroupId").MapRightKey("RoleId"));

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleId)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.GroupId)
                .IsFixedLength();
        }
    }
}
