using Application;
using Domain.Carts;
using Domain.Products;

namespace Test
{
    public class CartServiceTest
    {
        [Fact]
        public void AddProductToCart_WhenProductIsNotInCart_ShouldAddProduct()
        {
            var cart = new Cart();
            var product = new Product(Guid.NewGuid(), "Product1", 10.0m, "Store1");
            var cartService = new CartService(cart);

            cartService.AddProductToCart(product, 1);

            Assert.Single(cart.Items);
            Assert.Equal(1, cart.Items[0].Quantity);
            Assert.Equal(10.0m, cartService.GetTotalAmount());
        }


        [Fact]
        public void AddProductToCart_WhenProductAlreadyInCart_ShouldUpdateQuantity()
        {
            var cart = new Cart();
            var product = new Product(Guid.NewGuid(), "Product1", 10.0m, "Store1");
            var cartService = new CartService(cart);
            cartService.AddProductToCart(product, 1);

            cartService.AddProductToCart(product, 2);

            Assert.Single(cart.Items);
            Assert.Equal(3, cart.Items[0].Quantity);
            Assert.Equal(30.0m, cartService.GetTotalAmount());
        }

        [Fact]
        public void RemoveProductFromCart_WhenProductIsInCart_ShouldRemoveQuantity()
        {
            var cart = new Cart();
            var product = new Product(Guid.NewGuid(), "Product1", 10.0m, "Store1");
            var cartService = new CartService(cart);
            cartService.AddProductToCart(product, 3);

            cartService.RemoveProductFromCart(product.Id, 2);

            Assert.Single(cart.Items);
            Assert.Equal(1, cart.Items[0].Quantity);
            Assert.Equal(10.0m, cartService.GetTotalAmount());
        }

        [Fact]
        public void RemoveProductFromCart_WhenProductIsNotInCart_ShouldThrowException()
        {
            var cart = new Cart();
            var product = new Product(Guid.NewGuid(), "Product1", 10.0m, "Store1");
            var cartService = new CartService(cart);

            Assert.Throws<InvalidOperationException>(() => cartService.RemoveProductFromCart(product.Id, 1));
        }
    }
}
