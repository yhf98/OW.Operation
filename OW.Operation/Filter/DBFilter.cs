using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace OW.Operation.Filter
{

    public class DBFilter:ActionFilterAttribute
    {
        public string Database { get; set; }
    }
}