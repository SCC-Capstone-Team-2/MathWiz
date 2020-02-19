using MathWiz.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MathWiz.Data
{
    public class GradeEndpoint
    {

        //adds a grade for an assignment
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

        //can update an assignment grade or change which student it is assigned for
        public static bool UpdateAssignmentGrade(Grade grade)
        {
            string query = "UPDATE Grade SET StudentID = @studentid, Grade = @grade WHERE AssignmentID = @assnid";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentid", grade.StudentID);
                cmd.Parameters.AddWithValue("@grade", grade.AssignmentGrade);
                cmd.Parameters.AddWithValue("@assnid", grade.AssignmentID);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected.Equals(1);
            }
        }

        //returns a list of all assignments for a given student
        public List<Grade> GetGradesForStudent(int StudentID)
        {
            List<Grade> grades = new List<Grade>();
            string query = "SELECT * FROM Grade WHERE StudentID = @id";
            using(SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", StudentID);
                SqlDataReader results = cmd.ExecuteReader();
                if(results.HasRows)
                {
                    while(results.Read())
                    {
                        int AssignmentID = results.GetFieldValue<int>(0);
                        Decimal Grade = results.GetFieldValue<Decimal>(2);
                        Grade grade = new Grade();
                        grade.AssignmentGrade = Grade;
                        grade.AssignmentID = AssignmentID;
                        grade.StudentID = StudentID;
                        grades.Add(grade);
                    }
                }
            }
            return grades;
        }

        //will return a list of student grades for a given assignment
        public static List<Grade> GetGradesForAssignment(int AssignmentID)
        {
            List<Grade> grades = new List<Grade>();
            string query = "SELECT * FROM Grade WHERE AssignmentID = @id";
            using (SqlConnection conn = Database.getInstance())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", AssignmentID);
                SqlDataReader results = cmd.ExecuteReader();
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        int StudentID = results.GetFieldValue<int>(1);
                        Decimal Grade = results.GetFieldValue<Decimal>(2);
                        Grade grade = new Grade();
                        grade.AssignmentGrade = Grade;
                        grade.AssignmentID = AssignmentID;
                        grade.StudentID = StudentID;
                        grades.Add(grade);
                    }
                }
            }
            return grades;
        }

    }
}