using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Business.Abstract;
using Amazon.Entities.Concrete;
using Amazon.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.UI.Controllers
{
    public class UsersController : Controller
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile(string UserName)
        {
            var user = _userService.GetUserByUserName(UserName);
            return View(user);
        }

        [HttpPost]
        public IActionResult Profile(User user)
        {
            _userService.Update(user);
            return View();
        }

        public IActionResult CreateAccount(LoginViewModel model, string returnUrl)
        {
            var user = _userService.GetUserByUserName(model.UserName);
            if (user!=null)
            {
                ModelState.AddModelError("CreateUserError", "Bu kullanıcı adı kullanılmaktadır.");
            }
            _userService.Add(model.UserName, model.Password, model.Email, model.Name);
            if (Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }
    }
}
