using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection.Emit;

namespace EmpManagementSystem
{
    public partial class Login01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            string phone = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id,role_type,username FROM users WHERE phone = @Phone AND passwd = @Password";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                try
                                {
                                    // Attempt to retrieve userId and roleType
                                    string roleType = reader["role_type"].ToString();
                                    string username = reader["username"].ToString();

                                    Session["RoleType"] = roleType;
                                    Session["username"] = username;

                                    ResultLabel.Text = "Login successful. Redirecting...";
                                    ResultLabel.ForeColor = System.Drawing.Color.Green;

                                    // Redirect based on roleType
                                    if (roleType == "emp")
                                    {
                                        Response.Redirect("UserDash01.aspx");
                                    }
                                    else if (roleType == "admin")
                                    {
                                        Response.Redirect("AdminDash01.aspx");
                                    }
                                    else
                                    {
                                        ResultLabel.Text = "Invalid role. Please contact the administrator.";
                                        ResultLabel.ForeColor = System.Drawing.Color.Red;
                                    }
                                }
                                catch (InvalidCastException ex)
                                {
                                    // Handle cases where 'id' or 'roleType' retrieval fails
                                    ResultLabel.Text = $"Error retrieving user data (id/roleType issue): {ex.Message}";
                                    ResultLabel.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            else
                            {
                                ResultLabel.Text = "Invalid phone number or password.";
                                ResultLabel.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        ResultLabel.Text = $"Database error: {ex.Message}";
                        ResultLabel.ForeColor = System.Drawing.Color.Red;
                    }
                    catch (Exception ex)
                    {
                        ResultLabel.Text = $"An unexpected error occurred: {ex.Message}";
                        ResultLabel.ForeColor = System.Drawing.Color.Red;
                    }

                }
            }
        }
    }
}