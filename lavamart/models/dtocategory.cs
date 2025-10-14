using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace lavamart.models
{
    public class dtocategory
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
