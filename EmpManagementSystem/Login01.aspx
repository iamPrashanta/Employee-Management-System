<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login01.aspx.cs" Inherits="EmpManagementSystem.Login01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="login01" runat="server">
        <div>
            <h2>User Login</h2>

            <asp:Label ID="Label1" runat="server" Text="Phone Number:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />

            <asp:Button ID="login_btn" runat="server" Text="Login" OnClick="login_btn_Click" style="height: 29px" />

            <asp:Label ID="ResultLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </form>

    <div class="button-container">
        <a href="Register01.aspx">Register</a>
    </div>

</body>
</html>
