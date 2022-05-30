using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Npgsql;

namespace Salon_CRM
{
    public partial class Login : System.Web.UI.Page
    {
        DataAccessModule dbAccess = new DataAccessModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Global.user != null)
            {
                Global.user = null;
            }
        }

        protected void Button_login_signup_Click(object sender, EventArgs e)
        {
            NpgsqlConnection dbConn = new NpgsqlConnection(dbAccess.connectionString());
            dbConn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM clients WHERE email = @username AND password = @password;", dbConn);
            cmd.Parameters.AddWithValue("@username", TextBox_login_email.Text.Trim());
            cmd.Parameters.AddWithValue("@password", TextBox_login_password.Text.Trim());
            NpgsqlDataReader dataReader = cmd.ExecuteReader();           

            if (dataReader.HasRows)
            {
                dataReader.Read();                
                Global.user = new User(int.Parse(dataReader.GetValue(0).ToString()), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), int.Parse(dataReader.GetValue(5).ToString()));

                if(Global.user.IsAdmin == 1)
                {
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
                
            }
            else
            {
                Label_login_info.ForeColor = System.Drawing.Color.Red;
                Label_login_info.Text = "Unable to find user, Please try again.";
                Label_login_info.Visible = true;                
            }

            dbConn.Close();
        }
    }
}