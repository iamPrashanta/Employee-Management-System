<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="EmpManagementSystem.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
</head>
<body>
    <form id="changePasswordFrom" runat="server">
        <div>
            <h2>Change Password</h2>

            <asp:Label ID="lblOldPassword" runat="server" Text="Old Password:"></asp:Label>
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />

            <asp:Label ID="lblNewPassword" runat="server" Text="New Password:"></asp:Label>
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />

            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />

            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
            <br /><br />

            <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
