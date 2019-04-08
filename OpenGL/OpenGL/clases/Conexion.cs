using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace OpenGL.clases
{
    public class Conexion
    {
        public static string conn = "Data Source= (Local);Integrated Security=True; Initial Catalog = openGL ";

        public static DataTable llenarGridFromConsulta(string consulta)
        {
            System.Web.HttpContext.Current.Session["error"] = null;

            DataTable newDt = new DataTable();

            using (SqlConnection myConn = new SqlConnection(Conexion.conn))
            {
                using (SqlDataAdapter myDa = new SqlDataAdapter(consulta, myConn))
                {
                    try
                    {
                        myDa.Fill(newDt);
                    }
                    catch (Exception ex)
                    {

                        System.Web.HttpContext.Current.Session["error"] = ex.Message;
                    }

                    return newDt;
                }
            }
        }

    }
}