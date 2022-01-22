using curso.web.mvc.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace curso.web.mvc.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginUserViewModel loginUserViewModel)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel createUserViewModel)
        {
            return View();
        }
    }
}
