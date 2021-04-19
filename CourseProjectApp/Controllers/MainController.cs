using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseProjectApp.Controllers
{
    public class MainController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.value = "My first MVC route!!!";
            return View();
        }
    }
}
