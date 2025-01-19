using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpManagementSystem
{
    public partial class AdminDash01 : System.Web.UI.Page
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
                }
            }
        }
    }
}