using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Monsanto
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                    lblUsuario.Text = Session["user"].ToString();
                else
                    Response.Redirect("login.aspx");
            }
        }

        protected void ScriptManager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
            ScriptManager1.AsyncPostBackErrorMessage = e.Exception.Message;
            Response.Redirect(Request.Url.ToString());
        }



        protected void BtnToUpload(object sender, EventArgs e)
        {
            Response.Redirect("Upload.aspx");
        }

        protected void BtnToHome(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }


        protected void BtnToProcess(object sender, EventArgs e)
        {
            Response.Redirect("Procesamiento.aspx");
        }

    }
}