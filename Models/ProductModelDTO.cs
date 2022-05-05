using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFirstWeb.Models
{
    public class ProductModelDTO
    {
        [DisplayName("Id number")]
        public int Id { get; set; }

        [DisplayName("Produce Name")]
        public string Name { get; set; }

        [DisplayName("Cost to customer")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string PriceString { get; set; }

        [DisplayName("What you get ....")]
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal Tax { get; set; }

        public ProductModelDTO(ProductModel p)
        {
            Id = p.Id;
            Name = p.Name;
            Price = p.Price;
            Description = p.Description;

            PriceString = string.Format("{0:C}", p.Price);
            ShortDescription = p.Description.Length <= 25 ? p.Description : p.Description.Substring(0, 25);
            Tax = p.Price * 0.15M;
        }
    }
}
