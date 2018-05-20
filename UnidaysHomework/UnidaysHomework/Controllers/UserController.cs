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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateUserInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            var result = _userService.Create(new CreateUserParameters(model.EmailAddress, model.Password));

            if (result.Success)
            {
                ViewBag.Message = $"User {model.EmailAddress} created.";
                return View(new CreateUserInputModel()
                {
                    EmailAddress = string.Empty,
                    Password = string.Empty
                });
            }

            ViewBag.Message = $"Sorry something went wrong. Please try again.";
            return View(model);
        }
    }
}