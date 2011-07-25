using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAO;
using BussinessObjects;

namespace Monsanto
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<CentroDeServicio> _listCentServ = CentroDeServicioDAO.obtenerCentrosServicio();

            ddlCentroDeServicio.DataTextField = "nombre";
            ddlCentroDeServicio.DataValueField = "id";
            ddlCentroDeServicio.DataSource = _listCentServ;
            ddlCentroDeServicio.DataBind();

            cargarGrillaExactitud();

        }

        private void setearGrillaSiEstaVacia(GridView g)
        {

            if (g.Rows.Count == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Numero");
                dt.Columns.Add("Fecha");
                dt.Columns.Add("Id");



                dt.Rows.Add(new object[] { "", "", "1" });

                g.DataSource = dt;
                g.DataBind();
            }

        }

        //Exactitud
        private void cargarGrillaExactitud()
        {
            setearGrillaSiEstaVacia(GridViewExactitud);
        }

        protected void gridExactitud_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cargarGrillaExactitud();
            this.GridViewExactitud.PageIndex = e.NewPageIndex;
            this.GridViewExactitud.DataBind();

            TextBox t=(TextBox)GridViewExactitud.Rows[GridViewExactitud.SelectedIndex].FindControl("TextBox1");
            

        }
        //FIN Exactitud



        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridViewExactitud.Rows.Count; i++)
			{
			    if()
			} 
            
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

        }

    }
}