using Amazon.Core.DataAccess.EntityFramework;
using Amazon.DataAccess.Abstract;
using Amazon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfRepositoryBase<Category,AmazonContext>,ICategoryDal
    {
    }
}
