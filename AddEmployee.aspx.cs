using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace CircularManagementSystem
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        EmployeeRepository employee = new EmployeeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListData();
            }
        }
        protected void BindListData()
        {

            SortedList<int, string> temp = new SortedList<int, string>(employee.GetDepartment());
            foreach (KeyValuePair<int, string> keyValuePair in temp)
            {
                ListItem listItem = new ListItem(keyValuePair.Key + " " + keyValuePair.Value);
                departmentList.Items.Add(listItem);
            }
        }

        protected void Submit_Button(object sender, EventArgs e)
        {
            string name = employeename.Text;
            string phoneNumber = employeephoneNumber.Text;
            string email = emailId.Text;
            string password = name.Substring(0, 1) + phoneNumber.Substring(0, 1) + name.Substring(name.Length - 1) + phoneNumber.Substring(phoneNumber.Length - 1) + phoneNumber.Substring(5, 1);
            int department = Convert.ToInt32(Convert.ToString(departmentList.SelectedItem.Value).Substring(0, 1));
            int managerId = 0;
            if (Convert.ToString(managerList.SelectedItem.Value) == "CEO")
                managerId = 1;
            else if (Convert.ToString(managerList.SelectedItem.Value) == "ProjectManager")
                managerId = 2;
            string designation = employeeDesignation.Text;
            if (employee.AddEmployees(name, phoneNumber, department, managerId, designation) == 1)
            {
                if (employee.AddLogin(email, password, name, phoneNumber, managerId) == 1)
                {
                    Response.Write("Employee Added successfully");
                }
            }

        }
    }
}