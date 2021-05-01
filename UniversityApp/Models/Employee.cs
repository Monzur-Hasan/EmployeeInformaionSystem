using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class Employee
    {
       // public int Id { get; set; }
        public string EmployeeId  { get; set; }
        public string EmployeeName{ get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public decimal BasicSalary { get; set; }
        public string JoiningDate { get; set; }
        public decimal Bonus { get; set; }
    }
}