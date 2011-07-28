using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace Monsanto
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void UploadButton_Click(object sender, EventArgs e)
        {
           
            String savePath = @"c:\temp\";

            if (RadUpload1.UploadedFiles.Count>0)
            {
                String fileName = RadUpload1.UploadedFiles[0].GetName();
                savePath += fileName;
                RadUpload1.UploadedFiles[0].SaveAs(savePath);

                UploadStatusLabel.Text = "Archivo subido: " + fileName;
                read_file(savePath);
            }
            else
            {
                UploadStatusLabel.Text = "No se especifico ningun archivo para subir.";
            }

        }

        protected void Customvalidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (RadUpload1.InvalidFiles.Count == 0);
        }


        private void read_file(string file)
        {
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file + ";Extended Properties=Excel 8.0;";;
            // Create the connection object
            OleDbConnection oledbConn = new OleDbConnection(connString);
            try
            {
                // Open connection
                oledbConn.Open();

                // Create OleDbCommand object and select data from worksheet Sheet1
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Hoja1$]", oledbConn);

                // Create new OleDbDataAdapter
                OleDbDataAdapter oleda = new OleDbDataAdapter();

                oleda.SelectCommand = cmd;

                // Create a DataSet which will hold the data extracted from the worksheet.
                DataSet ds = new DataSet();

                // Fill the DataSet from the data extracted from the worksheet.
                oleda.Fill(ds);

                // Bind the data to the GridView

                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                oledbConn.Close();
            } 

        }
    }
}