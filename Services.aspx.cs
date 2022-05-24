using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salon_CRM
{
    public partial class Services : System.Web.UI.Page
    {        
        DataAccessModule dbAccess = new DataAccessModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                GridView_services.DataSource = dbAccess.getAllServices();
                GridView_services.DataBind();
                Session["appointmentCount"] = 0;
            }
        }

        protected void Button_services_select_Click(object sender, EventArgs e)
        {            
            Button btn = sender as Button;
            int rw = ((GridViewRow)(btn).NamingContainer).RowIndex; //Gets the row id for the selected service

            if (btn.Text == "Select")
            {                
                if (int.Parse(Session["appointmentCount"].ToString()) < 3)
                {
                    Session["appointmentCount"] = int.Parse(Session["appointmentCount"].ToString()) + 1;                    
                    btn.Text = "Deselect";
                    btn.BackColor = System.Drawing.Color.Red;
                    
                    Global.selectedServices.Add(int.Parse(GridView_services.Rows[rw].Cells[0].Text));
                }
                else
                {
                    Response.Write("<script>alert('No more that three (3) services can be made on an appointment.');</script>");
                }               
            }
            else        //btn.Text == "Deselect"
            {
                btn.Text = "Select";
                btn.BackColor = System.Drawing.Color.LimeGreen;

                if (int.Parse(Session["appointmentCount"].ToString()) > 0)
                {
                    Session["appointmentCount"] = int.Parse(Session["appointmentCount"].ToString()) - 1;
                }

                Global.selectedServices.Remove(int.Parse(GridView_services.Rows[rw].Cells[0].Text));

            }          
        }

        protected void Button_services_bookappointment_Click(object sender, EventArgs e)
        {
            Response.Redirect("Appointments.aspx");
        }
    }
}