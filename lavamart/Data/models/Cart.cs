using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace lavamart.Data.models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public string Id { get; set; }

        [AllowNull]
        public DateTime Creatdate { get; set; } = DateTime.Now;

        // Navigation property
    
        [ForeignKey("Id")]
        public Users Users { get; set; }
    }
}
