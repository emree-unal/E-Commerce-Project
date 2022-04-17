using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Business.Abstract;
using Amazon.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.UI.Controllers
{
    public class AdminDashboardController : Controller
    {
        private IProductService productService;

        public AdminDashboardController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            ViewBag.TotalNumber = TotalNumberOfProducts();
            ViewBag.TotalSoldPrice = TotalPriceOfProductSold();
            return View();
        }
        public int TotalNumberOfProducts()
        {
            return productService.GetAll().Count();
        }

        public decimal TotalPriceOfProductSold()
        {
            return productService.GetAll().Sum(x => x.Price);
        }
    }
}
