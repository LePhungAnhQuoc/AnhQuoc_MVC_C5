using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhQuoc_MVC_C5.Controllers
{
    public class CartController : Controller
    {
        private Cart _Cart;
        public Cart Cart
        {
            get
            {
                return Utilities.GetCart();
            }
        }
        
        [HttpPost]
        public ActionResult Add(ProductQuantity productQty)
        {
            using (var qlbh = new QuanLyHangHoaEntities())
            {
                var pro = qlbh.Products.First(item => item.Id == productQty.Id);

                Cart.Items.Add(new CartItem
                {
                    Product = pro,
                    Quantity = productQty.Quantity,
                });
                Utilities.UpdateCart(Cart);

                pro.Quantity = pro.Quantity - productQty.Quantity;
            }
            return RedirectToAction("Details", "Product", new { id = productQty.Id });
        }


        public JsonResult GetCartJson(string selectedRole)
        {
            var l = Utilities.GetCart().Items;
            return Json(l.Select(item 
                => new
                {
                    product = item.Product.Name,
                    quantity = item.Quantity,
                    amount = item.Product.Price * item.Quantity
                }), JsonRequestBehavior.AllowGet);
        }
    }
}