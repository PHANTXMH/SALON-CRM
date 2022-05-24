using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salon_CRM
{
    public partial class Appointments : System.Web.UI.Page
    {
        DataAccessModule dbAccess = new DataAccessModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Global.user == null)
            {
                Response.Redirect("Login.aspx");
            }            

            if (!IsPostBack)
            {
                Label_firstname_appointment.Text = Global.user.Fname;
                Label_lastname_appointment.Text = Global.user.Lname;

                GridView_pending_appointments.DataSource = dbAccess.getPendingAppointments(Global.user.Id);
                GridView_pending_appointments.DataBind();
            }
        }

        protected void Button_appointments_remove_bookings_Click(object sender, EventArgs e)
        {

        }
    }
}