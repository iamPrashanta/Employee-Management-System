using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection.Emit;

namespace EmpManagementSystem
{
    public partial class Register01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_btn_Click(object sender, EventArgs e)
        {
            string roleType = "emp";
            string username = TextBox1.Text.Trim();
            string email = TextBox2.Text.Trim();
            string phone = TextBox3.Text.Trim();
            string address = TextBox4.Text.Trim();
            string password = TextBox5.Text.Trim();
            string confirmPassword = TextBox6.Text.Trim();

            // Check if passwords match
            if (password != confirmPassword)
            {
                ResultLabel.Text = "Passwords do not match.";
                ResultLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            String connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string checkQuery = "SELECT COUNT(*) FROM users WHERE phone = @Phone";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                {
                    conn.Open();
                    checkCommand.Parameters.AddWithValue("@Phone", phone);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        ResultLabel.Text = "Phone number already exists. Please use a different number.";
                        ResultLabel.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                string query = @"INSERT INTO users (role_type, username, email, phone, uaddress, passwd, insert_date, update_date) 
                                 VALUES (@RoleType, @Username, @Email, @Phone, @Uaddress, @Password, GETDATE(), GETDATE())";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@RoleType", roleType);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Uaddress", address);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ResultLabel.Text = "Registration successful.";
                            ResultLabel.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            ResultLabel.Text = "Registration failed. Please try again.";
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