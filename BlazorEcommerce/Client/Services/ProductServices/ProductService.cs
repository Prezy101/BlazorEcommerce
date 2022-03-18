
namespace BlazorEcommerce.Client.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //Initializing a new property so we can get values to set on it
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = string.Empty;

        public event Action ProductChanged;

        public int CurrentPage { get; set; } = 1;

        public int PageCount { get; set; } = 0;

        public string LastSearchText  { get; set; } = string.Empty;

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var results = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");

            return results;

        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ? 
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");


            if (result != null && result.Data != null)
            
                Products = result.Data;
                ProductChanged.Invoke();

                CurrentPage = 1;
                PageCount = 0;

            if(Products.Count == 0)
            
                Message = "No products found";           
        }

        public async Task<List<string>> GetProductSearchSuggestion(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");

            return result.Data;
        }

        public async Task SearchProduct(string searchText, int page)
        {
            LastSearchText = searchText;

            var results = await _httpClient
                .GetFromJsonAsync<ServiceResponse<ProductSearchResultDTO>>($"api/product/search/{searchText}/{page}");
            if (results != null && results.Data != null)
            {
                Products = results.Data.Products;
                CurrentPage = results.Data.CurrentPage;
                PageCount = results.Data.Pages;
            }
               
            

            if(Products.Count == 0)
            
                Message = "No products were found.";
                ProductChanged?.Invoke();
            
        }
    }
}
