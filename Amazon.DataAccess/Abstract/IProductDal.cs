using Amazon.Core.DataAccess;
using Amazon.Entities.Concrete;
using Amazon.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
