<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register01.aspx.cs" Inherits="EmpManagementSystem.Register01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Registration Form</title>
</head>
<body>
    <form id="register01" runat="server">
        <div>
            <h2>User Registration Form</h2>

            <asp:Label ID="Label1" runat="server" Text="Full Name:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label3" runat="server" Text="Phone Number:"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label4" runat="server" Text="Address:"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label5" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label6" runat="server" Text="Confirm Password:"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />

            <asp:Button ID="register_btn" runat="server" Text="Register" OnClick="register_btn_Click" style="height: 29px" />

            <asp:Label ID="ResultLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </form>
    <div class="button-container">
        <a href="Login01.aspx">Login</a>
    </div>
</body>
</html>
