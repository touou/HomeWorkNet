using Microsoft.AspNetCore.Mvc;
using HW7Reflection.Models;

namespace HW7Reflection.Controllers
{
    
    [Route("User")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult UserCred()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserCred(User user)
        {
            return View(user);
        }
    }
}