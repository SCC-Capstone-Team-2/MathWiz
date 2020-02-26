using MathWiz.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MathWiz.Data
{
    public class ProblemEndpoint
        : APIEndpoint
    {

        public bool AddProblem(int AssignmentID, int ProblemType, string ProblemText, string ProblemAnswer)
        {
            string query = "INSERT INTO Problem (AssignmentID, ProblemType, ProblemText, ProblemAnswer) VALUES (@assnId, @type, @text, @answer)";
            using (SqlConnection DBConnection = new SqlConnection(DBConnectionString))
            {
                DBConnection.Open();
                SqlCommand cmd = new SqlCommand(query, DBConnection);
                cmd.Parameters.AddWithValue("@assnId", AssignmentID);
                cmd.Parameters.AddWithValue("@type", ProblemType);
                cmd.Parameters.AddWithValue("@text", ProblemText);
                cmd.Parameters.AddWithValue("@answer", ProblemAnswer);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected.Equals(1);
            }
        }

        public bool UpdateProblem(Problem problem)
        {
            string query = "UPDATE Problem SET ProblemType = @type, ProblemText = @text, ProblemAnswer = @ans WHERE ProblemID = @id";
            using (SqlConnection DBConnection = new SqlConnection(DBConnectionString))
            {
                DBConnection.Open();
                SqlCommand cmd = new SqlCommand(query, DBConnection);
                cmd.Parameters.AddWithValue("@type", problem.Type);
                cmd.Parameters.AddWithValue("@text", problem.Question);
                cmd.Parameters.AddWithValue("@ans", problem.Answer);
                //TODO: add in the problem id to the model
                cmd.Parameters.AddWithValue("@id", 0);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected.Equals(1);
            }
        }

        public List<Problem> GetProblemsForAssignment(int AssignmentID)
        {
            List<Problem> problems = new List<Problem>();
            string query = "SELECT * FROM Problem WHERE ProblemID = @id";
            using (SqlConnection DBConnection = new SqlConnection(DBConnectionString))
            {
                DBConnection.Open();
                SqlCommand cmd = new SqlCommand(query, DBConnection);
                cmd.Parameters.AddWithValue("@id", AssignmentID);
                SqlDataReader results = cmd.ExecuteReader();
                if(results.HasRows)
                {
                    while(results.Read())
                    {
                        int ProblemID = GetFieldValue<int>(results, 0, true);
                        int ProblemType = GetFieldValue<int>(results, 1, true);
                        string ProblemText = GetFieldValue<string>(results, 2, true);
                        string ProblemAnswer = GetFieldValue<string>(results, 3, true);
                        Problem p = new Problem(ProblemID, AssignmentID, ProblemText, ProblemAnswer, ProblemType);
                        problems.Add(p);
                    }
                }
            }
            return problems;
        }

    }
}