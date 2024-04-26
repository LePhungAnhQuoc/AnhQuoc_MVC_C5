using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnhQuoc_MVC_C5
{
    public class Cart
    {
        public IList<CartItem> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public int TotalQuantity()
        {
            return Items.Sum(x => x.Quantity);
        }
    }
}