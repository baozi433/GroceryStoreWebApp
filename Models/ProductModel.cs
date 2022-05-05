using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFirstWeb.Models
{
    public class ProductModel
    {
        [DisplayName("Id number")]
        public int Id { get; set; }
        [DisplayName("Produce Name")]
        public string Name { get; set; }
        [DisplayName("Cost to customer")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DisplayName("What you get ....")]
        public string Description { get; set; }
    }
}
