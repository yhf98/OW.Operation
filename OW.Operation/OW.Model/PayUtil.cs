using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OW.Operation.OW.Model
{
    public class PayUtil
    {
        public static string REDIRECT_URL = "/Home/Index";

        public static string API_USER = "cd9b9095";

        public static string API_KEY = "326bcc21-9861-45c1-990a-669dab5cdc41";

        public static Dictionary<string, string> payOrder(Dictionary<string, string> remoteMap)
        {
            Dictionary<string, string> paramMap = new Dictionary<string, string>();
            paramMap = remoteMap;

            paramMap.Add("redirect", REDIRECT_URL);
            paramMap.Add("api_user", API_USER);

            string signature = getSignature(API_USER, paramMap);

            paramMap.Add("signature", signature);

            return paramMap;
        }

        public static string getSignature(string api_user, Dictionary<string, string> treeMap)
        {
            string signStr = API_KEY;
            foreach (String value in treeMap.Values)
            {

                signStr = signStr + value;

            }
            getMd5Hash(signStr);

            return getMd5Hash(signStr);

        }




        public static string getOrderIdByUUId()
        {
            int machineId = 1;
            // int hashCodeV = UUID.randomUUID().toString().hashCode();
            string id = System.Guid.NewGuid().ToString("N");
            //if (hashCodeV < 0)
            //{// 有可能是负数
            //    hashCodeV = -hashCodeV;
            //}
            //  0 代表前面补充0;d 代表参数为正数型
            return machineId + id;
        }


        public static bool checkPayKey(Paypayzhu paypayzhu)
        {
            Dictionary<string, string> treeMap = new Dictionary<string, string>();
            if (!isBlank(paypayzhu.Ppz_order_id))
            {
                treeMap.Add("ppz_order_id", paypayzhu.Ppz_order_id);
                //System.out.println("支付回来的平台订单号：" + paypayzhu.getPpz_order_id());
            }
            if (!isBlank(paypayzhu.Order_id))
            {
                treeMap.Add("order_id", paypayzhu.Order_id);
                //System.out.println("支付回来的订单号：" + paypayzhu.getOrder_id());
            }
            if (!isBlank(paypayzhu.Price))
            {
                treeMap.Add("price", paypayzhu.Price.ToString());
                //System.out.println("支付回来的价格：" + paypayzhu.getPrice());
            }
            if (!isBlank(paypayzhu.Real_price))
            {
                treeMap.Add("real_price", paypayzhu.Real_price.ToString());
                //System.out.println("支付回来的真实价格：" + paypayzhu.getReal_price());
            }
            if (!isBlank(paypayzhu.Order_info))
            {
                treeMap.Add("order_info", paypayzhu.Order_info);
                //System.out.println("支付回来的订单信息：" + paypayzhu.getOrder_info());
            }

            string signStr = API_KEY;
            foreach (string value in treeMap.Values)
            {
                signStr = signStr + value;
            }
            string signMd5 = getMd5Hash(signStr);
            //System.out.println("我们自己拼接的签名：" + signMd5);
            return paypayzhu.Signature.Equals(signMd5);
        }

        public static bool isBlank(string str)
        {
            return str == null || str.Trim().Length == 0;
        }

        /**
         * 判断字符串是否为空
         * @param charSequence
         * @return
         */
        public static bool isEmpty(string charSequence)
        {
            return charSequence == null || charSequence.Length == 0;
        }


        public static string getMd5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            // Convert the input string to a byte array and compute the hash.
            char[] temp = input.ToCharArray();
            byte[] buf = new byte[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                buf[i] = (byte)temp[i];
            }
            byte[] data = md5Hasher.ComputeHash(buf);
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;//创建请求对象
            request.Method = "POST";//请求方式
            request.ContentType = "application/x-www-form-urlencoded";//链接类型
                                                                      //构造查询字符串
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                bool first = true;
                foreach (string key in parameters.Keys)
                {

                    if (!first)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        first = false;
                    }
                }
                byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
                //写入请求流
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }

        /// <summary>
        /// 从HttpWebResponse对象中提取响应的数据转换为字符串
        /// </summary>
        /// <param name="webresponse"></param>
        /// <returns></returns>
        public static string GetResponseString(HttpWebResponse webresponse)
        {
            using (Stream s = webresponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
    }
}