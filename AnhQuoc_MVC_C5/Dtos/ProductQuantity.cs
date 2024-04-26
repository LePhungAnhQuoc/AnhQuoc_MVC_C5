using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnhQuoc_MVC_C5
{
    public class ProductQuantity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public ProductQuantity()
        {
        }

        public ProductQuantity(int id, int quantity = 1)
        {
            Id = id;
            Quantity = quantity;
        }
    }
}