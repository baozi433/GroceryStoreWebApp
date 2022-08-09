using Bogus;
using Microsoft.AspNetCore.Mvc;
using MyFirstWeb.Models;
using MyFirstWeb.Services;
using MyFirstWeb.Utility;

namespace MyFirstWeb.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDAO products;
        public ProductsController()
        {
            products = new ProductsDAO();
        }
        public IActionResult Index()
        {
            return View(products.GetAllProducts());
        }

        public IActionResult Welcome(string firstName, int secretNumber)
        {
            ViewBag.FirstName = firstName;
            ViewBag.SecretNumber = secretNumber;
            return View();
        }

        public IActionResult SearchResults(string searchTerm)
        {
            MyLogger.GetInstance().Info($"You just searched {searchTerm}."); // log to the file
            List<ProductModel> productsList = products.SearchProducts(searchTerm);
            return View("index", productsList);
        }

        public IActionResult SearchForm(string searchTerm)
        {
            return View();
        }

        public IActionResult ShowProductDetail(int id)
        {
            ProductModel product = products.GetProductById(id);
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            ProductModel foundProduct = products.GetProductById(id);
            return View("ShowEdit", foundProduct);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            MyLogger.GetInstance().Info($"The info of {product.Name} has been updated.");
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult Delete(int id)
        { 
            ProductModel product = products.GetProductById(id);
            MyLogger.GetInstance().Warning($"{product.Name} with id:{id} has been deleted!"); 
            products.Delete(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ProcessCreate(ProductModel product)
        {
            MyLogger.GetInstance().Info($"{product.Name} has been added!");

            return View("ShowProductDetail", product);
        }

    }
}
