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
            //会员车辆
            ViewBag.hcar = OW.BLL.DataManager.GetCarsByType(2).Count;
            //充值
            ViewBag.ccar = OW.BLL.DataManager.GetCarsByType(3).Count;
            //外来
            ViewBag.wcar = OW.BLL.DataManager.GetCarsByType(1).Count;

            ViewBag.pcount = OW.BLL.DataManager.GetParkingInfos();

            ViewBag.scared = OW.BLL.DataManager.GetCarSettled();

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
            
            return View();
        }
        [HttpPost]
        public string login(string name,string pwd)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
            {
                return JsonConvert.SerializeObject(new Msg() { status=0, message="账号或密码不能为空", action="" });
            }

            AdminInfo user = OW.BLL.DataManager.GetAdmin(name,pwd);
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
            
            return View();
        }
        /// <summary>
        /// 会员车辆
        /// </summary>
        /// <returns></returns>
        [Login(IsCheck = true)]
        public ActionResult Member()
        {
            ViewBag.hcar = OW.BLL.DataManager.GetCarsByType(2);
            return View();
        }

        /// <summary>
        /// 充值车辆
        /// </summary>
        /// <returns></returns>
        [Login(IsCheck = true)]
        public ActionResult Recharge()
        {
            ViewBag.ccar = OW.BLL.DataManager.GetCarsByType(3);
            return View();
        }
        /// <summary>
        /// 外来车辆
        /// </summary>
        /// <returns></returns>
        [Login(IsCheck = true)]
        public ActionResult Foreign()
        {
            ViewBag.wcar = OW.BLL.DataManager.GetCarsByType(1);
            return View();
        }



        /// <summary>
        /// 收入统计
        /// </summary>
        /// <returns></returns>
        [Login(IsCheck = true)]
        public ActionResult Statistics()
        {
           
            return View();
        }
    }
}