using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AnhQuoc_MVC_C5
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository()
        {
        }

        public CategoryRepository(ObservableCollection<Category> items) : base(items)
        {
        }
    }
}