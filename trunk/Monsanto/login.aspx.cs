using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Monsanto
{
    public partial class Login : System.Web.UI.Page
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

            Session["user"] = HttpContext.Current.User.Identity.Name.ToString();

            FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.User.Identity.Name.ToString(), false);
        }
    }
}