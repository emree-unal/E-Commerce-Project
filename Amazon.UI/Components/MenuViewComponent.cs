using Amazon.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.UI.Components
{
    public class MenuViewComponent:ViewComponent
    {
        private ICategoryService categoryservice;

        public MenuViewComponent(ICategoryService categoryService)
        {
            this.categoryservice = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var categories = categoryservice.GetCategories();
            return View(categories);
        }
    }
}
