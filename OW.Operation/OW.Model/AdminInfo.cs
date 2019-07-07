using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OW.Operation.OW.Model
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class AdminInfo
    {
        public int AdminID { get; set; }

        public string AdminName { get; set; }

        public string AdminPwd { get; set; }

        public string AdminEmail { get; set; }

    }
}