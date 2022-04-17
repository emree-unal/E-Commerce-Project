using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Amazon.Business.Abstract;
using Amazon.Entities.Concrete;
using Amazon.UI.Models;

namespace Amazon.UI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }
        public int pageSize { get; set; } = 4;
        public IActionResult Index(int page=1, int? categoryId=0)
        {
            List<Product> products = null;
            
            if (categoryId.HasValue && categoryId!=0)
            {
                products = _productService.GetProductsByCategoryId(categoryId.Value);

            }
            else
            {
                products = _productService.GetAll();
            }
           
            var productsForPerPage = products.OrderBy(x => x.ProductId)
                                            .Skip((page - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToList();
            PagingInfo pagingInfo = new PagingInfo { CurrentPage = page, PageSize = pageSize, TotalItemsCount = products.Count() };
            var viewModel = new ProductListViewModal { Products = productsForPerPage,PagingInfo=pagingInfo }; 
          
            return View(viewModel);
        }

     

      
    }
}
