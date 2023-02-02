namespace TsukuyomiMuseum.Models
{
    public class AdminView
    {
        public Product? product { get; set; }

        public Supply? supply { get; set; }

        public List<Category>? categories { get; set; }

        public List<Product>? products { get; set; }
    }
}
