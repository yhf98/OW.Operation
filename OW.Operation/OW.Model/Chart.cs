using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OW.Operation.OW.Model
{
    public class XAxis
    {
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> data { get; set; }
    }

    public class YAxis
    {
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
    }

    public class Series
    {
        /// <summary>
        /// 
        /// </summary>
        public List<int> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public XAxis xAxis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public YAxis yAxis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Series> series { get; set; }
    }

}