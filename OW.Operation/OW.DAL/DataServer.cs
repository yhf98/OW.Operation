using OW.Operation.OW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace OW.Operation.OW.DAL
{
    public class DataServer
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public static List<UserInfo> GetUserInfos()
        {
            string sql = "select UserID,UserName,UserPwd,UserSex,UserAddress,UserTypeID from t_Users";
            List<UserInfo> list = new List<UserInfo>();

            using(MySqlDataReader dr = DBHelper.GetReader(sql))
            {
                while (dr.Read())
                {
                    UserInfo info = new UserInfo();
                    info.UserID = Convert.ToInt32(dr["UserID"]);
                    info.UserName = Convert.ToString(dr["UserName"]);
                    info.UserPwd = Convert.ToString(dr["UserPwd"]);
                    info.UserSex = Convert.ToString(dr["UserSex"]);
                    info.UserAddress = Convert.ToString(dr["UserAddress"]);
                    info.UserTypeID = Convert.ToInt32(dr["UserTypeID"]);
                    list.Add(info);
                }
            }

            return list;

        }

        /// <summary>
        /// 车辆信息查询
        /// </summary>
        /// <returns></returns>
        public static List<CarsInfo> GetCars(int type)
        {
            string sql = "SELECT c.CarID,c.License,c.Brand,c.Color,t.CarType,c.UserID,u.UserName,u.UserPhone,u.Usersfz,u.UserSex FROM t_Cars c,CarType t,t_Users u WHERE c.CarTypeID = t.CarTypeID and u.UserID = c.UserID and t.CarTypeID="+type+"";

            List<CarsInfo> list = new List<CarsInfo>();

            using (MySqlDataReader dr = DBHelper.GetReader(sql))
            {
                while (dr.Read())
                {
                    CarsInfo info = new CarsInfo();
                    info.CarID = Convert.ToInt32(dr["CarID"]);
                    info.License = Convert.ToString(dr["License"]);
                    info.Brand = Convert.ToString(dr["Brand"]);
                    info.Color = Convert.ToString(dr["Color"]);
                    info.CarType = Convert.ToString(dr["CarType"]);
                    info.UserID = Convert.ToInt32(dr["UserID"]);
                    info.UserName = Convert.ToString(dr["UserName"]);
                    info.UserPhone = Convert.ToString(dr["UserPhone"]);
                    info.Usersfz = Convert.ToString(dr["Usersfz"]);
                    info.UserSex = Convert.ToString(dr["UserSex"]);

                    list.Add(info);
                }
            }
            return list;
        }

        public static List<CarsInfo> GetCars()
        {
            string sql = "SELECT c.CarID,c.License,c.Brand,c.Color,t.CarType,c.UserID,u.UserName,u.UserPhone,u.Usersfz,u.UserSex FROM t_Cars c,CarType t,t_Users u WHERE c.CarTypeID = t.CarTypeID and u.UserID = c.UserID";

            List<CarsInfo> list = new List<CarsInfo>();

            using (MySqlDataReader dr = DBHelper.GetReader(sql))
            {
                while (dr.Read())
                {
                    CarsInfo info = new CarsInfo();
                    info.CarID = Convert.ToInt32(dr["CarID"]);
                    info.License = Convert.ToString(dr["License"]);
                    info.Brand = Convert.ToString(dr["Brand"]);
                    info.Color = Convert.ToString(dr["Color"]);
                    info.CarType = Convert.ToString(dr["CarType"]);
                    info.UserID = Convert.ToInt32(dr["UserID"]);
                    info.UserName = Convert.ToString(dr["UserName"]);
                    info.UserPhone = Convert.ToString(dr["UserPhone"]);
                    info.Usersfz = Convert.ToString(dr["Usersfz"]);
                    info.UserSex = Convert.ToString(dr["UserSex"]);

                    list.Add(info);
                }
            }
            return list;
        }

        /// <summary>
        /// 车位查询
        /// </summary>
        /// <returns></returns>
        public static int GetParkingInfos()
        {
            string sql = "SELECT COUNT(*) FROM t_CarSettled ";
            using (MySqlDataReader dr = DBHelper.GetReader(sql))
            {
                if (dr.Read())
                {
                    return 50-Convert.ToInt32(dr[0]);
                }
                return 0;
            }
        }

        /// <summary>
        /// 车辆入最新驻信息
        /// </summary>
        /// <returns></returns>
        public static List<CarSettledInfo> GetCarSettled()
        {
            string sql = "SELECT* FROM t_CarSettled d,t_Cars c where d.CarID=c.CarID  ORDER BY c.CarID DESC limit 0,5";
            List<CarSettledInfo> list = new List<CarSettledInfo>();

            using (MySqlDataReader dr = DBHelper.GetReader(sql))
            {
                while(dr.Read())
                {
                    CarSettledInfo info = new CarSettledInfo();

                    info.SettleID = Convert.ToInt32(dr["SettleID"]);
                    info.SettledDate = Convert.ToString(dr["SettledDate"]);
                    info.License = Convert.ToString(dr["License"]);
                    info.Brand = Convert.ToString(dr["Brand"]);
                    info.Color = Convert.ToString(dr["Color"]);
                    info.Color = Convert.ToString(dr["Color"]);
                    list.Add(info);
                    
                }

                return list;

            }

        }


        /// <summary>
        /// 车辆信息
        /// </summary>
        /// <returns></returns>
        public static List<CarSettledInfo> GetCarSettledList()
        {
            string sql = "SELECT* FROM t_CarSettled d,t_Cars c where d.CarID=c.CarID  ORDER BY c.CarID DESC";
            List<CarSettledInfo> list = new List<CarSettledInfo>();

            using (MySqlDataReader dr = DBHelper.GetReader(sql))
            {
                while (dr.Read())
                {
                    CarSettledInfo info = new CarSettledInfo();

                    info.SettleID = Convert.ToInt32(dr["SettleID"]);
                    info.SettledDate = Convert.ToString(dr["SettledDate"]);
                    info.License = Convert.ToString(dr["License"]);
                    info.Brand = Convert.ToString(dr["Brand"]);
                    info.Color = Convert.ToString(dr["Color"]);
                    info.Color = Convert.ToString(dr["Color"]);
                    list.Add(info);

                }

                return list;

            }

        }


        /// <summary>
        /// 查询输入数据
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<string> GetIncomeData(int type,out List<int> value)
        {
            string sql = "";  
            List<string> key = new List<string>();
            value = new List<int>();
            if (type == 0)
            {
                 sql = "select DATE_FORMAT(Date,'%Y年%m月%d日') days,SUM(price) count from t_Income group by days;";
            }
            else if(type==1)
            {
                sql = "select DATE_FORMAT(Date,'%Y年%m月') months,SUM(price) count from t_Income group by months;";
            }
            else
            {
                sql = "select DATE_FORMAT(Date,'%Y年') years,SUM(price) count from t_Income group by years;";
            }

            MySqlDataReader dr = DBHelper.GetReader(sql);
            while (dr.Read())
            {
                key.Add(Convert.ToString(dr[0]));
                value.Add(Convert.ToInt32(dr[1]));
            }

            return key;
        } 











        /// <summary>
        /// 管理员表
        /// </summary>
        /// <returns></returns>
        public static List<AdminInfo> GetAdmin()
        {
            string sql = "SELECT * FROM t_Admin";
            List<AdminInfo> list = new List<AdminInfo>();

            using (MySqlDataReader dr = DBHelper.GetReader(sql))
            {
                while (dr.Read())
                {
                    AdminInfo info = new AdminInfo();

                    info.AdminID = Convert.ToInt32(dr["AdminID"]);
                    info.AdminName = Convert.ToString(dr["AdminName"]);
                    info.AdminPwd = Convert.ToString(dr["AdminPwd"]);
                    info.AdminEmail = Convert.ToString(dr["AdminEmail"]);
                    list.Add(info);
                }

                return list;

            }

        }

        /// <summary>
        ///  删除车辆
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteCar(int id)
        {
            string sql = "DELETE FROM t_Cars WHERE CarID="+id+"";
            return DBHelper.GetBoool(sql);
        }


    }
}