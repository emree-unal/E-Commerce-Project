using Amazon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.UI.Models
{
    public class Cart
    {
        private List<ProductInCart> products = new List<ProductInCart>();
        public void AddItem(Product product, int quantity)
        {
            ProductInCart existingProduct = products.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
            if (existingProduct==null)
            {
                products.Add(new ProductInCart {Product=product,Quantity=quantity });
            }
            else
            {
                existingProduct.Quantity += quantity;     
            }
        }
        public decimal GetTotalValue()
        {
            return products.Sum(x =>(decimal) x.Product.Price * (x.Quantity));
        }
        public void Clear() => products.Clear();
        public void Remove(Product product) => products.RemoveAll(x => x.Product.ProductId == product.ProductId);
        public IEnumerable<ProductInCart> Products => products;
    }
}
