using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salon_CRM
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gallerySlideShow();
        }

        void gallerySlideShow()
        {
            Image_homepage.ImageUrl = "https://blackhairinformation.com/wp-content/uploads/2016/10/Salon.jpg";
            Image_homepage.Height = 255;
            Image_homepage.Width = 430;
        }

        protected void Button_homepage_gallery_next_Click(object sender, EventArgs e)
        {
            Image_homepage.ImageUrl = "https://media.glamour.com/photos/5f5bbc4b57e4fde4029c8f24/1:1/w_1080,h_1080,c_limit/118201188_1388346488222636_8021455638907600604_n.jpg";
            Image_homepage.Height = 255;
            Image_homepage.Width = 240;
        }
    }
}