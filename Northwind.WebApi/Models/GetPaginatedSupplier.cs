namespace Northwind.WebApi.Models
{
    public class GetPaginatedSupplier
    {
        public int Page { get; set; }
        public int Rows { get; set; }
        public string SearchTerm { get; set; }
    }
}
