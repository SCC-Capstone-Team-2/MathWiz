using MathWiz.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MathWiz.Data
{
    public class ProblemEndpoint
    {

        public static bool AddProblem(int AssignmentID, int ProblemType, string ProblemText, string ProblemAnswer)
        {
            string query = "INSERT INTO Problem (AssignmentID, ProblemType, ProblemText, ProblemAnswer) VALUES (@assnId, @type, @text, @answer)";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@assnId", AssignmentID);
                cmd.Parameters.AddWithValue("@type", ProblemType);
                cmd.Parameters.AddWithValue("@text", ProblemText);
                cmd.Parameters.AddWithValue("@answer", ProblemAnswer);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected.Equals(1);
            }
        }

        public static bool UpdateProblem(Problem problem)
        {
            string query = "UPDATE Problem SET ProblemType = @type, ProblemText = @text, ProblemAnswer = @ans WHERE ProblemID = @id";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@type", problem.Type);
                cmd.Parameters.AddWithValue("@text", problem.Question);
                cmd.Parameters.AddWithValue("@ans", problem.Answer);
                //TODO: add in the problem id to the model
                cmd.Parameters.AddWithValue("@id", 0);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected.Equals(1);
            }
        }

        public static List<Problem> GetProblemsForAssignment(int AssignmentID)
        {
            List<Problem> problems = new List<Problem>();
            string query = "SELECT * FROM Problem WHERE ProblemID = @id";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", AssignmentID);
                SqlDataReader results = cmd.ExecuteReader();
                if(results.HasRows)
                {
                    while(results.Read())
                    {
                        //int ProblemID = results.GetFieldValue<int>(0);
                        //int ProblemType = results.GetFieldValue<int>(1);
                        //string ProblemText = results.GetFieldValue<string>(2);
                        //string ProblemAnswer = results.GetFieldValue<string>(3);
                        //Problem p = new Problem(ProblemID, ProblemText, ProblemAnswer, ProblemType);
                        //problems.Add(p);
                    }
                }
            }
            return problems;
        }

    }
}