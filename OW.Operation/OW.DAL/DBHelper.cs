﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace OW.Operation.OW.DAL
{
    /// <summary>
    /// 数据库类
    /// </summary>

    public class DBHelper
    {
        //数据库连接字符串
        private static string Sqlstring = ConfigurationManager.ConnectionStrings["SqlString"].ConnectionString.ToString();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static MySqlDataReader GetReader(string sql)
        {
            MySqlConnection con = new MySqlConnection(Sqlstring);
            con.Open();

            MySqlCommand com = new MySqlCommand(sql,con);

            return com.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sql)
        {
            MySqlConnection con = new MySqlConnection(Sqlstring);
            con.Open();
            DataTable tb = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sql,con);
            da.Fill(tb);
            return tb;
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool GetBoool(string sql)
        {
            MySqlConnection con = new MySqlConnection(Sqlstring);
            con.Open();

            MySqlCommand com = new MySqlCommand(sql, con);
            bool b = com.ExecuteNonQuery() > 0;
            con.Close();
            return b;
        }


    }
}