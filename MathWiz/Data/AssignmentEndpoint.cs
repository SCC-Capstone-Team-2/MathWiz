using MathWiz.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MathWiz.Data
{
    public class AssignmentEndpoint
    {

        public static void AddAssignment(Assignment assn)
        {
            string query = "INSERT INTO Assignment VALUES (@AssignmentName, @AssignmentType)";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                //TODO: add in the values for these calls
                cmd.Parameters.AddWithValue("@AssignmentName", "");
                cmd.Parameters.AddWithValue("@AssignmentType", 0);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteAssignment(int assignmentId)
        {
            string query = "DELETE FROM Assignment WHERE @AssignmentID = @id";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", assignmentId);
                cmd.ExecuteNonQuery();
            }
        }

        public static Assignment GetAssignmentById(int assignmentId)
        {
            string query = "SELECT * FROM Assignment WHERE @AssignmentId = @id";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", assignmentId);
                SqlDataReader results = cmd.ExecuteReader();
                if(results.HasRows && results.Read())
                {
                    int AssignmentID = results.GetInt32(0);
                    string AssignmentName = results.GetString(1);
                    int AssignmentType = results.GetInt32(2);
                    //TODO: populate the assignment object and return it
                    return new Assignment();
                } else
                {
                    return null;
                }
            }
        }

    }
}