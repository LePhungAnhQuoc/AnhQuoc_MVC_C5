using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhQuoc_MVC_C5
{
    public static class HtmlHelperExtend
    {
        public static MvcHtmlString LessString(this HtmlHelper html, string str, int maxlength)
        {
            if (str.Length < maxlength)
            {
                return new MvcHtmlString(str);
            }
            return new MvcHtmlString(string.Format("{0}....", str.Substring(0, maxlength - 3)));
        }

        public static string Price2String(this HtmlHelper html, double price)
        {
            return string.Format("{0:N0} đ", price);
        }
    }
}