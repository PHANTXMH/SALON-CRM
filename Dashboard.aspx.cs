using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Salon_CRM
{
    public partial class Dashboard : System.Web.UI.Page
    {
        DataAccessModule dbAccess = new DataAccessModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GridView_dashboard_today_appointment.DataSource = dbAccess.getDashboardAppointmentForToday();
                GridView_dashboard_today_appointment.DataBind();
                GridView_dashboard_all_appointment.DataSource = dbAccess.getAllDashboardAppointment();
                GridView_dashboard_all_appointment.DataBind();

                
            }
        }

                                                //FIGURE OUT A WAY TO LET THE DROPDOWNLIST SHOW THE SERVICES FOR EACH APPOINTMENT
        
        //int rw = ((GridViewRow)(DropDownList_).NamingContainer).RowIndex; //Gets the row id for the selected service

        //DataTable dataTable = dbAccess.getAllServicesFromAppointment(GridView_);

        protected void Button_dashboard_complete_Click(object sender, EventArgs e)
        {

        }        
    }
}