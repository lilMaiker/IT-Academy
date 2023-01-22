using Microsoft.AspNetCore.Mvc;

namespace FriendsMVC.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
