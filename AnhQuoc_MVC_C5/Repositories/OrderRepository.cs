using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AnhQuoc_MVC_C5
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository()
        {
        }

        public OrderRepository(ObservableCollection<Order> items) : base(items)
        {
        }
    }
}