using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MathWiz.Data
{
    public abstract class APIEndpoint
    {

        public string DBConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }

        public T GetFieldValue<T>(SqlDataReader reader, int index, bool throwErrorIfNull = false)
        {
            if(reader.IsDBNull(index))
            {
                if(throwErrorIfNull)
                {
                    throw new Exception($"The value in column {index} cannot be null");
                }
                return default;
            } else
            {
                return (T)reader.GetValue(index);
            }
        }

    }
}