using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MathWiz
{
    public class Database
    {


        private static SqlConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        private Database()
        {

        }

        public static SqlConnection getInstance()
        {
            return _db;
        }

    }
}