using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OW.Operation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult aaaa()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}