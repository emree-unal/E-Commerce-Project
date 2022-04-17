using Amazon.Core.DataAccess;
using Amazon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
    }
}
