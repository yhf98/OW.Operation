using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OW.Operation.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Svgdisplay()
        {
            return PartialView("Svgdisplay");
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
        /// <summary>
        /// 会员车辆
        /// </summary>
        /// <returns></returns>
        public ActionResult Member()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 充值车辆
        /// </summary>
        /// <returns></returns>
        public ActionResult Recharge()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 外来车辆
        /// </summary>
        /// <returns></returns>
        public ActionResult Foreign()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 收入统计
        /// </summary>
        /// <returns></returns>
        public ActionResult Statistics()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}