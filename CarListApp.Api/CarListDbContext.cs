using Microsoft.EntityFrameworkCore;

namespace CarListApp.Api
{
    public class CarListDbContext : DbContext
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
        }
    }
}