namespace BlazorEcommerce.Server.Services.CartServices
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponseDTO>>> GetCartItemsAsync(List<CartItem> cartItems);
    }
}
