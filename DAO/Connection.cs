using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

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
    }
}