<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EmpManagementSystem.HomePage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            margin-top: 100px;
        }
        h1 {
            color: #333;
            margin-top:15%;
        }
        .button-container {
            margin-top: 20px;
        }
        .button-container a {
            display: inline-block;
            text-decoration: none;
            padding: 10px 20px;
            margin: 10px;
            background-color: #007BFF;
            color: #fff;
            border-radius: 5px;
            font-size: 16px;
        }
        .button-container a:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <h1>Welcome to the Employee Management System</h1>
    <p>Please select an option below to proceed:</p>
    <div class="button-container">
        <a href="Login01.aspx">Login</a>
        <br />
        <a href="Register01.aspx">Register</a>
    </div>
</body>
</html>