using Amazon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Business.Abstract
{
    public interface ICategoryService
    {
        Category Add(Category category);
        void Delete(Category category);
        Category GetById(int Id);
        void Update(Category category);
        public List<Category> GetCategories();
    }
}
