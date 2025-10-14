namespace lavamart.models
{
    public class dtoproductsfilter
    {

        public string? Keyword { get; set; }
        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
        public string? Categories { get; set; }
    }
}
