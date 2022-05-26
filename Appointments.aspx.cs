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
            if (Global.user == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                Label_firstname_appointment.Text = Global.user.Fname;
                Label_lastname_appointment.Text = Global.user.Lname;

                GridView_pending_appointments.DataSource = dbAccess.getPendingAppointments(Global.user.Id);
                GridView_pending_appointments.DataBind();

                DropDownList_appointment_time_selection.Items.Add(new ListItem("9AM","9:00 AM"));
                DropDownList_appointment_time_selection.Items.Add(new ListItem("10AM", "10:00 AM"));
                DropDownList_appointment_time_selection.Items.Add(new ListItem("11AM", "11:00 AM"));
                DropDownList_appointment_time_selection.Items.Add(new ListItem("12PM", "12:00 PM"));
                DropDownList_appointment_time_selection.Items.Add(new ListItem("1PM", "1:00 PM"));
                DropDownList_appointment_time_selection.Items.Add(new ListItem("2PM", "2:00 PM"));
                DropDownList_appointment_time_selection.Items.Add(new ListItem("3PM", "3:00 PM"));

                if (Global.selectedServices.Count > 0)
                {
                    GridView_appointment_new_bookings.DataSource = dbAccess.getBookingServices(Global.selectedServices);
                    GridView_appointment_new_bookings.DataBind();

                    tallyAppointment();
                }
            }

            if (GridView_appointment_new_bookings.Rows.Count < 1)
            {
                Button_appointment_confirm.Enabled = false;                
            }
            else
            {
                Button_appointment_confirm.Enabled = true;                
            }
           
        }

        protected void Button_appointments_remove_bookings_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int rw = ((GridViewRow)(btn).NamingContainer).RowIndex; //Gets the row id for the selected service

            Global.selectedServices.Remove(int.Parse(GridView_appointment_new_bookings.Rows[rw].Cells[0].Text));

            GridView_appointment_new_bookings.DataSource = dbAccess.getBookingServices(Global.selectedServices);
            GridView_appointment_new_bookings.DataBind();

            tallyAppointment();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Services.aspx");
        }

        void tallyAppointment()
        {
            int appointmentTotal = 0, x = 0;
            foreach (int n in Global.selectedServices)
            {
                appointmentTotal += int.Parse(GridView_appointment_new_bookings.Rows[x].Cells[2].Text);
                x++;
            }

            TextBox_appointment_total.Text = "$" + appointmentTotal.ToString();
            if(appointmentTotal == 0)
            {
                TextBox_appointment_total.Text = "";
                Button_appointment_confirm.Enabled = false;                
            }
        }

        protected void Button_appointment_confirm_Click(object sender, EventArgs e)
        {
            if (Calendar_appointment.SelectedDate == DateTime.MinValue)
            {
                Label_confirm_button_info.Text = "Please select a date for the appointment.";
                Label_confirm_button_info.ForeColor = System.Drawing.Color.Red;
                Label_confirm_button_info.Visible = true;
            }
            else
            if (Calendar_appointment.SelectedDate.CompareTo(DateTime.Now) < 0)
            {
                Label_confirm_button_info.Text = "The date selected has already passed.";
                Label_confirm_button_info.ForeColor = System.Drawing.Color.Red;
                Label_confirm_button_info.Visible = true;
            }
            else
            if(Calendar_appointment.SelectedDate.DayOfWeek == DayOfWeek.Saturday)
            {
                Label_confirm_button_info.Text = "The business is closed on Saturday.";
                Label_confirm_button_info.ForeColor = System.Drawing.Color.Red;
                Label_confirm_button_info.Visible = true;
            }
            else             
            {                
                //RUN DATABASE COMMAND TO ADD APPOINTMENT FOR CURRENT USER
                dbAccess.setClientAppointment(Global.user.Id, Calendar_appointment.SelectedDate.ToShortDateString(), DropDownList_appointment_time_selection.SelectedValue);
                Label_confirm_button_info.Text = "Your appointment has been created.";
                Label_confirm_button_info.ForeColor = System.Drawing.Color.Green;
                Label_confirm_button_info.Visible = true;
                Button_appointment_confirm.Enabled = false;

                GridView_pending_appointments.DataSource = dbAccess.getPendingAppointments(Global.user.Id);
                GridView_pending_appointments.DataBind();

                Global.selectedServices = new List<int>();  //clear list after processing
                TextBox_appointment_total.Text = "";

                GridView_appointment_new_bookings.DataSource = dbAccess.getBookingServices(Global.selectedServices);
                GridView_appointment_new_bookings.DataBind();
            }

            
        }
    }
}