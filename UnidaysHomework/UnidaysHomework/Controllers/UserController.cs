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
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var result = _userService.Create(new CreateUserParameters(model.EmailAddress, model.Password));

            if (result.Success)
            {

            }
            else
            {

            }


            return null;
        }
    }
}