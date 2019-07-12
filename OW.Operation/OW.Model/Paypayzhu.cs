using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OW.Operation.OW.Model
{
    public class Paypayzhu
    {
        private string ppz_order_id;

        /**
         * 您的自定义订单号
         */
        private string order_id;

        /**
         * 订单定价
         */
        private string price;

        /**
         * 实际支付金额
         */
        private string real_price;

        /**
         * 您的自定义订单信息
         */
        private string order_info;

        private string signature;

        private string type;

        private string redirect;

        public string Ppz_order_id { get => ppz_order_id; set => ppz_order_id = value; }
        public string Order_id { get => order_id; set => order_id = value; }
        public string Price { get => price; set => price = value; }
        public string Real_price { get => real_price; set => real_price = value; }
        public string Order_info { get => order_info; set => order_info = value; }
        public string Signature { get => signature; set => signature = value; }
        public string Type { get => type; set => type = value; }
        public string Redirect { get => redirect; set => redirect = value; }
    }
}