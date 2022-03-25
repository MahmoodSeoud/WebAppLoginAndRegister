using Microsoft.AspNetCore.Mvc;
using RegisterAndLogin.Models;
using RegisterAndLogin.Services;

namespace RegisterAndLogin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult ProcessLogin(UserModel userModel)
        {
            SercurityService service = new SercurityService();
            
            if (service.isValid(userModel))
            {
                return View("LoginSuccess", userModel);
            }
            else
            {
                return View("LoginFailure", userModel);
            }
        }
    }
}
