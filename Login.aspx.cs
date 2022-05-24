using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Salon_CRM
{
    public partial class Login : System.Web.UI.Page
    {
        DataAccessModule dbAccess = new DataAccessModule();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_login_signup_Click(object sender, EventArgs e)
        {
            DataTable dt = dbAccess.getUser(TextBox_login_email.Text, TextBox_login_password.Text);

            if(dt == null)
            {
                Label_login_info.BackColor = System.Drawing.Color.Red;
                Label_login_info.Text = "Unable to find user, Please try again.";
                Label_login_info.Visible = true;
            }
            else
            {

            }
        }
    }
}