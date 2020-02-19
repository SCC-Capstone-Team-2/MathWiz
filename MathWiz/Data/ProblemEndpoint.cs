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

        public static bool AddProblem(int ProblemType, string ProblemText, string ProblemAnswer)
        {
            string query = "INSERT INTO Problem (ProblemType, ProblemText, ProblemAnswer) VALUES (@type, @text, @answer)";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
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

    }
}