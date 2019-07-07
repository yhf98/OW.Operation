using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OW.Operation.OW.Model
{
    /// <summary>
    /// 车辆信息表
    /// </summary>
    public class CarsInfo:CarTypeInfo
    {
        public int CarID { get; set; }

        public string License { get; set; }
        
        public string Brand { get; set; }

        public string Color { get; set; }
        
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserPwd { get; set; }

        public string UserSex { get; set; }

        public string UserAddress { get; set; }

        public int UserTypeID { get; set; }

        public string Usersfz { get; set; }

        public string UserPhone { get; set; }

    }
}