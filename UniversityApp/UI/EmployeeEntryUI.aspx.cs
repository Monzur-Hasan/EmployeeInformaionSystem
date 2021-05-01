using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityApp.Manager;
using UniversityApp.Models;

namespace UniversityApp.UI
{
    public partial class EmployeeEntryUI : System.Web.UI.Page
    {
        EmployeeManager aManager = new EmployeeManager();
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        
        private void ClearAllTextBoxes()
        {
            empIdTextBox.Text = "";
            empNameTextBox.Text = "";
            addressTextBox.Text = "";
            phoneNoTextBox.Text = "";
            emailTextBox.Text = "";
            ageTextBox.Text = "";
            basicSalaryTextBox.Text = "";
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {

            Employee aEmployee = new Employee();

            aEmployee.EmployeeId = empIdTextBox.Text;
            aEmployee.EmployeeName = empNameTextBox.Text;
            aEmployee.Address = addressTextBox.Text;
            aEmployee.PhoneNo = phoneNoTextBox.Text;
            aEmployee.Email = emailTextBox.Text;
            aEmployee.Age = Convert.ToInt32(ageTextBox.Text);
            aEmployee.BasicSalary = Convert.ToDecimal( basicSalaryTextBox.Text);

            string message = aManager.SaveEmployee(aEmployee);
            meassageLabel.Text = message;

            ClearAllTextBoxes();
            
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string empId = empIdTextBox.Text;

            Employee aEmployee = aManager.SearchEmployeebyEmployeeId(empId);
            empIdTextBox.Text = aEmployee.EmployeeId;
            empNameTextBox.Text = aEmployee.EmployeeName;
            addressTextBox.Text = aEmployee.Address;
            phoneNoTextBox.Text = aEmployee.PhoneNo;
            emailTextBox.Text = aEmployee.Email;
            ageTextBox.Text = aEmployee.Age.ToString();
            basicSalaryTextBox.Text = aEmployee.BasicSalary.ToString();

        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            Employee aEmployee = new Employee();

            aEmployee.EmployeeId = empIdTextBox.Text;
            aEmployee.EmployeeName = empNameTextBox.Text;
            aEmployee.Address = addressTextBox.Text;
            aEmployee.PhoneNo = phoneNoTextBox.Text;
            aEmployee.Email = emailTextBox.Text;
            aEmployee.Age = Convert.ToInt32(ageTextBox.Text);
            aEmployee.BasicSalary = Convert.ToDecimal(basicSalaryTextBox.Text);

            meassageLabel.Text = aManager.UpdateEmployee(aEmployee);
            ClearAllTextBoxes();
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            string empId = empIdTextBox.Text;
            meassageLabel.Text = aManager.DeleteEmployee(empId);
            ClearAllTextBoxes();            
        }

        protected void showAllEmployeeButton_Click1(object sender, EventArgs e)
        {
            allEmployeeGridView.DataSource = null;
            allEmployeeGridView.DataSource = aManager.GetAllEmployees();
            allEmployeeGridView.DataBind();
        }

       
    }
}