namespace ODataExample.Models {
    public class Product {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string Description { get; set; } = default!;
        public decimal PriceTotal { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; } 
    }
}