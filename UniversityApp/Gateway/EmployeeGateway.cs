using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.Models;

namespace UniversityApp.Gateway
{
    public class EmployeeGateway
    {
        ConnectionDB connection = new ConnectionDB();

        public int SaveEmployee(Employee aEmployee)
        {
            int rowCount = 0;
            try
            {
                string query = "insert into tblEmployeeEntry values(@EmpId, @EmpName, @Address,@PhoneNo, @Email, @Age, @BasicSalary)";

                SqlCommand cmd = new SqlCommand(query, connection.GetConnection());

                cmd.Parameters.Clear();      // Parameters query clear()

                //cmd.Parameters.Add("@EmpId", SqlDbType.Char);
                //cmd.Parameters["@EmpId"].Value = aEmployee.EmployeeId;

                cmd.Parameters.AddWithValue("@EmpId", aEmployee.EmployeeId);
                cmd.Parameters.AddWithValue("@EmpName", aEmployee.EmployeeName);
                cmd.Parameters.AddWithValue("@Address", aEmployee.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", aEmployee.PhoneNo);
                cmd.Parameters.AddWithValue("@Email", aEmployee.Email);
                cmd.Parameters.AddWithValue("@Age", aEmployee.Age);
                cmd.Parameters.AddWithValue("@BasicSalary", aEmployee.BasicSalary);

                rowCount = cmd.ExecuteNonQuery();            // count row affected
                connection.GetColse();
            }

            catch
            {
                throw;
            }

            return rowCount;
        }

        public bool IsExistEmployeeId(string empId)                //Check Unique Key Constraint [duplicate]
        {
            string query = "select * from tblEmployeeEntry where EmpId = '" + empId + "'";
            SqlCommand cmd = new SqlCommand(query, connection.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }

        public bool IsExistEmail(string email)
        {
            string query = "select * from tblEmployeeEntry where Email = '" + email + "'";
            SqlCommand cmd = new SqlCommand(query, connection.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }

        public Employee SearchEmployeebyEmployeeId(string empId)
        {
            string query = "select * from tblEmployeeEntry where EmpId = '" + empId + "'";
            SqlCommand cmd = new SqlCommand(query, connection.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();

            Employee aEmployee = new Employee();
            while (reader.Read())
            {
                aEmployee.EmployeeId = reader["EmpId"].ToString();
                aEmployee.EmployeeName = reader["EmpName"].ToString();
                aEmployee.Address = reader["Address"].ToString();
                aEmployee.PhoneNo = reader["PhoneNo"].ToString();
                aEmployee.Email = reader["Email"].ToString();
                aEmployee.Age = (int)reader["Age"];
                aEmployee.BasicSalary = (decimal)reader["BasicSalary"];
            }
            connection.GetColse();
            return aEmployee;
        }

        public int UpdateEmployee(Employee aEmployee)
        {
            string query = "update tblEmployeeEntry set EmpId = '" + aEmployee.EmployeeId + "', EmpName  = '" + aEmployee.EmployeeName + "', Address  = '" + aEmployee.Address + "',PhoneNo  = '" + aEmployee.PhoneNo + "', Email  = '" + aEmployee.Email + "', Age  = '" + aEmployee.Age + "', BasicSalary  = '" + aEmployee.BasicSalary + "' where EmpId = '" + aEmployee.EmployeeId + "'";
            SqlCommand cmd = new SqlCommand(query, connection.GetConnection());

            //cmd.Parameters.Clear();
            //cmd.Parameters.AddWithValue("@EmpId", aEmployee.EmployeeId);
            //cmd.Parameters.AddWithValue("@EmpName", aEmployee.EmployeeName);
            //cmd.Parameters.AddWithValue("@Address", aEmployee.Address);
            //cmd.Parameters.AddWithValue("@PhoneNo", aEmployee.PhoneNo);
            //cmd.Parameters.AddWithValue("@Email", aEmployee.Email);
            //cmd.Parameters.AddWithValue("@Age", aEmployee.Age);
            //cmd.Parameters.AddWithValue("@BasicSalary", aEmployee.BasicSalary);

            int rowCount = cmd.ExecuteNonQuery();

            return rowCount;
        }

        public int DeleteEmployee(string empId)
        {
            string query = "delete from tblEmployeeEntry where EmpId = '" + empId + "'";

            SqlCommand cmd = new SqlCommand(query, connection.GetConnection());
            int rowCount = cmd.ExecuteNonQuery();
            return rowCount;
        }

        public List<Employee> GetAllEmployees()    //Grid View in data
        {
            string query = "select * from tblEmployeeEntry as e inner join tblEmployeeSalary as s on e.EmpId = s.EmpId";
            SqlCommand cmd = new SqlCommand(query, connection.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();

            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                Employee aEmployee = new Employee()
                {
                    EmployeeId = reader["EmpId"].ToString(),
                    EmployeeName = reader["EmpName"].ToString(),
                    Address = reader["Address"].ToString(),
                    PhoneNo = reader["PhoneNo"].ToString(),
                    Email = reader["Email"].ToString(),
                    Age = (int)reader["Age"],
                    BasicSalary = (decimal)reader["BasicSalary"],
                    JoiningDate = reader["JoiningDate"].ToString(),
                    Bonus = (decimal)reader["Bonus"]                   
                };
                employees.Add(aEmployee);
            }

            connection.GetColse();
            return employees;
        }

    }
}