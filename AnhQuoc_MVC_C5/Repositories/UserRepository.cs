using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AnhQuoc_MVC_C5
{
    public class UserRepository : Repository<User>
    {
        public UserRepository()
        {
        }

        public UserRepository(ObservableCollection<User> items) : base(items)
        {
        }
    }
}