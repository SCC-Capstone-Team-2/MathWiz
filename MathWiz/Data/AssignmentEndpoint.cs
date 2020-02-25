using MathWiz.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MathWiz.Data
{
    public class AssignmentEndpoint
        : APIEndpoint
    {

        public int AddAssignment(Assignment assn)
        {
            string query = "INSERT INTO Assignment(AssignmentName, AssignmentType) VALUES (@AssignmentName, @AssignmentType); SELECT SCOPE_IDENTITY();";
            using (SqlConnection DBConnection = new SqlConnection(DBConnectionString))
            {
                DBConnection.Open();
                SqlCommand cmd = new SqlCommand(query, DBConnection);
                //TODO: add in the values for these calls
                cmd.Parameters.AddWithValue("@AssignmentName", assn.Name);
                cmd.Parameters.AddWithValue("@AssignmentType", assn.Type);
                SqlDataReader result = cmd.ExecuteReader();
                if(result.HasRows && result.Read())
                {
                    Decimal resVal = result.GetFieldValue<Decimal>(0);
                    return int.Parse(resVal.ToString());
                }
            }
            return 0;
        }

        public void DeleteAssignment(int assignmentId)
        {
            string query = "DELETE FROM Assignment WHERE AssignmentID = @id";
            using (SqlConnection DBConnection = new SqlConnection(DBConnectionString))
            {
                DBConnection.Open();
                SqlCommand cmd = new SqlCommand(query, DBConnection);
                cmd.Parameters.AddWithValue("@id", assignmentId);
                cmd.ExecuteNonQuery();
            }
        }

        public Assignment GetAssignmentById(int assignmentId)
        {
            string query = "SELECT * FROM Assignment WHERE AssignmentId = @id";
            using (SqlConnection DBConnection = new SqlConnection(DBConnectionString))
            {
                DBConnection.Open();
                SqlCommand cmd = new SqlCommand(query, DBConnection);
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

        public List<Assignment> GetAllAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();
            string query = "SELECT * FROM Assignment";
            using (SqlConnection DBConnection = new SqlConnection(DBConnectionString))
            {
                DBConnection.Open();
                SqlCommand cmd = new SqlCommand(query, DBConnection);
                SqlDataReader results = cmd.ExecuteReader();
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        int AssignmentId = GetFieldValue<int>(results, 0, true);
                        string AssignmentName = GetFieldValue<string>(results, 1, true);
                        int AssignmentType = GetFieldValue<int>(results, 2, true);
                        DateTime startTimestamp = GetFieldValue<DateTime>(results, 3);
                        DateTime endTimestamp = GetFieldValue<DateTime>(results, 4);
                        DateTime dueBy = GetFieldValue<DateTime>(results, 5);
                        //TODO: add in other db fields to the assignment model
                        Assignment assn = new Assignment(AssignmentId, AssignmentName, AssignmentType, dueBy);
                        assignments.Add(assn);
                    }
                }
            }
            return assignments;
        }

    }
}