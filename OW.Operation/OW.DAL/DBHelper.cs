using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace OW.Operation.OW.DAL
{
    public class DBHelper
    {
        private static string Sqlstring = ConfigurationManager.ConnectionStrings["SqlString"].ConnectionString.ToString();
    }
}