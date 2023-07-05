using Microsoft.AspNetCore.Mvc;

namespace pharmacy.Controllers
{
    public class Order : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
