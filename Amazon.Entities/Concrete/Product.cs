using Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Entities.Concrete
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
