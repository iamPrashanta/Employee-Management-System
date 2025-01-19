<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDash01.aspx.cs" Inherits="EmpManagementSystem.UserDash01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Dashboard</title>
</head>
<body>
    <form id="userDashboardForm" runat="server">
        <h2><asp:Label ID="lblWelcome" runat="server" Text=""></asp:Label></h2>

        <!-- Assigned Project Section -->
        <h3>Your Assigned Project:</h3>
        <asp:Label ID="lblProjects" runat="server" Text=""></asp:Label>
        <br />

        <div class="button-container">
            <a href="ChangePassword.aspx">Change Password</a>
            <br />
            <a href="Logout.aspx">Logout</a>
        </div>
    </form>
</body>
</html>
