using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinessObjects;
using System.Data;

namespace DAO
{
   public class Metrica1DAO
    {

       

       private static List<metrica1> obtenerMetricasGeneric(string query)
       {
           DataTableReader datatableReader = Connection.getFromDataBase(query);

           List<metrica1> _listMetrica1 = new List<metrica1>();


           while (datatableReader.Read())
           {
               metrica1 m = new metrica1();
               m.Id = (int)datatableReader["id"];
               m.Numero = (string)datatableReader["numero"];


               if (!datatableReader.IsDBNull(datatableReader.GetOrdinal("fecha")))
                   m.Fecha = datatableReader.GetDateTime(datatableReader.GetOrdinal("fecha"));



               if ((int)datatableReader["exceptuado"] == 1)
                   m.Exceptuado = true;
               else
                   m.Exceptuado = false;

               if (!datatableReader.IsDBNull(datatableReader.GetOrdinal("observacion")))
                   m.Observacion = (string)datatableReader["observacion"];
               else
                   m.Observacion = "";


               _listMetrica1.Add(m);
           }
           return _listMetrica1;
       }

       public static List<metrica1> obtenerMetricas()
       {

           string query = "Select * from dbo.metrica1";

           return obtenerMetricasGeneric(query);

       }

       public static List<metrica1> obtenerMetricas(string id_centServ)
       {
           string query =string.Format( "Select * from dbo.metrica1 where id_centroServ={0} ", id_centServ);

           return obtenerMetricasGeneric(query);
       }



       public static void actualizarMetricas(Dictionary<int, GridStateValues> gv)
       {
           string update = "update dbo.metrica1 set exceptuado={0}, observacion='{1}' where id={2}; ";

            StringBuilder sb = new StringBuilder();
           foreach (int i in gv.Keys.ToList())
           {
               string check="";
              if( gv[i]._checked1)
                  check="1";
               else
                  check="0";
              

               sb.Append(string.Format(update,check,gv[i].Text,i.ToString()));
               

           }

           Connection.ExecuteNonQuery(sb.ToString());

       }
    }
}
