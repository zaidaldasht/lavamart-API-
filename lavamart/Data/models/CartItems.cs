using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace lavamart.Data.models
{
    public class CartItems
    {
        [Key]
        public int CartItemId { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        // Navigation properties
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }

        [ForeignKey("ProductId")]
        public Products Products { get; set; }
    }
}
