using Amazon.Business.Abstract;
using Amazon.DataAccess.Abstract;
using Amazon.Entities.Concrete;
using Amazon.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            this._productDal = productDal;    
        }
        public Product Add(Product product)
        {
            _productDal.Add(product);
            return product;
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAllEntities();
        }

        public Product GetById(int Id)
        {
            return _productDal.Get(filter:p=>p.ProductId==Id);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

        public List<Product> GetProductsByCategoryId(int Id)
        {
            return _productDal.GetAllEntities(x => x.CategoryId == Id);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
