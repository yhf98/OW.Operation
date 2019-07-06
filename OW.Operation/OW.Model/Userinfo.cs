using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OW.Operation.OW.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserPwd { get; set; }

        public string UserSex { get; set; }

        public string UserAddress { get; set; }

        public int UserTypeID { get; set; }
    }
}