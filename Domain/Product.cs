namespace AMS3A_SalesAPI.Domain
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public double Stock {  get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate = DateTime.Now;
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
