using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityApp.Manager;
using UniversityApp.Models;

namespace UniversityApp
{
    public partial class StudentUI : System.Web.UI.Page
    {
        StudentManager aManager = new StudentManager();

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
              

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string regNo = regNoTextBox.Text;
            Student aStudent = aManager.SerachStudentbyRegNo(regNo);
            studentNameTextBox.Text = aStudent.StudentName;
            regNoTextBox.Text = aStudent.RegNo;
            emailTextBox.Text = aStudent.Email;
            addressTextBox.Text = aStudent.Address;
            departmentTextBox.Text = aStudent.Department;
            phoneNoTextBox.Text = aStudent.PhoneNo;

        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            string regNo = regNoTextBox.Text;
            messageLabel.Text = aManager.DeleteStudent(regNo);
            ClearAllTextBoxes();
        }

        private void ClearAllTextBoxes()
        {
            regNoTextBox.Text = "";
            studentNameTextBox.Text = "";
            emailTextBox.Text = "";
            addressTextBox.Text = "";
            departmentTextBox.Text = "";
            phoneNoTextBox.Text = "";
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            Student aStudent = new Student();
            aStudent.StudentName = studentNameTextBox.Text;
            aStudent.RegNo = regNoTextBox.Text;
            aStudent.Email = emailTextBox.Text;
            aStudent.Address = addressTextBox.Text;
            aStudent.Department = departmentTextBox.Text;
            aStudent.PhoneNo = phoneNoTextBox.Text;
            messageLabel.Text = aManager.UpdateStudent(aStudent);
            ClearAllTextBoxes();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Student aStudent = new Student();
            aStudent.StudentName = studentNameTextBox.Text;
            aStudent.RegNo = regNoTextBox.Text;
            aStudent.Email = emailTextBox.Text;
            aStudent.Address = addressTextBox.Text;
            aStudent.Department = departmentTextBox.Text;
            aStudent.PhoneNo = phoneNoTextBox.Text;
            string message = aManager.SaveStudent(aStudent);
            messageLabel.Text = message;
            ClearAllTextBoxes();
        }
    }
}