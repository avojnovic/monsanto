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
          


           
            string query = "Select * from dbo.CentrosDeServicio";

            DataTableReader datatableReader = Connection.getFromDataBase(query);

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
