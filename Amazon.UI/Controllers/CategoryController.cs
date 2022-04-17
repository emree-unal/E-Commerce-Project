using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Business.Abstract;
using Amazon.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.UI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("CategoryName", "Description")] Category category)
        {
            if (ModelState.IsValid)
            {
               var addedcategory= _categoryService.Add(category);
                return Json(addedcategory);
            }
           
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category=_categoryService.GetById(id);
            _categoryService.Delete(category);

            return Json("OK");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = _categoryService.GetById(id);
            return View(category);
          
        }

        [HttpPost]
        public IActionResult Update([Bind("CategoryId", "CategoryName", "Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(category);
                return Json("OK");
            }
           
            return View();
        }

    }
}
