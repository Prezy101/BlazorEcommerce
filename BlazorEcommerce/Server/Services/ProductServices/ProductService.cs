namespace BlazorEcommerce.Server.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService (DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            //Getting data from the database, but we are using the ServiveResponse class which has a generic type field Data, to hold data from the database
            var response = new ServiceResponse<List<Product>>()
            {
                //Data is a field from ServiceReponse which is used to hold database fields, added an orderby query
                Data = await _context.Products.OrderByDescending(p => p.Id)
                .Include(p => p.Variants).ToListAsync()

            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductsAsync(int productId)
        {
            var response = new ServiceResponse<Product>();

            var product = await _context.Products
                .OrderByDescending(p => p.Id)
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry but this product does not exist, Thank you";
            }
            else
            {
                response.Data = product;

            }
            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductsBySearch(searchText);

            List<string> result = new List<string>();
            
                foreach(var product in products)
            { 
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if(product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation).Distinct().ToArray();

                    var words = product.Description.Split()
                                .Select(s => s.Trim(punctuation));

                    foreach(var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                            {
                            result.Add(word);
                            };
                    }
                }

            }
            return new ServiceResponse<List<string>> { Data = result };

        }

        public async Task<ServiceResponse<List<Product>>> GetProductsFromCategoryAsync(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .OrderByDescending(p => p.Id)
                .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                .Include(p => p.Variants)
                .ToListAsync()

            };
            return response;
        }

        public  async Task<ServiceResponse<List<Product>>> GetFeaturedProduct()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                    .Where(p => p.Featured)
                    .Include(p => p.Variants)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<ProductSearchResultDTO>> SearchProduct(string searchText, int page)
        {
            var pageResults = 3f;

            var pageCount = Math.Ceiling((await FindProductsBySearch(searchText)).Count / pageResults);

            var products = await _context.Products
                            .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                            || p.Description.ToLower().Contains(searchText.ToLower()))
                            .Include(p => p.Variants)
                            .Skip((page - 1) * (int)(pageResults))
                            .Take((int)pageResults)
                            .ToListAsync();
            var response = new ServiceResponse<ProductSearchResultDTO>
            {
                Data = new ProductSearchResultDTO
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }

            };
            return response;
        }

        private async Task<List<Product>> FindProductsBySearch(string searchText)
        {
            return await _context.Products
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                                || p.Description.ToLower().Contains(searchText.ToLower()))
                                .Include(p => p.Variants)
                                .ToListAsync();
        }
    }
}
