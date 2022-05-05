using Microsoft.AspNetCore.Mvc;
using MyFirstWeb.Models;
using MyFirstWeb.Services;
using System.Web.Http.Description;

namespace MyFirstWeb.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductsControllerAPI : ControllerBase
    {
        ProductsDAO productsDAO;

        public ProductsControllerAPI()
        {
            productsDAO = new ProductsDAO();
        }

        [HttpGet]
        public ActionResult <IEnumerable<ProductModel>> Index()
        {
            return productsDAO.GetAllProducts();
        }

        [HttpGet("DTO")] //DTO version of all the products
        [ResponseType(typeof(ProductModelDTO))]
        public IEnumerable<ProductModelDTO> DTO()
        {
            List<ProductModel> products = productsDAO.GetAllProducts();

            IEnumerable<ProductModelDTO> productsDTO = from product in products select new ProductModelDTO(product);
            return productsDTO;
        }

        [HttpGet("SearchResults/{searchTerm}")]
        public ActionResult <IEnumerable<ProductModel>> SearchResults(string searchTerm)
        {
            return productsDAO.SearchProducts(searchTerm);
        }

        [HttpGet("ShowProductDetail/{id}")]
        public ActionResult <ProductModel> ShowProductDetail(int id)
        {
            return productsDAO.GetProductById(id);
        }

        [HttpGet("ShowProductDetail/DTO/{id}")]
        public ActionResult<ProductModelDTO> ShowProductDTODetail(int id) // DTO version 
        {
            var product = productsDAO.GetProductById(id);
            return new ProductModelDTO(product);
        }

        [HttpPost("insertOne")]
        public ActionResult <int> InsertOne(ProductModel product)
        {
            var newId = productsDAO.Insert(product);
            return newId;
        }

        [HttpPut("ProcessEdit")]
        public ActionResult <ProductModel> ProcessEdit(ProductModel product)
        {
            productsDAO.Update(product);
            return productsDAO.GetProductById(product.Id);
        }

        [HttpDelete("DeleteOne/{id}")]
        public ActionResult<int> Delete(int id)
        {
            ProductModel product = productsDAO.GetProductById(id);
            return productsDAO.Delete(product);
        }
    }
}
