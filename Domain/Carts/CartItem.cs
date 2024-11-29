using Domain.Products;

namespace Domain.Carts
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void RemoveQuantity(int quantity)
        {
            if (Quantity - quantity < 0)
                throw new InvalidOperationException("No more items can be removed than are already in the cart.");
            Quantity -= quantity;
        }
    }
}
