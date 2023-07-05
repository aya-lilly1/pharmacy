using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pharmacy_DbModel.Models;
using System.Security.Claims;

namespace pharmacy.Controllers
{
    public class BaseController : Controller
    {
        public readonly string _UserId;
        //public readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _UserId  = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;


        }
    }
}
