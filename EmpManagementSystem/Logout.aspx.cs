using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpManagementSystem
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear the current session
            Session.Clear();

            // Abandon the session to remove all session data
            Session.Abandon();

            // Redirect to the login page after logout
            //Response.Redirect("Login01.aspx");
        }
    }
}