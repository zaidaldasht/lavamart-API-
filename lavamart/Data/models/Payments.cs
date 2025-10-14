using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace lavamart.Data.models
{
    public class Payments
    {

        [Key]
        public int PaymentId { get; set; }

        public int OrderId { get; set; }

        [Required(ErrorMessage = "please enter PaymentMethod ")]
        [MaxLength(50)]
        public string PaymentMethod { get; set; } 

        [Required(ErrorMessage = "please enter the amount ")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "please enter the status ")]
        [MaxLength(50)]
        public string Status { get; set; }  // Paid, Pending, Failed

        [AllowNull]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        // Navigation property
        [ForeignKey("OrderId")]
        public Orders Orders { get; set; }
    }
}
