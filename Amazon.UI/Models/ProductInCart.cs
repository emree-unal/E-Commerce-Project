using Amazon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.UI.Models
{
    public class ProductInCart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}