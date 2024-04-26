using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhQuoc_MVC_C5.Controllers
{
    public class ProductController : Controller
    {
        QuanLyHangHoaEntities qlbh = new QuanLyHangHoaEntities();
        // GET: Product

        [HttpGet]
        public ActionResult Index(int? catId, int page = 1)
        {
            IEnumerable<Product> products = null;
            if (catId != null)
            {
                products = qlbh.Products.Where(pro => pro.CatID == (int)catId);
            }
            else
            {
                products = qlbh.Products.ToList();
            }

            int total = products.Count();
            if (total == 0)
                return View(products);

            int nPage = total / Constants.nPerPage + (total % Constants.nPerPage > 0 ? 1 : 0);
            if (page < 1)
                page = 1;

            if (page > nPage)
                page = nPage;

            ViewBag.disableNext = false;
            ViewBag.disablePrevious = false;

            if (page == nPage)
                ViewBag.disableNext = true;
            if (page == 1)
                ViewBag.disablePrevious = true;

            ViewBag.totalPage = nPage;
            ViewBag.curPage = page;

            products = products.OrderBy(item => item.Id).Skip((page - 1) * Constants.nPerPage).Take(Constants.nPerPage);

            ViewBag.Categories = qlbh.Categories.ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var product = qlbh.Products.FirstOrDefault(item => item.Id == id);
                Utilities.MinusQuantity(product);
                return View(product);
            }
            return View("Index", qlbh.Products.ToList());
        }
    }
}