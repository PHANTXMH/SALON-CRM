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
        List<int> selectedServices = new List<int>();
        DataAccessModule dbAccess = new DataAccessModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView_services.DataSource = dbAccess.getAllServices();
                GridView_services.DataBind();              
            }
        }

        protected void Button_services_select_Click(object sender, EventArgs e)
        {
            //Button btn = ((Button)(this.GridView_services.FindControl("Button_services_select")));
            
            Button btn = sender as Button;
            int rw = ((GridViewRow)(btn).NamingContainer).RowIndex; //Gets the row id for the selected service

            if (btn.Text == "Select")
            {
                btn.Text = "Deselect";
                btn.BackColor = System.Drawing.Color.Red;

                selectedServices.Add(int.Parse(GridView_services.Rows[rw].Cells[0].Text));
                TextBox_services.Text = selectedServices.ToString();
            }
            else
            {
                btn.Text = "Select";
                btn.BackColor = System.Drawing.Color.LimeGreen;

                selectedServices.Remove(int.Parse(GridView_services.Rows[rw].Cells[0].Text));
                TextBox_services.Text = selectedServices.ToString();
            }          
        }        
    }
}