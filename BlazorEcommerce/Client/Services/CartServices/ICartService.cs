namespace BlazorEcommerce.Client.Services.CartServices
{
    public interface ICartService
    {
        event Action onChange;

        Task AddToCart(CartItem cartItem);

        Task <List<CartItem>> GetCartItems();

        Task<List<CartProductResponseDTO>> GetCartProducts();

        Task RemoveProductFromCart(int productId, int productTypeId);

        Task UpdateQuantity(CartProductResponseDTO product);
    }
}
