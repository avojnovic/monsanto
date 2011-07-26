using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAO
{
    public class Connection
    {

       


        public  static void open(SqlConnection myConnection)
        {
            try
            {


                Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                ConnectionStringSettings connString;
                if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
                {
                    connString = rootWebConfig.ConnectionStrings.ConnectionStrings["MonsantoConStr"];
                    if (null != connString)
                    {
                        myConnection.ConnectionString = connString.ToString();
                        myConnection.Open();
                    }
                   
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public static DataTableReader getFromDataBase(string query)
        {
            SqlConnection myConnection = new SqlConnection();
            
            try
            {
                Connection.open(myConnection);
                DataTable dt = new DataTable();
                SqlCommand cmm = new SqlCommand(query, myConnection);
                cmm.CommandTimeout = 6000;
                SqlDataAdapter da = new SqlDataAdapter(cmm);
                da.Fill(dt);
                DataTableReader datatableReader = dt.CreateDataReader();
               
                return datatableReader;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                myConnection.Close();
            }
           
        }

    }
}