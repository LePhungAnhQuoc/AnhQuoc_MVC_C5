using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhQuoc_MVC_C5.Controllers
{
    public class UserController : Controller
    {
        QuanLyHangHoaEntities qlbh = new QuanLyHangHoaEntities();
        // GET: User
        public ActionResult Index(int? catId, int page = 1)
        {
            UserLogin user = new UserLogin();

            if (!Utilities.IsLogged())
            {
                return RedirectToAction("Login", "Account");
            }

            ViewData[nameof(user.Username)] = Session[nameof(user.Username)];
            return View();
        }

        public ActionResult ProductManage(int? catId, int page = 1)
        {
            IEnumerable<Product> products = null;
            if (catId != null)
            {
                products = qlbh.Products.Where(item => item.CatID == (int)catId);
            }
            else
            {
                products = qlbh.Products.ToList();
            }

            int total = products.Count();
            if (total > 0)
            {
                int nPage = total / Constants.nPerPage + (total % Constants.nPerPage > 0 ? 1 : 0);
                if (page < 1)
                    page = 1;

                if (page > nPage)
                    page = nPage;

                TempData["disableNext"] = false;
                TempData["disablePrevious"] = false;

                if (page == nPage)
                    TempData["disableNext"] = true;
                if (page == 1)
                    TempData["disablePrevious"] = true;

                ViewBag.totalPage = nPage;
                ViewBag.curPage = page;

                products = products.OrderBy(item => item.Id).Skip((page - 1) * Constants.nPerPage).Take(Constants.nPerPage);

                ViewBag.Categories = qlbh.Categories.ToList();
            }

            Utilities.MinusQuantity(products);
            return PartialView("_ProductManage", products);
        }

        // GET: Category
        public ActionResult GetListCategories()
        {
            return PartialView("_UserPartialGetCategories", qlbh.Categories.ToList());
        }
    }
}