using Microsoft.EntityFrameworkCore;

namespace LCMonitoringSystem3.Models.Autorisation
{
    public class AutorisationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public AutorisationContext(DbContextOptions<AutorisationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "88Admin88";

            string defaultUserEmail = "user@gmail.com";
            string defaultUserPassword = "1user1";


            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };
            User defaultUser = new User { Id = 2, Email = defaultUserEmail, Password = defaultUserPassword, RoleId = userRole.Id };
            

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            modelBuilder.Entity<User>().HasData(new User[] { defaultUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
