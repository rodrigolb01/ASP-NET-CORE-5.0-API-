using WebApplication3.Domain.Helpers;


namespace WebApplication3.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double value { get; set; }
        public string observation { get; set; }
        public int CompanyID { get; set; }
    }
}
