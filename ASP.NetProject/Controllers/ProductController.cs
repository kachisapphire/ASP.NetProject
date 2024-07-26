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
                Id = x.Id,
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
		public IActionResult Edit(int id)
        {
            // look for products with this id
            var productEntity = _dbContext.Products.Find(id);

            //if this product was not found wit that id
            // return not found
            if (productEntity == null)
            {
                return View("Error");
            }
            // copy from product entity to product model
            var productModel = new ProductModel
            {
                 Description = productEntity.Description,
                 Price = productEntity.Price,
                 Quantity = productEntity.Quantity,
                 Name = productEntity.Name,
                 Id = productEntity.Id
            };
            return View(productModel);
        }
        [HttpPost]

		public IActionResult Edit(ProductModel productModel)
        {
			// look for product with this id
			var productEntity = _dbContext.Products.Find(productModel.Id);

			//if this product was not found wit that id
			// return not found
			if (productEntity == null)
			{
				return View("Error");
			}
            //lets update our entity
            productEntity.Description = productModel.Description;
            productEntity.Price = productModel.Price;
            productEntity.Quantity = productModel.Quantity;
            productEntity.Name = productModel.Name;
            // save the new updates
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
		}
        [HttpPost]
        public IActionResult Delete(int id)
        {
			var productEntity = _dbContext.Products.Find(id);

			if (productEntity == null)
			{
				return View("Error");
			}
            //remove product entity from product table
            _dbContext.Products.Remove(productEntity);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
		}

	}
}
