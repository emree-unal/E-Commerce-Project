using Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Entities.Concrete
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
