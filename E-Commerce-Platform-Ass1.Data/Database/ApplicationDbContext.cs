using E_Commerce_Platform_Ass1.Data.Database.Configurations;
using E_Commerce_Platform_Ass1.Data.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Platform_Ass1.Data.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
