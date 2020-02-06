<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Login.aspx.cs" Inherits="CircularManagementSystem.Login" %>

<asp:Content ID="loginHead" runat="server" ContentPlaceHolderID="head"></asp:Content>
<asp:Content ID="contentHeader" runat="server" ContentPlaceHolderID="ContentLogin" runtat="server">
    <h1>Employee Login:</h1>
    <table>
        <tr>
            <td>User name: </td>
            <td>
                <asp:TextBox ID="UserId" type="text" runat="server" name="username" /></td>
        </tr>
        <tr>
            <td>Password: </td>
            <td>
                <asp:TextBox ID="Password" type="password" runat="server" name="password" /></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Submit" value="submit" runat="server" OnClick="Submit_Click" Text="Submit" /></td>
        </tr>
    </table>
</asp:Content>
