using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace lavamart.Data.models
{
    public class Products
    {

        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "please enter the product name")]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "please enter the product descreption")]
        [MaxLength(300)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [AllowNull]
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        [AllowNull]
        public string Image { get; set; }

        [AllowNull]
        public DateTime Createdate { get; set; } = DateTime.Now;

        // Navigation property
        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }


    }
}
