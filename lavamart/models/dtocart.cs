using System.ComponentModel.DataAnnotations;

namespace lavamart.models
{
    public class dtocartitem
    {
        public int CartItemId { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }

    public class dtocartsync
    {
        public List<dtocartitem> Data { get; set; } = new();

    }
}
