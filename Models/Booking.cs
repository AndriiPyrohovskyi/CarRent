using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    /// <summary>
    /// Сутність бронювання
    /// </summary>
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Active, Completed, Cancelled

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        // Навігаційні властивості
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; } = null!;

        public virtual Contract? Contract { get; set; }
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
