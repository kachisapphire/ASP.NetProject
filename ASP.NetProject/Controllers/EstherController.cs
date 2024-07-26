using Microsoft.AspNetCore.Mvc;

namespace ASP.NetProject.Controllers
{
    public class EstherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View("~/Views/Esther/Add.cshtml");
        }
    }
}

