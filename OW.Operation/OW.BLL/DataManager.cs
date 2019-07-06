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
        public static UserInfo GetUser(string name,string pwd)
        {
            UserInfo user = DAL.DataServer.GetUserInfos().Find(F=>F.UserName==name&&F.UserPwd==pwd);
            return user;
        }

    }
}