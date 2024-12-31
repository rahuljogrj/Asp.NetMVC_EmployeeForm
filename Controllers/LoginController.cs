using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication3.Models;
using WebApplication3.modules;
using WebApplication3.modules.EmployeeEntity;

namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {
        dbContext _db;
        LogInModel _objModel;

        public LoginController(dbContext dbcontext)
        {
            _db = dbcontext;
            _objModel = new LogInModel();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginCheckAsync(LogInModel mdlLogin)
        {
            UserMaster checkUser = _db.UserMaster.Where(x => x.UserName == mdlLogin.Username && x.Password == mdlLogin.Password).SingleOrDefault();
            if (checkUser != null)
            {
                HttpContext.Session.SetString("Username", checkUser.UserName);
                HttpContext.Session.SetString("Password", checkUser.Password);

                // Create the user's claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, checkUser.UserName),
                    new Claim(ClaimTypes.Role, "Admin") // Add role as a claim

                };

                // Create the claims identity
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                TempData["successMessage"] = "User Login successfully.....";
                return Json(new { message = TempData["successMessage"], isSuccess = true });
            }
            else
            {

                TempData["successMessage"] = "invalid username or password....";
                return Json(new { message = TempData["successMessage"], isSuccess = false });
            }
        }

        public async Task<IActionResult> LogOut()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
            return RedirectToAction("LogIn","LogIn");
        }

        public ActionResult Register(LogInModel mdlLogin)
        {
            UserMaster checkUSer = _db.UserMaster.Where(x => x.UserName == mdlLogin.Username).SingleOrDefault();
            if (checkUSer == null)
            {
                UserMaster registerUser = new UserMaster();

                registerUser.UserID = Guid.NewGuid();
                registerUser.CreationDate = DateTime.Now;
                registerUser.FirstName = mdlLogin.FirstName;
                registerUser.LastName = mdlLogin.LastName;
                registerUser.Emaill = mdlLogin.Emaill;
                registerUser.PhoneNumber = mdlLogin.PhoneNumber;
                registerUser.UserName = mdlLogin.Username;
                registerUser.Password = mdlLogin.Password;
                registerUser.ConfirmPassword = mdlLogin.ConfirmPassword;
                registerUser.Status = "A";

                _db.Entry(registerUser).State = EntityState.Added;
                _db.SaveChanges();

                TempData["successMessage"] = "User Register successfully.....";
                return Json(new { message = TempData["successMessage"], isSuccess = true });
            }
            else
            {
                TempData["successMessage"] = "Username Already is in Use.....";
                return Json(new { message = TempData["successMessage"], isSuccess = false });
            }
        }
    }
}
