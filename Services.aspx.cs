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
            GridView_services.DataSource = dbAccess.getAllServices();
            GridView_services.DataBind();
        }

        protected void Button_services_select_Click(object sender, EventArgs e)
        {

        }
    }
}