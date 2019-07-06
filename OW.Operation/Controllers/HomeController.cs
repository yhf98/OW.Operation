using Newtonsoft.Json;
using OW.Operation.Filter;
using OW.Operation.OW.Model;
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
        [Login(IsCheck = true)]
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
        [HttpPost]
        public string login(string name,string pwd)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
            {
                return JsonConvert.SerializeObject(new Msg() { status=0, message="账号或密码不能为空", action="" });
            }

            UserInfo user = OW.BLL.DataManager.GetUser(name,pwd);
            if (user != null)
            {
                Session["user"] = user;
                return JsonConvert.SerializeObject(new Msg() { status = 1, message = "登录成功!", action = "/Home/Index" });
            }
            else
            {
                return JsonConvert.SerializeObject(new Msg() { status = 0, message = "账号或密码不能为空", action = "" });
            }

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
        [Login(IsCheck = true)]
        public ActionResult Member()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 充值车辆
        /// </summary>
        /// <returns></returns>
        [Login(IsCheck = true)]
        public ActionResult Recharge()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 外来车辆
        /// </summary>
        /// <returns></returns>
        [Login(IsCheck = true)]
        public ActionResult Foreign()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 收入统计
        /// </summary>
        /// <returns></returns>
        [Login(IsCheck = true)]
        public ActionResult Statistics()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}