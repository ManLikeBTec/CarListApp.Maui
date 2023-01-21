using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarListApp.Api
{
    public class CarListDbContext : IdentityDbContext
    {
        public CarListDbContext(DbContextOptions<CarListDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Make = "Honda",
                    Model = "Fit",
                    Vin = "ABC1"
                },
                new Car
                {
                    Id = 2,
                    Make = "Honda",
                    Model = "csd",
                    Vin = "ABC2"
                },
                new Car
                {
                    Id = 3,
                    Make = "Honda",
                    Model = "Fdscsdit",
                    Vin = "ABC3"
                },
                new Car
                {
                    Id = 4,
                    Make = "Honda",
                    Model = "Fsdcit",
                    Vin = "ABC4"
                }
            );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "b152ca2b-d8d7-4e8d-9863-af0f6f54609f",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "2ff6e43f-257d-4ec8-9fb0-32b7e6d66e4a",
                    Name = "User",
                    NormalizedName = "USER"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "a7ede16b-a1e2-4a7f-8135-e447d3875816",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Password"),
                    EmailConfirmed = true
                },
                new IdentityUser
                {
                    Id = "1bf5ab5a-fbbe-4f5a-8b10-893e3bd7ed63",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Password1"),
                    EmailConfirmed = true
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "b152ca2b-d8d7-4e8d-9863-af0f6f54609f",
                    UserId = "a7ede16b-a1e2-4a7f-8135-e447d3875816"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2ff6e43f-257d-4ec8-9fb0-32b7e6d66e4a",
                    UserId = "1bf5ab5a-fbbe-4f5a-8b10-893e3bd7ed63"
                }
            );
        }
    }
}