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
    public partial class UserDash01 : System.Web.UI.Page
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
                    lblWelcome.Text = $"Welcome, {username}!";
                    LoadAssignedProject(username);
                }
            }
        }

        private void LoadAssignedProject(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT p.project_name, p.project_details
                    FROM assign_project ap
                    INNER JOIN projects p ON ap.project_id = p.id
                    INNER JOIN users u ON ap.user_id = u.id
                    WHERE u.username = @UserName";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Use the correct parameter name
                    command.Parameters.AddWithValue("@UserName", username);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Clear existing text before appending new content
                            lblProjects.Text = "";

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string projectName = reader["project_name"].ToString();
                                    string projectDetails = reader["project_details"].ToString();

                                    // Append project information to the label
                                    lblProjects.Text += $"<b>{projectName}</b>: {projectDetails}<br />";
                                }
                            }
                            else
                            {
                                lblProjects.Text = "No projects are assigned yet.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lblProjects.Text = "Error loading assigned projects.";
                        System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }


    }
}