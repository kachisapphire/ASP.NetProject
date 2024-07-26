using ASP.NetProject.Data;
using ASP.NetProject.Entities;
using ASP.NetProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetProject.Controllers
{
    public class ProductController : Controller
    {
        MyDbContext _dbContext;

        public ProductController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            
            var products = _dbContext.Products.ToList();
            var productModelList = products.Select(x => new ProductModel
            {
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Quantity = x.Quantity
            }).ToList();
            return View(productModelList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductModel productModel)
        {
            var productEntity = new Product 
            { 
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                Quantity = productModel.Quantity
            };
            _dbContext.Products.Add(productEntity);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
		public IActionResult Edit(int Id)
        {
            return View();
        }

	}
}
