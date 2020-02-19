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

        public bool AddStudent(Student student)
        {
            string query = "INSERT INTO Student VALUES (@StudentID, @StudentFirst, @StudentLast)";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                cmd.Parameters.AddWithValue("@StudentFirst", student.StudentFirst);
                cmd.Parameters.AddWithValue("@StudentLast", student.StudentLast);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected.Equals(1);
            }
        }

        public bool UpdateStudent(Student student)
        {
            string query = "UPDATE Student SET StudentFirst = @first, StudentLast = @last WHERE StudentID = @id";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@first", student.StudentFirst);
                cmd.Parameters.AddWithValue("@last", student.StudentLast);
                cmd.Parameters.AddWithValue("@id", student.StudentID);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected.Equals(1);
            }
        }

        public Student GetStudentById(int studentId)
        {
            string query = "SELECT * FROM Student WHERE StudentID = @id";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", studentId);
                SqlDataReader results = cmd.ExecuteReader();
                if(results.HasRows && results.Read())
                {
                    string studentFirst = results.GetFieldValue<string>(1);
                    string studentLast = results.GetFieldValue<string>(2);
                    Student student = new Student();
                    student.StudentID = studentId;
                    student.StudentFirst = studentFirst;
                    student.StudentLast = studentLast;
                    return student;
                }
            }
            return null;
        }

    }
}