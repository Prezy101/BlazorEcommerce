using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
            {
                 _productService = productService;
            }

		[HttpGet] 
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsAsync()
            {
                var response = await _productService.GetProductsAsync();
			    return Ok(response);
            }

        //Getting a product ID and passing it through a query string
        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsAsync(int productId)
            {
                var result = await _productService.GetProductsAsync(productId);
                return Ok(result);
            }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsFromCategoryAsync(string categoryUrl)
            {
                var result = await _productService.GetProductsFromCategoryAsync(categoryUrl);
                return Ok(result);

            }
        
        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResultDTO>>> SearchProduct(string searchText, int page = 1 )
            {
                var result = await _productService.SearchProduct(searchText, page);
                return Ok(result);
            }
        [HttpGet("searchSuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText)
            {
                var result = await _productService.GetProductSearchSuggestions(searchText);
                return Ok(result);
            }

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProduct()
            {
            var result = await _productService.GetFeaturedProduct();
                return Ok(result);
            }
    }
}
