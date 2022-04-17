using Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Entities.DTOs
{
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
