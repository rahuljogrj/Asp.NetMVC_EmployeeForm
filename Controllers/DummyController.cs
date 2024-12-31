using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DummyController : Controller
    {
        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("Username");
            ViewBag.Username = username;

            return View();
        }
    }
}
