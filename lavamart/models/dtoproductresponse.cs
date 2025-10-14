using lavamart.Data.models;

namespace lavamart.models
{
    public class dtoproductresponse
    {

        public int TotalCount { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public List<Products> Products { get; set; } = new();
    }
    
}
