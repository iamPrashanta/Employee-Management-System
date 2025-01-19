<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDash01.aspx.cs" Inherits="EmpManagementSystem.AdminDash01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="adminDashboardForm" runat="server">
        <h2><asp:Label ID="lblWelcome" runat="server" Text=""></asp:Label></h2>

        <div class="button-container">
            <a href="ChangePassword.aspx">Change Password</a>
            <br />
            <a href="Logout.aspx">Logout</a>
        </div>
    </form>
</body>
</html>
