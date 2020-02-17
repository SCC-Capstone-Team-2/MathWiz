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

        private static SqlConnection _db;

        static Database()
        {
            string connectionString = ConfigurationManager.AppSettings["DatabaseConnection"];
            _db = new SqlConnection(connectionString);
        }

        public static SqlConnection getInstance()
        {
            if(_db == null)
            {
                new Database();
            }
            return _db;
        }

    }
}