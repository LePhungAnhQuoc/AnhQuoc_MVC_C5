using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AnhQuoc_MVC_C5
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository()
        {
        }

        public ProductRepository(ObservableCollection<Product> items) : base(items)
        {
        }
    }
}