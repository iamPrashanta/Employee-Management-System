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
                string query = "SELECT COUNT(*) FROM users WHERE phone = @Phone AND passwd = @Password";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        conn.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            ResultLabel.Text = "Login successful. Redirecting...";
                            ResultLabel.ForeColor = System.Drawing.Color.Green;

                            // Redirect to a home page or dashboard
                            Response.Redirect("UserDash01.aspx");
                        }
                        else
                        {
                            ResultLabel.Text = "Invalid phone number or password.";
                            ResultLabel.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {
                        ResultLabel.Text = "Error: " + ex.Message;
                        ResultLabel.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}