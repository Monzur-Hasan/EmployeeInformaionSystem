using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.Models;

namespace UniversityApp.Gateway
{
    public class StudentGateway
    {

        ConnectionDB connection = new ConnectionDB();
        public int SaveStudent(Student aStudent)
        {
            int rowCount = 0;

            try
            {
                string query = "INSERT INTO tblStudent VALUES(@StudentName, @RegNo, @Email, @Address, @Department, @PhoneNo)";

                SqlCommand cmd = new SqlCommand(query, connection.GetConnection());

                cmd.Parameters.Clear();      // Parameters query clear()

                //cmd.Parameters.Add("@EmpId", SqlDbType.Char);
                //cmd.Parameters["@EmpId"].Value = aEmployee.EmployeeId;

                cmd.Parameters.AddWithValue("@StudentName", aStudent.StudentName);
                cmd.Parameters.AddWithValue("@RegNo", aStudent.RegNo);
                cmd.Parameters.AddWithValue("@Email", aStudent.Email);
                cmd.Parameters.AddWithValue("@Address", aStudent.Address);
                cmd.Parameters.AddWithValue("@Department", aStudent.Department);
                cmd.Parameters.AddWithValue("@PhoneNo", aStudent.PhoneNo);               

                rowCount = cmd.ExecuteNonQuery();         // count row affected
                connection.GetColse();
            }

            catch (Exception)
            {
                throw;
            }

            return rowCount;
        }

        public bool IsExistRegNo(string regNo)   //Check Unique Key Constraint [duplicate]
        {
            string query = "SELECT * FROM tblStudent WHERE RegNo = '" + regNo + "'";

            SqlCommand cmd = new SqlCommand(query, connection.GetConnection());

            SqlDataReader reader = cmd.ExecuteReader();         //catch row in db
            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }

        public bool ISExistEmail(string email)
        {

            string query = "SELECT * FROM tblStudent WHERE Email = '" + email + "' ";

            SqlCommand sqlCommand = new SqlCommand(query, connection.GetConnection());

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            if (dataReader.HasRows)
            {
                return true;
            }

            return false;

        }

        public List<Student> GetAllStudents()     //Grid View in data
        {
            string query = "SELECT * FROM tblStudent";

            SqlCommand cmd = new SqlCommand(query, connection.GetConnection());

            SqlDataReader reader = cmd.ExecuteReader();         //catch row in db

            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student bStudent = new Student();
                bStudent.StudentId = Convert.ToInt32(reader["StudentId"].ToString());
                bStudent.StudentName = reader["StudentName"].ToString();
                bStudent.RegNo = reader["RegNo"].ToString();
                bStudent.Email = reader["Email"].ToString();
                bStudent.Address = reader["Address"].ToString();
                bStudent.Department = reader["Department"].ToString();
                bStudent.PhoneNo = reader["PhoneNo"].ToString();
                students.Add(bStudent);
            }

            connection.GetColse();
            return students;

        }

        public Student SerachStudentbyRegNo(string regNo)
        {
            

            string query = "SELECT * FROM tblStudent WHERE RegNo = '"+regNo+"'";

            SqlCommand cmd = new SqlCommand(query, connection.GetConnection());

            SqlDataReader reader = cmd.ExecuteReader();         //catch row in db

            Student bStudent = new Student();
            while (reader.Read())
            {
                
                bStudent.StudentId = Convert.ToInt32(reader["StudentId"].ToString());
                bStudent.StudentName = reader["StudentName"].ToString();
                bStudent.RegNo = reader["RegNo"].ToString();
                bStudent.Email = reader["Email"].ToString();
                bStudent.Address = reader["Address"].ToString();
                bStudent.Department = reader["Department"].ToString();
                bStudent.PhoneNo = reader["PhoneNo"].ToString();
            }
            connection.GetColse();
            return bStudent;
        }

        public int DeleteStudent(string regNo)
        {

        //    SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-HIKI7DQ\SQL2019;Initial Catalog=StudentInfo;Persist Security Info=True;User ID=sa;Password=12345");
        //    connection.Open();

            string query = "DELETE FROM tblStudent WHERE RegNo = '"+regNo+"'";

            SqlCommand cmd = new SqlCommand(query, connection.GetConnection());
            int rowCount = cmd.ExecuteNonQuery();
            return rowCount;
        }

        public int UpdateStudent(Student aStudent)
        {
            //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-HIKI7DQ\SQL2019;Initial Catalog=StudentInfo;Persist Security Info=True;User ID=sa;Password=12345");
            //connection.Open();

            string query = "UPDATE tblStudent SET StudentName = '"+aStudent.StudentName+"', RegNo = '"+aStudent.RegNo+"', Email = '"+aStudent.Email+"', Address = '"+aStudent.Address+ "', Department =  '"+aStudent.Department+"' WHERE RegNo = '"+aStudent.RegNo+"' ";

            SqlCommand cmd = new SqlCommand(query, connection.GetConnection());
            int rowCount = cmd.ExecuteNonQuery();
            return rowCount;
        }
    }
}