using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salon_CRM
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Global.user == null)
            {
                Label_signin.Text = "Sign In";
                Label_navbar_accountname.Visible = false;
                Label_navbar_dashboard.Visible = false;
            }
            else
            {
                if(Global.user.IsAdmin == 1)
                {
                    Label_navbar_dashboard.Visible = true;
                    Label_signin.Text = "Log Out";
                    Label_navbar_accountname.Visible = true;
                    Label_navbar_accountname.Text = "Hi admin";
                }
                else
                {
                    Label_navbar_accountname.Text = "Hi, " + Global.user.Fname+"!";
                    Label_signin.Text = "Log Out";
                    Label_navbar_accountname.Visible = true;
                }
                
            }
        }
    }
}