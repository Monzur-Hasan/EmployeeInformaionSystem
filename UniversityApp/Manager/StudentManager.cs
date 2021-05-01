using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApp.Gateway;
using UniversityApp.Models;

namespace UniversityApp.Manager
{
    public class StudentManager
    {
        StudentGateway aGateway = new StudentGateway();

        public string SaveStudent(Student aStudent)
        {
            if (aStudent.StudentName == "")
            {
                return "Please enter name";
            }

            if (aStudent.RegNo == "")
            {
                return "Please enter registration number";
            }

            if (aStudent.Email == "")
            {
                return "Please enter your email address";
            }

            if (aStudent.Address == "")
            {
                return "Please enter your address";
            }

            if (aStudent.Department == "")
            {
                return "Please enter department name";
            }

            if (aGateway.IsExistRegNo(aStudent.RegNo))
            {
                return "This Registration Number is already exist";
            }

            if (aGateway.ISExistEmail(aStudent.Email))
            {
                return "This Email number is already exist";
            }

            int rowCount = aGateway.SaveStudent(aStudent);

            if (rowCount > 0)
            {
                return "Data has been saved successfully";
            }

            return "Not Saved";
        }

        public List<Student> GetAllStudentsInfo()
        {
            return aGateway.GetAllStudents();
        }

        public Student SerachStudentbyRegNo(string regNo)
        {
           
            return aGateway.SerachStudentbyRegNo(regNo);
        }

        public string DeleteStudent(string regNo)
        {
            int rowCount = aGateway.DeleteStudent(regNo);
            if(rowCount > 0)
            {
                return "Delete student information has been successfully";
            }

            return "Delete Failed!";
        }

        public string UpdateStudent(Student aStudent)
        {
            int rowCount = aGateway.UpdateStudent(aStudent);
            if(rowCount > 0)
            {
                return "Student information has been Update";
            }
            return "Updated Failed!";
        }
    }
}