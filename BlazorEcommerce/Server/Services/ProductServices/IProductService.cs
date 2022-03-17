namespace BlazorEcommerce.Server.Services.ProductServices

{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();

        Task<ServiceResponse<Product>> GetProductsAsync(int productId);

        Task<ServiceResponse<List<Product>>> GetProductsFromCategoryAsync(string categoryUrl);

        Task<ServiceResponse<ProductSearchResultDTO>>SearchProduct(string searchText, int page);

        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);

        Task<ServiceResponse<List<Product>>> GetFeaturedProduct();

    }
}
