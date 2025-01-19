using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpManagementSystem
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || string.IsNullOrEmpty(Session["username"].ToString()))
            {
                Response.Redirect("Login01.aspx");
            }
            else
            {
                String username = Session["username"].ToString();
                System.Diagnostics.Debug.WriteLine("Session username: " + Session["username"]);
                if (!IsPostBack)
                {
                    // do something
                }
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                lblResult.Text = "All fields are required.";
                return;
            }

            if (newPassword != confirmPassword)
            {
                lblResult.Text = "New Password and Confirm Password do not match.";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string checkPasswordQuery = "SELECT passwd FROM users WHERE username = @Username AND passwd = @OldPassword";
                string updatePasswordQuery = "UPDATE users SET passwd = @NewPassword WHERE username = @Username";

                try
                {
                    conn.Open();

                    // Check if old password is correct
                    using (SqlCommand checkCommand = new SqlCommand(checkPasswordQuery, conn))
                    {
                        checkCommand.Parameters.AddWithValue("@Username", username);
                        checkCommand.Parameters.AddWithValue("@OldPassword", oldPassword);

                        object result = checkCommand.ExecuteScalar();

                        if (result == null)
                        {
                            lblResult.Text = "Old password is incorrect.";
                            return;
                        }
                    }

                    // Update to new password
                    using (SqlCommand updateCommand = new SqlCommand(updatePasswordQuery, conn))
                    {
                        updateCommand.Parameters.AddWithValue("@Username", username);
                        updateCommand.Parameters.AddWithValue("@NewPassword", newPassword);

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblResult.Text = "Password changed successfully.";
                            lblResult.ForeColor = System.Drawing.Color.Green;

                            // Clear the session
                            Session.Clear();
                            Session.Abandon();

                            // Hide fields
                            txtOldPassword.Visible = false;
                            txtNewPassword.Visible = false;
                            txtConfirmPassword.Visible = false;
                            btnChangePassword.Visible = false;
                            lblOldPassword.Visible = false;
                            lblNewPassword.Visible = false;
                            lblConfirmPassword.Visible = false;

                            // Show "Login Again" link
                            lblResult.Text += " Please log in again.";
                            HyperLink loginLink = new HyperLink
                            {
                                Text = "Login Again",
                                NavigateUrl = "Login01.aspx"
                            };
                            changePasswordFrom.Controls.Add(loginLink);
                        }
                        else
                        {
                            lblResult.Text = "Failed to change password. Please try again.";
                        }
                    }
                }
                catch (SqlException ex)
                {
                    lblResult.Text = $"Database error: {ex.Message}";
                }
                catch (Exception ex)
                {
                    lblResult.Text = $"An unexpected error occurred: {ex.Message}";
                }
            }
        }
    }
}