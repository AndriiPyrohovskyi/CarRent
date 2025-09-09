using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    /// <summary>
    /// Сутність автомобіля
    /// </summary>
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Model { get; set; } = string.Empty;

        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(50)]
        public string LicensePlate { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal PricePerDay { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(200)]
        public string? ImageUrl { get; set; }

        // Навігаційні властивості
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
