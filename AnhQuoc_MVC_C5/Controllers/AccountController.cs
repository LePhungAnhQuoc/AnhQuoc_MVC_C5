using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnhQuoc_MVC_C5.Controllers
{
    public class AccountController : Controller
    {
        private const int monthsLogin = 1;
        
        public ActionResult Login()
        {
            UserLogin user = new UserLogin();
            if (Utilities.IsLogged())
            {
                return RedirectToAction("Index", "User");
            }

            user = new UserLogin
            {
                RememberMe = true,
            };
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(UserLogin user)
        {
            bool isCheck = true;
            var passwordHashed = Utilities.Md5HashType2(user.Password);
            User userCheck = null;

            Action<int> addCookieHandler = (monthsLoginQuantity) =>
            {
                var cookie = new HttpCookie("userId", userCheck.Id.ToString());
                cookie.Expires = DateTime.Now.AddMonths(monthsLoginQuantity);
                Response.Cookies.Add(cookie);
            };

            using (var qlhh = new QuanLyHangHoaEntities())
            {
                IEnumerable<User> listUser = qlhh.Users;
                userCheck = listUser.SingleOrDefault(item => item.Username == user.Username);

                if (userCheck == null)
                {
                    isCheck = false;
                }
                else
                {
                    if (passwordHashed != userCheck.Password)
                    {
                        isCheck = false;
                    }
                }
                if (!isCheck)
                    ModelState.AddModelError(nameof(user.Password), "Username or Password isn't correct.");
                if (ModelState.IsValid == false)
                    return View(user);

                if (user.RememberMe)
                {
                    addCookieHandler(monthsLogin);
                }
                // add new session
                Session[nameof(user.Username)] = user.Username;
                Session[nameof(user.Password)] = user.Password;

                return RedirectToAction("Index", "User");
            }
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisting user)
        {
            using (var qlbh = new QuanLyHangHoaEntities())
            {
                if (qlbh.Users.FirstOrDefault(item => item.Username == user.Username) != null)
                {
                    ModelState.AddModelError(nameof(user.Username), "This account has already existed");
                }
                if (string.Compare(user.PasswordRetype, user.Password, false) != 0)
                {
                    ModelState.AddModelError(nameof(user.PasswordRetype), "The re-entered password must be the same as above");
                }

                if (ModelState.IsValid == false)
                {
                    return View(user);
                }

                var passwordHashed = Utilities.Md5HashType2(user.Password);

                var newUser = new User
                {
                    // Id = user.Id,
                    Username = user.Username,
                    Password = passwordHashed,
                    Name = user.Name,
                    Email = user.Email,
                    DOB = user.DOB,
                    Permission = 0,
                };

                qlbh.Users.Add(newUser);
                qlbh.SaveChanges();

                return RedirectToAction("Index", "Login");
            }
               
        }

        [AuthActionFilter]
        public ActionResult UserProfile()
        {
            using (var qlbh = new QuanLyHangHoaEntities())
            {
                string userUsername = Session["Username"].ToString();
                User user = qlbh.Users.FirstOrDefault(item => item.Username == userUsername);

                return View(user);
            }
        }


        public ActionResult LogOut()
        {
            UserLogin user = new UserLogin();

            Response.Cookies["userId"].Expires = DateTime.Now.AddDays(-1);
            Session[nameof(user.Username)] = null;
            Session[nameof(user.Password)] = null;

            return RedirectToAction("Login", "Account");
        }
    }
}