using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace lavamart.Data.models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        public string Id { get; set; }

        [AllowNull]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }   // Pending, Shipped, Delivered, Cancelled

        [AllowNull]
        public int TotalAmount { get; set; }

        [AllowNull]
        public string ShippingAddress { get; set; }


        // Navigation property


        [ForeignKey("Id")]
        public Users Users { get; set; }
    }
}
