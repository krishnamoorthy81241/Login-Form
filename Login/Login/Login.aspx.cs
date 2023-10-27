using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source = KRISHNA;Initial Catalog = Login_ASP;Integrated Security = True;"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM tblUser WHERE username=@username AND password=@password";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlcmd.Parameters.AddWithValue("@username",txtUserName.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Response.Redirect("Dashboard.aspx");
                }
                else { lblErrorMessage.Visible = true; }
            }
        }
    }
}