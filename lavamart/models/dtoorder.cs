using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace lavamart.models
{
    public class dtoaddorder
    {
        [Key]
        public int OrderId { get; set; }

        public string Id { get; set; }

        [AllowNull]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }   

        [AllowNull]
        public int TotalAmount { get; set; }

        [AllowNull]
        public string ShippingAddress { get; set; }
    }


    public class dtogetorder
    {
        public int OrderId { get; set; }

        public string Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string Status { get; set; }   

        public int TotalAmount { get; set; }

        public string ShippingAddress { get; set; }
    }
}
