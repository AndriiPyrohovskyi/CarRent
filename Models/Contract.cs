using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    /// <summary>
    /// Сутність договору
    /// </summary>
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BookingId { get; set; }

        [Required]
        [StringLength(50)]
        public string ContractNumber { get; set; } = string.Empty;

        [Required]
        public DateTime SignedDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Terms { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? AdditionalNotes { get; set; }

        [Required]
        public bool IsSigned { get; set; } = false;

        // Навігаційні властивості
        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; } = null!;
    }
}
