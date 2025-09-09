using Microsoft.EntityFrameworkCore;
using CarRent.Models;

namespace CarRent.Data
{
    public class CarRentContext : DbContext
    {
        public CarRentContext(DbContextOptions<CarRentContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Car)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Booking)
                .WithOne(b => b.Contract)
                .HasForeignKey<Contract>(c => c.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.LicensePlate)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.DriverLicense)
                .IsUnique();

            modelBuilder.Entity<Contract>()
                .HasIndex(c => c.ContractNumber)
                .IsUnique();

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Admin", LastName = "User", Email = "admin@carrent.com", Phone = "+380501234567", DriverLicense = "ADM123456", Role = "Admin", CreatedAt = seedDate },
                new User { Id = 2, FirstName = "Manager", LastName = "User", Email = "manager@carrent.com", Phone = "+380501234568", DriverLicense = "MAN123456", Role = "Manager", CreatedAt = seedDate },
                new User { Id = 3, FirstName = "Іван", LastName = "Петренко", Email = "ivan@example.com", Phone = "+380501234569", DriverLicense = "CLI123456", Role = "Client", CreatedAt = seedDate }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Brand = "Toyota", Model = "Camry", Year = 2022, LicensePlate = "АА1234АА", PricePerDay = 1200m, IsAvailable = true, Description = "Комфортний седан для поїздок по місту" },
                new Car { Id = 2, Brand = "BMW", Model = "X5", Year = 2023, LicensePlate = "ВВ5678ВВ", PricePerDay = 2500m, IsAvailable = true, Description = "Преміум кросовер для далеких подорожей" },
                new Car { Id = 3, Brand = "Volkswagen", Model = "Golf", Year = 2021, LicensePlate = "СС9012СС", PricePerDay = 800m, IsAvailable = true, Description = "Економічний хетчбек для міських поїздок" }
            );
        }
    }
}
