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
                GridView_dashboard_today_appointment.Columns[1].Visible = false;
                
                GridView_dashboard_all_appointment.DataSource = dbAccess.getAllDashboardAppointment();
                GridView_dashboard_all_appointment.DataBind();
                GridView_dashboard_all_appointment.Columns[0].Visible = false;
                
            }
        }

        protected void Button_dashboard_complete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int rw = ((GridViewRow)(btn).NamingContainer).RowIndex;

            dbAccess.setAppointmentComplete(int.Parse(GridView_dashboard_today_appointment.Rows[rw].Cells[1].Text));
            GridView_dashboard_today_appointment.Columns[1].Visible = true;
            GridView_dashboard_today_appointment.DataSource = dbAccess.getDashboardAppointmentForToday();
            GridView_dashboard_today_appointment.DataBind();
            GridView_dashboard_today_appointment.Columns[1].Visible = false;
        }        

        protected void Button_dashboard_view_services_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int rw = ((GridViewRow)(btn).NamingContainer).RowIndex;

            if(btn.Text == "View")
            {
                btn.Text = "Hide";
                btn.BackColor = System.Drawing.Color.Orange;                
                
                GridView_dashboard_appointment_services.DataSource = dbAccess.getAllServicesFromAppointment(int.Parse(GridView_dashboard_today_appointment.Rows[rw].Cells[1].Text));
                GridView_dashboard_appointment_services.DataBind();
            }else
            {
                btn.Text = "View";
                btn.BackColor = System.Drawing.Color.DodgerBlue;
                GridView_dashboard_appointment_services.DataSource = null;
                GridView_dashboard_appointment_services.DataBind();
            }

            
            
        }
    }
}