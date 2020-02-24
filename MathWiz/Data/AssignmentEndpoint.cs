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

        public static int AddAssignment(Assignment assn)
        {
            string query = "INSERT INTO Assignment VALUES (@AssignmentName, @AssignmentType); SELECT SCOPE_IDENTITY();";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                //TODO: add in the values for these calls
                cmd.Parameters.AddWithValue("@AssignmentName", assn.Name);
                cmd.Parameters.AddWithValue("@AssignmentType", assn.Type);
                SqlDataReader result = cmd.ExecuteReader();
                return result.GetInt32(0);
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
                    return new Assignment(AssignmentName, AssignmentID, AssignmentType);
                } else
                {
                    return null;
                }
            }
        }

        public static List<Assignment> GetAllAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();
            //string query = "SELECT * FROM Assignment";
            //using(SqlConnection conn = Database.getInstance())
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    SqlDataReader results = cmd.ExecuteReader();
            //    if(results.HasRows)
            //    {
            //        while(results.Read())
            //        {
            //            int AssignmentId = results.GetInt32(0);
            //            string AssignmentName = results.GetString(1);
            //            int AssignmentType = results.GetInt32(2);
            //            DateTime startTimestamp = results.GetDateTime(3);
            //            DateTime endTimestamp = results.GetDateTime(4);
            //            DateTime dueBy = results.GetDateTime(5);
            //            //TODO: add in other db fields to the assignment model
            //            //Assignment assn = new Assignment(AssignmentName, AssignmentType, dueBy);
            //            //assignments.Add(assn);
            //        }
            //    }
            //}
            return assignments;
        }

    }
}