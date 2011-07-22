using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BussinessObjects;


namespace DAO
{
    public class CentroDeServicioDAO
    {
        public static List<CentroDeServicio> obtenerCentrosServicio()
        {
             SqlConnection myConnection = new SqlConnection();
            Connection.open(myConnection);


            DataTable dt = new DataTable();
            string query = "Select * from dbo.CentrosDeServicio";

            SqlCommand cmm = new SqlCommand(query, myConnection);
            cmm.CommandTimeout=6000;
            SqlDataAdapter da= new  SqlDataAdapter(cmm);
            da.Fill(dt);

            DataTableReader datatableReader = dt.CreateDataReader();
            myConnection.Close();

            List<CentroDeServicio> _listCentros = new List<CentroDeServicio>();

           
                while (datatableReader.Read()) 
                {
                    CentroDeServicio cs = new CentroDeServicio();
                    cs.Id =(int)datatableReader["id"];
                    cs.Nombre = (string)datatableReader["nombre"];

                    _listCentros.Add(cs);
                }
            

            return _listCentros;
        
        }


    }
}
