using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Monsanto
{
    public partial class Procesamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUltEnvEmails.Text =DateTime.Now.ToShortDateString() +" "+ DateTime.Now.ToShortTimeString();
            lblUltProc.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        protected void procesar_click(object sender, EventArgs e)
        {
           
        }

        protected void email_click(object sender, EventArgs e)
        {
         
        }

    }
}