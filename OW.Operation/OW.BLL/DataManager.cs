using OW.Operation.OW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OW.Operation.OW.BLL
{
    public class DataManager
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        /// <returns></returns>
        public static List<UserInfo> GetUserInfos()
        {
            return DAL.DataServer.GetUserInfos();
        }

        /// <summary>
        /// 获取单个用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static UserInfo GetUser(string name, string pwd)
        {
            UserInfo user = DAL.DataServer.GetUserInfos().Find(F => F.UserName == name && F.UserPwd == pwd);
            return user;
        }

        /// <summary>
        /// 获取车辆信息
        /// </summary>
        /// <returns></returns>
        public static List<CarsInfo> GetCars()
        {
            return DAL.DataServer.GetCars();
        }

        /// <summary>
        /// 查询某一类车辆
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<CarsInfo> GetCarsByType(int type)
        {
            List<CarsInfo> list = DAL.DataServer.GetCars(type);

            return list;
        }

        /// <summary>
        /// 车位查询
        /// </summary>
        /// <returns></returns>
        public static int GetParkingInfos()
        {
            return DAL.DataServer.GetParkingInfos();
        }

        /// <summary>
        /// 车辆入最新驻信息
        /// </summary>
        /// <returns></returns>
        public static List<CarSettledInfo> GetCarSettled()
        {
            return DAL.DataServer.GetCarSettled();
        }

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static AdminInfo GetAdmin(string name,string pwd)
        {
            return DAL.DataServer.GetAdmin().Find(F=>F.AdminName==name&&F.AdminPwd==pwd ); ;
        }

        /// <summary>
        /// 删除车辆
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteCar(int id)
        {
            return DAL.DataServer.DeleteCar(id);
        }

     } 
}