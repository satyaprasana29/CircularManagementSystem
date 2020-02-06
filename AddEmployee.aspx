<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="CircularManagementSystem.AddEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="Register" runat="server">
        <div>
            <h1>Employee Registration</h1>
            <table>
                <tr>
                    <td>EmployeeName:</td>
                    <td>
                        <asp:TextBox ID="employeename" type="text" runat="server" name="employeeName"></asp:TextBox></td>
                    <td>
                        <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator" runat="server" ControlToValidate="employeename" ErrorMessage="Enter valid name" Style="color: red" ValidationExpression="[A-Z][a-z-A-Z]+$"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>EmployeePhoneNumber</td>
                    <td>
                        <asp:TextBox ID="employeephoneNumber" type="text" runat="server" name="employeePhone"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Department:</td>
                    <td>
                        <asp:DropDownList ID="departmentList" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Choose Reporting Manager:</td>
                    <td>
                        <asp:DropDownList ID="managerList" runat="server">
                            <asp:ListItem>CEO</asp:ListItem>
                            <asp:ListItem>ProjectManager</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Enter Designation:</td>
                    <td>
                        <asp:TextBox ID="employeeDesignation" runat="server" type="text" name="employeeDesignation"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Enter Email Id:</td>
                    <td>
                        <asp:TextBox ID="emailId" runat="server" type="text" name="employeeMail"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="submitButton" runat="server" OnClick="Submit_Button" value="Submit" Text="Submit" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
