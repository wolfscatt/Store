using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
            var products = _manager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };
            var productlistViewModel = new ProductListViewModel(){
                Products = products,
                Pagination = pagination
            };
            return View(productlistViewModel);
        }
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var product = _manager.ProductService.GetOneProduct(id, false);
            return View(product);
        }
    }
}