using Amazon.Core.DataAccess.EntityFramework;
using Amazon.DataAccess.Abstract;
using Amazon.Entities.Concrete;
using Amazon.Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfRepositoryBase<Product, AmazonContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (AmazonContext context = new AmazonContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId = p.ProductId, ProductName = p.ProductName, 
                                 CategoryName = c.CategoryName, Price = p.Price, Description = p.Description };
                return result.ToList();
            } 
        }
    }
}
