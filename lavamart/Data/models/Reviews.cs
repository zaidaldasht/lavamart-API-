using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace lavamart.Data.models
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }

        public int ProductId { get; set; }

        public string Id { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [AllowNull]
        public string Comment { get; set; }

        [AllowNull]
        public DateTime Creatdate { get; set; } = DateTime.Now;

        // Navigation property
        [ForeignKey("ProductId")]
        public Products Products { get; set; }

        [ForeignKey("Id")]
        public Users Users { get; set; }

    }
}
