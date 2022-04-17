using Amazon.Entities.Concrete;
using Amazon.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int Id);
        List<Product> GetProductsByCategoryId(int Id);
        Product Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        List<ProductDetailDto> GetProductDetails();
    }
}
