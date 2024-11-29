using Domain.Carts;
using Domain.Products;

namespace Application
{
    public class CartService : ICartService
    {
        private readonly Cart _cart;

        public CartService(Cart cart)
        {
            _cart = cart;
        }
        public void AddProductToCart(Product product, int quantity)
        {
            _cart.AddProduct(product, quantity);
        }

        public void RemoveProductFromCart(Guid productId, int quantity)
        {
            _cart.RemoveProduct(productId, quantity);
        }

        public IReadOnlyList<CartItem> GetCart()
        {
            return _cart.Items;
        }

        public decimal GetTotalAmount()
        {
            return _cart.TotalAmount;
        }
    }
}
