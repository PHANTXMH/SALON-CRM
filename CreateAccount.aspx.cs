using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salon_CRM
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        DataAccessModule dbAccess = new DataAccessModule();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_signup_Click(object sender, EventArgs e)
        {
            if((TextBox_createaccount_firstname.Text == "") || (TextBox_createaccount_lastname.Text == "") ||
                (TextBox_createaccount_email.Text == "") || (TextBox_createaccount_password.Text == ""))
            {
                Label_createaccount_info.Text = "Please enter all required fields.";
                Label_createaccount_info.Visible = true;
            }
            else
            {
                dbAccess.addNewUser(TextBox_createaccount_firstname.Text.Trim(), TextBox_createaccount_lastname.Text.Trim(),
                TextBox_createaccount_email.Text.Trim(), TextBox_createaccount_password.Text.Trim());
                Response.Redirect("Default.aspx");
            }            
        }
    }
}