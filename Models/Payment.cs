using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    /// <summary>
    /// Сутність платежу
    /// </summary>
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BookingId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = string.Empty; // Cash, Card, Transfer

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Completed, Failed, Refunded

        [StringLength(100)]
        public string? TransactionId { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        // Навігаційні властивості
        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; } = null!;
    }
}
