using Microsoft.AspNetCore.Mvc;

namespace pharmacy.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
