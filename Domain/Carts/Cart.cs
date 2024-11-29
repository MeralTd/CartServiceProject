using Domain.Products;

namespace Domain.Carts
{
    public class Cart
    {
        private readonly List<CartItem> _items = new();

        public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

        public decimal TotalAmount => _items.Sum(item => item.Product.Price * item.Quantity);

        public void AddProduct(Product product, int quantity)
        {
            var cartItem = _items.FirstOrDefault(item => item.Product.Id == product.Id);
            if (cartItem != null)
            {
                cartItem.AddQuantity(quantity);
            }
            else
            {
                _items.Add(new CartItem(product, quantity));
            }
        }

        public void RemoveProduct(Guid productId, int quantity)
        {
            var cartItem = _items.FirstOrDefault(item => item.Product.Id == productId);
            if (cartItem == null)
            {
                throw new InvalidOperationException("Product not found in the cart.");
            }
            cartItem.RemoveQuantity(quantity);

            if (cartItem.Quantity == 0)
            {
                _items.Remove(cartItem);
            }
        }

    }
}
