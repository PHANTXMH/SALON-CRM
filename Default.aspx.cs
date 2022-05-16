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
        int gallery = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            gallerySlideShow();            
        }

        void gallerySlideShow()
        {
            Button_homepage_gallery_previous.Enabled = false;
            Button_homepage_gallery_next.Enabled = true;
            Image_homepage.ImageUrl = "https://blackhairinformation.com/wp-content/uploads/2016/10/Salon.jpg";
            Image_homepage.Height = 255;
            Image_homepage.Width = 430;
        }

        protected void Button_homepage_gallery_next_Click(object sender, EventArgs e)
        {
            if (gallery == 1)
            {
                gallery = 2;
                gallerySlideShow3();
                
            }else
            if (gallery == 2)
            {
                gallery = 3;
                gallerySlideShow2();
            }            
        }

        protected void Button_homepage_gallery_previous_Click(object sender, EventArgs e)
        {
            if(gallery == 3)
            {
                gallery = 2;
                gallerySlideShow2();
            }else
            if(gallery == 2)
            {
                gallery = 1;
                gallerySlideShow();
            }
        }

        void gallerySlideShow2()
        {
            Button_homepage_gallery_previous.Enabled = true;
            Button_homepage_gallery_next.Enabled = true;
            Image_homepage.ImageUrl = "https://media.glamour.com/photos/5f5bbc4b57e4fde4029c8f24/1:1/w_1080,h_1080,c_limit/118201188_1388346488222636_8021455638907600604_n.jpg";
            Image_homepage.Height = 265;
            Image_homepage.Width = 240;
        }

        void gallerySlideShow3()
        {        
            Button_homepage_gallery_next.Enabled = false;
            Button_homepage_gallery_previous.Enabled = true;
            Image_homepage.ImageUrl = "https://www.hairstyleslife.com/wp-content/uploads/2019/06/Braids-hairstyles-for-black-women-2019-2020.jpg";
            Image_homepage.Height = 265;
            Image_homepage.Width = 420;
        }       
    }
}