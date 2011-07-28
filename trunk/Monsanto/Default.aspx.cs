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

            if (!IsPostBack)
            {
                Session["indexs"] = null;


                List<CentroDeServicio> _listCentServ = CentroDeServicioDAO.obtenerCentrosServicio();

                ddlCentroDeServicio.DataTextField = "nombre";
                ddlCentroDeServicio.DataValueField = "id";
                ddlCentroDeServicio.DataSource = _listCentServ;
                ddlCentroDeServicio.DataBind();

            

                string id_centServ = ddlCentroDeServicio.SelectedValue;
                cargarGrillaExactitud(id_centServ);
            }
        }

        private void setearGrillaSiEstaVacia(GridView g)
        {

            if (g.Rows.Count == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Numero");
                dt.Columns.Add("Fecha");
                dt.Columns.Add("Id");
                dt.Columns.Add("Observacion");
                dt.Columns.Add("Exceptuado");

               
                dt.Rows.Add(new object[] { "", "", "1", "", false });

                dt.Rows[0].SetField(4, false);
                g.DataSource = dt;
                g.DataBind();

                TextBox t = (TextBox)GridViewExactitud.Rows[0].FindControl("TxtObservacion");
                t.Enabled = false;
                CheckBox c= (CheckBox)GridViewExactitud.Rows[0].FindControl("CheckBoxExcep");
                c.Enabled = false;
            }

        }

        protected void ddlCentroDeServicio_modified(object sender, EventArgs e)
        {
            string id_centServ = ddlCentroDeServicio.SelectedValue;
            cargarGrillaExactitud(id_centServ);
        }

        //Exactitud
        private void cargarGrillaExactitud(string id_centServ)
        {

           List<metrica1> _metrica1= Metrica1DAO.obtenerMetricas(id_centServ);
           
           GridViewExactitud.DataSource = _metrica1;
          
           GridViewExactitud.DataBind();

            setearGrillaSiEstaVacia(GridViewExactitud);
        }

        protected void gridExactitud_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            Dictionary<int, GridStateValues> indexs = guardarDirtyFlagsGrillaExactitud();

            string id_centServ = ddlCentroDeServicio.SelectedValue;
            cargarGrillaExactitud(id_centServ);
            this.GridViewExactitud.PageIndex = e.NewPageIndex;
            this.GridViewExactitud.DataBind();

            foreach (GridViewRow row in GridViewExactitud.Rows)
            {
                int index = (int)GridViewExactitud.DataKeys[row.RowIndex].Value;

                if (indexs.Keys.Contains(index))
                {
                    ((CheckBox)row.FindControl("CheckBoxExcep")).Checked = indexs[index]._checked1;
                    ((TextBox)row.FindControl("TxtObservacion")).Text = indexs[index].Text;
                }
            }

           
          

        }

        private Dictionary<int, GridStateValues> guardarDirtyFlagsGrillaExactitud()
        {
            Dictionary<int, GridStateValues> indexs;
            if (Session["indexs"] != null)
                indexs = (Dictionary<int, GridStateValues>)Session["indexs"];
            else
                indexs = new Dictionary<int, GridStateValues>();


            foreach (GridViewRow r in GridViewExactitud.DirtyRows)
            {
                GridStateValues gv = new GridStateValues();
                gv._checked1 = ((CheckBox)GridViewExactitud.Rows[r.RowIndex].FindControl("CheckBoxExcep")).Checked;
                gv.Text = ((TextBox)GridViewExactitud.Rows[r.RowIndex].FindControl("TxtObservacion")).Text;

                if (!indexs.ContainsKey((int)GridViewExactitud.DataKeys[r.RowIndex].Value))
                {
                    indexs.Add((int)GridViewExactitud.DataKeys[r.RowIndex].Value, gv);
                }
                else
                {
                    indexs[(int)GridViewExactitud.DataKeys[r.RowIndex].Value] = gv;
                }
            }


            Session["indexs"] = indexs;
            return indexs;
        }
        //FIN Exactitud



        protected void BtnGuardar_Click(object sender, EventArgs e)
        {


            Dictionary<int, GridStateValues> indexs = guardarDirtyFlagsGrillaExactitud();

            Metrica1DAO.actualizarMetricas(indexs);

            
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Session["indexs"] = null;
            string id_centServ = ddlCentroDeServicio.SelectedValue;
            cargarGrillaExactitud(id_centServ);
        }

    }
}