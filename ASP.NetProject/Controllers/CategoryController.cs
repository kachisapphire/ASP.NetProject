using ASP.NetProject.Data;
using ASP.NetProject.Entities;
using ASP.NetProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetProject.Controllers
{
    public class CategoryController : Controller
    {
        MyDbContext _dbContext;

        public CategoryController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var categories = _dbContext.Categories.ToList();
            var categoryModelList = categories.Select(x => new CategoryModel
            {
                Name = x.Name
            }).ToList();
            return View(categoryModelList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CategoryModel categoryModel)
        {
            var categoryEntity = new Category
            {
                Name = categoryModel.Name
            };
            _dbContext.Categories.Add(categoryEntity);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}