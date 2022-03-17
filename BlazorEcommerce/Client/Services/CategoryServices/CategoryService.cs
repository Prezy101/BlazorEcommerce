namespace BlazorEcommerce.Client.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategoriesAsync()
        {
            var results = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
            
            if (results != null && results.Data != null)
            {
                Categories = results.Data;
            }
                
        }
    }
}
