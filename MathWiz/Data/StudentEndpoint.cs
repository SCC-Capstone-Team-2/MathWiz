using MathWiz.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MathWiz.Data
{
    public class StudentEndpoint
    {

        public void AddStudent(Student student)
        {
            string query = "INSERT INTO Student VALUES (@StudentID, @StudentFirst, @StudentLast)";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                //TODO: add in first and last name
                cmd.Parameters.AddWithValue("@StudentID", student.studentID);
                cmd.Parameters.AddWithValue("@StudentFirst", student.studentName);
                cmd.Parameters.AddWithValue("@StudentLast", student.studentName);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student student)
        {

        }

    }
}