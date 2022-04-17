using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Business.Abstract;
using Amazon.Entities.Concrete;
using Amazon.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Amazon.UI.Controllers
{
   // [Authorize]
   [Authorize(Roles ="Admin")] // rolü yalnızca admin olan kullanıcılar erişebilir.
    public class ProductsController : Controller
    {
        private ICategoryService categoryService;
        private IProductService productService;

        public ProductsController(IProductService productService,ICategoryService categoryService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }
        // [AllowAnonymous]  tüm controller için giriş gerekli ancak ındex için gerekli değildir çünkü bu kodla kaldırmış olduk.
        public int pageSize { get; set; } = 10;
        public IActionResult Index(int page=1)
        {

            var products = productService.GetProductDetails();
           
            var productsForPerPage = products.OrderBy(x => x.ProductId)
                                          .Skip((page - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((decimal)products.Count() / pageSize);
            
            return View(productsForPerPage);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> optionList = GetCategoriesForSelect();
            ViewBag.Options = optionList.AsEnumerable();
            return View();
        }

        private List<SelectListItem> GetCategoriesForSelect()
        {
            var optionList = new List<SelectListItem>();
            var categories = categoryService.GetCategories();
            categories.ToList().ForEach(c =>
            {
                SelectListItem selectListItem = new SelectListItem { Text = c.CategoryName, Value = c.CategoryId.ToString() };
                optionList.Add(selectListItem);
            });
            return optionList;
        }

        [HttpPost]
        public IActionResult Create([Bind("ProductName,Price,Description,ImageUrl,CategoryId")] Product product)
        {
            if (ModelState.IsValid )
            {
                var addedproduct=productService.Add(product);
                return Json(addedproduct.ProductName);
            }
            ViewBag.Options = GetCategoriesForSelect().AsEnumerable();
            return View();
        }
        public IActionResult Update(int id)
        {
            var product = productService.GetById(id);
            List<SelectListItem> optionList = GetCategoriesForSelect();
            ViewBag.Options = optionList.AsEnumerable();
            return View(product);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Update([Bind("ProductId,ProductName,Price,Description,ImageUrl,CategoryId")]Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Update(product);
                return Json("OK");
            }
           
            return View();
        }

        public IActionResult Delete(int id)
        {
            var product = productService.GetById(id);
            productService.Delete(product);
            return Json("OK");
        }

        //[HttpPost,ActionName("Delete")]
        //public IActionResult DeleteConfirm(int id)
        //{
        //    var product = productService.GetById(id);
        //    productService.Delete(product);
        //    return View();
        //}
    }
}
