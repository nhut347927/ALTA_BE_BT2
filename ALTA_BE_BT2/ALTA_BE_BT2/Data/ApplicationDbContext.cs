using Microsoft.EntityFrameworkCore;
using ALTA_BE_BT2.Models;

namespace ALTA_BE_BT2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Intern> Interns { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AllowAccess> AllowAccesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<AllowAccess>()
                .HasOne(aa => aa.Role)
                .WithMany(r => r.AllowAccesses)
                .HasForeignKey(aa => aa.RoleId);
        }
    }
}