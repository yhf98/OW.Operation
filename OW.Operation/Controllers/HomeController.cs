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
            //////////////////////生成图表////////////////////////////////////////////
            var options = new
            {
                xAxis = new XAxis
                {
                    data = new List<string>() { "0", "3", "6", "9", "12" },
                    type = "category",
                },
                yAxis = new YAxis
                {
                    type = "value"
                },
                series = new Series
                {
                    data = new List<int>() { 100, 110, 120, 130, 100, 133, 90, 180, 70 },
                    type = "line"
                }
            };

            Session["option"] = JsonConvert.SerializeObject(options);

            //////////////////////生成图表////////////////////////////////////////////

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
        public string login(string name, string pwd)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
            {
                return JsonConvert.SerializeObject(new Msg() { status = 0, message = "账号或密码不能为空", action = "" });
            }

            AdminInfo user = OW.BLL.DataManager.GetAdmin(name, pwd);
            if (user != null)
            {
                Session["user"] = user;
                Session["Username"] = user.AdminName;

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

            int page = 0;
            if (string.IsNullOrEmpty(Request["page"]))
            {
                page = 1;
            }
            else
            {
                page = Convert.ToInt32(Request["page"]);
            }
            List<CarsInfo> tatol = OW.BLL.DataManager.GetCarsByType(2);
            List<CarsInfo> currrnt = new List<CarsInfo>();
            int start = (page - 1) * 8;

            int end = page * 8 + 1;
            int i = 1;
            foreach (CarsInfo item in tatol)
            {
                if (i < end && i > start)
                {
                    if (currrnt.Count > 8) break;
                    currrnt.Add(item);
                }
                i++;
            }

            ViewBag.hcar = currrnt;

            ViewBag.currentPage = page;
            ViewBag.totalPage = tatol.Count / 8 + 1;
            ViewBag.total = tatol.Count;

            return View();
        }

        /// <summary>
        /// 充值车辆
        /// </summary>
        /// <returns></returns>
        [Login(IsCheck = true)]
        public ActionResult Recharge()
        {
            int page = 0;
            if (string.IsNullOrEmpty(Request["page"]))
            {
                page = 1;
            }
            else
            {
                page = Convert.ToInt32(Request["page"]);
            }
            List<CarsInfo> tatol = OW.BLL.DataManager.GetCarsByType(3);
            List<CarsInfo> currrnt = new List<CarsInfo>();
            int start = (page - 1) * 8;

            int end = page * 8 + 1;
            int i = 1;
            foreach (CarsInfo item in tatol)
            {
                if (i < end && i > start)
                {
                    if (currrnt.Count > 8) break;
                    currrnt.Add(item);
                }
                i++;
            }

            ViewBag.ccar = currrnt;

            ViewBag.currentPage = page;
            ViewBag.totalPage = tatol.Count / 8 + 1;
            ViewBag.total = tatol.Count;

            return View();
        }
        /// <summary>
        /// 外来车辆
        /// </summary>
        /// <returns></returns>
        [Login(IsCheck = true)]
        public ActionResult Foreign()
        {
            int page = 0;
            if (string.IsNullOrEmpty(Request["page"]))
            {
                page = 1;
            }
            else
            {
                page = Convert.ToInt32(Request["page"]);
            }
            List<CarsInfo> tatol = OW.BLL.DataManager.GetCarsByType(1);
            List<CarsInfo> currrnt = new List<CarsInfo>();
            int start = (page - 1) * 8;

            int end = page * 8 + 1;
            int i = 1;
            foreach (CarsInfo item in tatol)
            {
                if (i < end && i > start)
                {
                    if (currrnt.Count > 8) break;
                    currrnt.Add(item);
                }
                i++;
            }

            ViewBag.wcar = currrnt;

            ViewBag.currentPage = page;
            ViewBag.totalPage = tatol.Count / 8 + 1;
            ViewBag.total = tatol.Count;



            return View();
        }



        /// <summary>
        /// 收入统计
        /// </summary>
        /// <returns></returns>
        [Login(IsCheck = true)]
        public ActionResult Statistics()
        {

            var options =new {
                xAxis= new XAxis
                {
                    data = new List<string>() { "0", "3", "6", "9", "12" },
                    type = "category",
                },
                yAxis=new YAxis {
                    type = "value"
                },
                series=new Series {
                    data = new List<int>() { 100, 110, 120, 130, 100, 133, 90, 180, 70 },
                    type = "line" }
            };

            Session["option"] = JsonConvert.SerializeObject(options);

            return View();

            //new XAxis
            //{
            //    data =new List<string>(){"0","3","6","9","12" }, type= "category",
            //};
            //new YAxis { type = "value" };

            //new Series { data=new List<int>() {1 ,1,1,1}, type= "line" };
            //return View();
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetID(string id)
        {
            Session["Cid"] = id;
            return "";
        }

        /// <summary>
        /// 删除车辆
        /// </summary>
        /// <returns></returns>
        public string DeleteCar()
        {
            if (Session["Cid"] == null) return JsonConvert.SerializeObject(new Msg() { status = 0, message = "删除失败！", action = "" });
            int id = Convert.ToInt32(Session["Cid"]);

            if (OW.BLL.DataManager.DeleteCar(id))
            {
                return JsonConvert.SerializeObject(new Msg() { status = 1, message = "删除成功！", action = "" });
            }

            else
            {
                return JsonConvert.SerializeObject(new Msg() { status = 0, message = "服务器错误！", action = "" });
            }

        }



    }
}