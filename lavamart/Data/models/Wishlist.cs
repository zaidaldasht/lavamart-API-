using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lavamart.Data.models
{
    public class Wishlist
    {

        [Key]
        public int WishlistId { get; set; }

        public string Id { get; set; }

        public int ProductId { get; set; }

        // Navigation property
        [ForeignKey("ProductId")]
        public Products Products { get; set; }

        [ForeignKey("Id")]
        public Users Users { get; set; }
    }
}
