using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace lavamart.Data.models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "please enter the category name ")]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        [AllowNull]
        public string Description { get; set; }

     

    }
}
