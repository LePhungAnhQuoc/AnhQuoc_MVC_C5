using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace AnhQuoc_MVC_C5.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            using (var qlbh = new QuanLyHangHoaEntities())
            {
                return View(qlbh.Categories.ToList());
            }
        }
        
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            using (var qlbh = new QuanLyHangHoaEntities())
            {
                Category cat = qlbh.Categories.FirstOrDefault(item => item.Id == id);
                return View(cat);
            }
        }

        public ActionResult Delete(int id)
        {
            IEnumerable<Category> l = null;
            using (var qlbh = new QuanLyHangHoaEntities())
            {
                var cat = qlbh.Categories.FirstOrDefault(item => item.Id == id);
                if (cat != null)
                {
                    var productsByCat = qlbh.Products.Where(item => item.CatID == cat.Id);

                    if (productsByCat.Count() > 0)
                    {
                        Utilities.SetAlert(TempData, Utilities.NotifyNotValidToDelete(nameof(Category)), 2);
                    }
                    else
                    {
                        qlbh.Categories.Remove(cat);
                        qlbh.SaveChanges();
                    }
                }
                l = qlbh.Categories.ToList();
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Details(int id)
        {
            using (var qlbh = new QuanLyHangHoaEntities())
            {
                Category catFinded = qlbh.Categories.FirstOrDefault(item => item.Id == id);
                return View(catFinded);
            }
        }

        [HttpPost]
        public ActionResult Add(Category cat)
        {
            using (var qlbh = new QuanLyHangHoaEntities())
            {
                IEnumerable<Category> l = null;
                qlbh.Categories.Add(cat);
                qlbh.SaveChanges();

                l = qlbh.Categories.ToList();
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public ActionResult Edit(Category catNew)
        {
            using (var qlbh = new QuanLyHangHoaEntities())
            {
                int idEdit = catNew.Id;

                Category catOld = null;
                IEnumerable<Category> l = null;

                catOld = qlbh.Categories.FirstOrDefault(item => item.Id == idEdit);
                if (catOld != null)
                {
                    Utilities.Copy(catOld, catNew);
                    qlbh.SaveChanges();
                }
                l = qlbh.Categories.ToList();

                return RedirectToAction(nameof(Index));
            }
        }
    }
}