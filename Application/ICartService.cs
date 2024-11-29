using Domain.Carts;
using Domain.Products;

namespace Application
{
    public interface ICartService
    {
        void AddProductToCart(Product product, int quantity);
        void RemoveProductFromCart(Guid productId, int quantity);
        IReadOnlyList<CartItem> GetCart();
        decimal GetTotalAmount();
    }
}
