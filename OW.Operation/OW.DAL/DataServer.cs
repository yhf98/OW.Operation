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
    }
}