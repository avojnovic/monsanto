using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Text;
using Utils;
using System;
using System.Web.Security;


namespace Monsanto
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //bool enableLogin = false;
            //if (HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    if (ActDirCheck.CheckUserAuthentication(HttpContext.Current.User.Identity.Name.ToString()))
            //    {
            //        enableLogin = true;
            //    }
            //}

            //Session["user"] = r;
            FormsAuthentication.RedirectFromLoginPage("test", false);
            
        }

        protected void clickbtn(object sender, EventArgs e)
        {

            Response.Redirect("About.aspx?id=1");

        }



    }
}