namespace Domain.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Store { get; set; }

        public Product(Guid id, string name, decimal price, string store)
        {
            Id = id;
            Name = name;
            Price = price;
            Store = store;
        }
    }
}
