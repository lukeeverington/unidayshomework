using System.Web.Mvc;
using UnidaysHomework.Models;
using UniDaysHomework.Services;

namespace UnidaysHomework.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(CreateUserInputModel model)
        {
            return null;
        }
    }
}