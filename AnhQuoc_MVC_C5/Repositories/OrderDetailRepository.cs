using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AnhQuoc_MVC_C5
{
    public class OrderDetailRepository : Repository<OrderDetail>
    {
        public OrderDetailRepository()
        {
        }

        public OrderDetailRepository(ObservableCollection<OrderDetail> items) : base(items)
        {
        }
    }
}