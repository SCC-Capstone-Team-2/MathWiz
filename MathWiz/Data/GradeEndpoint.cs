using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MathWiz.Data
{
    public class GradeEndpoint
    {

        public static bool AddGradeForAssignment(int AssignmentID, int StudentID, Decimal grade)
        {
            string query = "INSERT INTO Grade VALUES (@AssignmentID, @StudentID, @Grade)";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AssignmentID", AssignmentID);
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
                cmd.Parameters.AddWithValue("@Grade", grade);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected.Equals(1);
            }
        }

    }
}