using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApp.Gateway;
using UniversityApp.Models;

namespace UniversityApp.Manager
{
    public class EmployeeManager
    {
        EmployeeGateway aGateway = new EmployeeGateway();
        public string SaveEmployee(Employee aEmployee)
        {
            if (aEmployee.EmployeeId == "")
            {
                return "Please Enter Employee Id";
            }

            if (aEmployee.EmployeeName == "")
            {

                return "Please Enter Employee Name";
            }

            if (aEmployee.Address == "")
            {

                return "Please Enter Address";
            }

            if (aEmployee.Email == "")
            {
                return "Please Enter Email"; ;
            }

            //if (aEmployee.Age == 0)
            //{
            //    return "Please Enter Age";
            //}

            //if (aEmployee.BasicSalary == 0)
            //{
            //    return "Please Enter Salary";
            //}

            if (aGateway.IsExistEmployeeId(aEmployee.EmployeeId))
            {
                return "This Employee Id is already Exist";
            }

            if (aGateway.IsExistEmail(aEmployee.Email))
            {
                return "This Email is already exist";
            }

            int rowCount = aGateway.SaveEmployee(aEmployee);
            if (rowCount > 0)
            {
                return "Data has been saved successfully";
            }

            return "Data Not Saved!";
        }

        public Employee SearchEmployeebyEmployeeId(string empId)
        {
            return aGateway.SearchEmployeebyEmployeeId(empId);
        }

        public string UpdateEmployee(Employee aEmployee)
        {
            int rowCount = aGateway.UpdateEmployee(aEmployee);
            if(rowCount > 0)
            {
                return "Employee information has been Update";
            }

            return "Update Failed!";
        }

        public string DeleteEmployee(string empId)
        {
            int rowCount = aGateway.DeleteEmployee(empId);
            if(rowCount > 0)
            {
                return "Delete Employee information has been successfully";
            }

            return "Delete Failed!";
        }

        public List<Employee> GetAllEmployees()
        {
            return aGateway.GetAllEmployees();
        }
    }
}