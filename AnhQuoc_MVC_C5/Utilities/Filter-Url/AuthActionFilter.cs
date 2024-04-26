using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhQuoc_MVC_C5
{
    public class AuthActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Utilities.IsLogged())
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }
    }
}