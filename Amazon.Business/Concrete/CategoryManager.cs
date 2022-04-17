using Amazon.Business.Abstract;
using Amazon.DataAccess.Abstract;
using Amazon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;   
        }

        public Category Add(Category category)
        {
            return _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category GetById(int Id)
        {
            return _categoryDal.Get(x=>x.CategoryId==Id);
        }

        public List<Category> GetCategories()
        {
            return _categoryDal.GetAllEntities();
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
