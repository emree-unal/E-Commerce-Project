using Amazon.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.UI.Components
{
    public class ProfileViewComponent:ViewComponent
    {
        private IUserService _userService;

        public ProfileViewComponent(IUserService userService)
        {
            this._userService = userService;
        }
        public IViewComponentResult Invoke(string Name)
        {
            var user = _userService.GetUserByUserName(Name);
            return View(user);
        }
    }
}
