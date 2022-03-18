namespace BlazorEcommerce.Client.Services.ProductServices
{
    public interface IProductService
    {
        event Action ProductChanged;
        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; } 
        //Initializing a property (Product)
        List <Product> Products { get; set; } 
        Task GetProducts(string? categoryUrl = null);
        Task <ServiceResponse<Product>> GetProduct(int productId);
        Task SearchProduct(string searchText, int page);
        Task <List<string>> GetProductSearchSuggestion(string searchText);

    }
}
 