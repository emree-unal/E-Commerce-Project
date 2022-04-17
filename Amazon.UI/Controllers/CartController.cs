using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Business.Abstract;
using Amazon.UI.Extensions;
using Amazon.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Amazon.UI.Controllers
{
    public class CartController : Controller
    {
        private IProductService productService;

        public CartController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            Cart cart = GetCart();
            return View(cart);
        }

        public IActionResult AddToCart(int productId)
        {
            var product = productService.GetById(productId);
            if (product==null)
            {
                return BadRequest();
            }
            Cart cart = GetCart();
            cart.AddItem(product, 1);
            SaveCart(cart);

            return Json("OK");
        }
        public IActionResult RemoveCart(int id)
        {
            Cart cart = GetCart();
            var product = productService.GetById(id);
            cart.Remove(product);
            SaveCart(cart);
            return Json("OK");
        }

        public Cart GetCart()
        {
         
            Cart cart = HttpContext.Session.GetJson<Cart>("sepetim") ?? new Cart();
            return cart;
        } 

      
        void SaveCart(Cart cart)
        {
            HttpContext.Session.SetString("isOnline", "true");
            HttpContext.Session.SetJson("sepetim", cart);
        }
    }
}
