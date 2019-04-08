using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace OpenGL.clases
{
    public class clsActualizaciones
    {


        public static bool Agregar_usuario(string username, string contraseña, string nombreapellido, string email, bool esAdmin, DateTime fecha, string cargo)
        {
            bool valorRetorno = false;

            using (SqlConnection myConn = new SqlConnection(Conexion.conn))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Agregar_Usuario", myConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@username", SqlDbType.VarChar);
                    cmd.Parameters["@username"].Value = username;

                    cmd.Parameters.Add("@contraseña", SqlDbType.VarChar);
                    cmd.Parameters["@contraseña"].Value = contraseña;

                    cmd.Parameters.Add("@nombreApellido", SqlDbType.VarChar);
                    cmd.Parameters["@nombreApellido"].Value = nombreapellido;

                    cmd.Parameters.Add("@cargo", SqlDbType.VarChar);
                    cmd.Parameters["@cargo"].Value = cargo;

                    cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    cmd.Parameters["@email"].Value = email;

                    cmd.Parameters.Add("@esAdmin", SqlDbType.Bit);
                    cmd.Parameters["@esAdmin"].Value = esAdmin;

                    cmd.Parameters.Add("@fechaAlta", SqlDbType.DateTime);
                    cmd.Parameters["@fechaAlta"].Value = fecha;




                    System.Web.HttpContext.Current.Session["error"] = null;

                    try
                    {
                        myConn.Open();
                        cmd.ExecuteNonQuery();
                        valorRetorno = true;
                    }
                    catch (Exception ex)
                    {

                        System.Web.HttpContext.Current.Session["error"] = ex.ToString();
                    }
                    finally { myConn.Close(); }

                    return valorRetorno;
                }
            }
        }


        public static bool Actualizar_usuario(int id, string username, string constraseña, string nombreapellido, string email, bool esAdmin, string cargo)
        {
            bool valorRetorno = false;

            using (SqlConnection myConn = new SqlConnection(Conexion.conn))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Modificar_usuario", myConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id_usuario", SqlDbType.Int);
                    cmd.Parameters["@id_usuario"].Value = id;

                    cmd.Parameters.Add("@username", SqlDbType.VarChar);
                    cmd.Parameters["@username"].Value = username;

                    cmd.Parameters.Add("@contraseña", SqlDbType.VarChar);
                    cmd.Parameters["@contraseña"].Value = constraseña;

                    cmd.Parameters.Add("@nombreApellido", SqlDbType.VarChar);
                    cmd.Parameters["@nombreApellido"].Value = nombreapellido;

                    cmd.Parameters.Add("@cargo", SqlDbType.VarChar);
                    cmd.Parameters["@cargo"].Value = cargo;

                    cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    cmd.Parameters["@email"].Value = email;

                    cmd.Parameters.Add("@esAdmin", SqlDbType.Bit);
                    cmd.Parameters["@esAdmin"].Value = esAdmin;



                    System.Web.HttpContext.Current.Session["error"] = null;

                    try
                    {
                        myConn.Open();
                        cmd.ExecuteNonQuery();
                        valorRetorno = true;

                    }
                    catch (Exception ex)
                    {

                        System.Web.HttpContext.Current.Session["error"] = ex.ToString();
                    }
                    finally { myConn.Close(); }

                    return valorRetorno;
                }
            }
        }

        public static bool Agregar_Transaccion(string transaccion, int codigo, decimal monto, DateTime fechaC,
            DateTime fechaR, string documento, int user, string jornada,
            string linea, int movimiento, int comprobante)
        {
            bool valorRetorno = false;

            using (SqlConnection myConn = new SqlConnection(Conexion.conn))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Agregar_Transaccion1", myConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@transaccion", SqlDbType.VarChar);
                    cmd.Parameters["@transaccion"].Value = transaccion;

                    cmd.Parameters.Add("@codigo", SqlDbType.Int);
                    cmd.Parameters["@codigo"].Value = codigo;

                    cmd.Parameters.Add("@monto", SqlDbType.Decimal);
                    cmd.Parameters["@monto"].Value = monto;

                    cmd.Parameters.Add("@fecha_creacion", SqlDbType.DateTime);
                    cmd.Parameters["@fecha_creacion"].Value = fechaC;

                    cmd.Parameters.Add("@fecha_registracion", SqlDbType.DateTime);
                    cmd.Parameters["@fecha_registracion"].Value = fechaR;

                    cmd.Parameters.Add("@documento", SqlDbType.VarChar);
                    cmd.Parameters["@documento"].Value = documento;

                    cmd.Parameters.Add("@user", SqlDbType.Int);
                    cmd.Parameters["@user"].Value = user;

                    cmd.Parameters.Add("@jornada", SqlDbType.VarChar);
                    cmd.Parameters["@jornada"].Value = jornada;

                    cmd.Parameters.Add("@linea", SqlDbType.VarChar);
                    cmd.Parameters["@linea"].Value = linea;

                    cmd.Parameters.Add("@movimiento", SqlDbType.Int);
                    cmd.Parameters["@movimiento"].Value = movimiento;

                    cmd.Parameters.Add("@comprobante", SqlDbType.Int);
                    cmd.Parameters["@comprobante"].Value = comprobante;

                    System.Web.HttpContext.Current.Session["error"] = null;

                    try
                    {
                        myConn.Open();
                        cmd.ExecuteNonQuery();
                        valorRetorno = true;
                    }
                    catch (Exception ex)
                    {

                        System.Web.HttpContext.Current.Session["error"] = ex.ToString();
                    }
                    finally { myConn.Close(); }

                    return valorRetorno;
                }
            }
        }

        public static bool Actualizar_Transaccion(int id, int codigo, decimal monto, DateTime fechaC, DateTime fechaR, string documento, string jornada, string linea, int movimiento)
        {
            bool valorRetorno = false;

            using (SqlConnection myConn = new SqlConnection(Conexion.conn))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Modificar_Transaccion", myConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id_Transaccion", SqlDbType.Int);
                    cmd.Parameters["@id_Transaccion"].Value = id;

                    cmd.Parameters.Add("@codigo", SqlDbType.Int);
                    cmd.Parameters["@codigo"].Value = codigo;

                    cmd.Parameters.Add("@monto", SqlDbType.Decimal);
                    cmd.Parameters["@monto"].Value = monto;

                    cmd.Parameters.Add("@fecha_creacion", SqlDbType.DateTime);
                    cmd.Parameters["@fecha_creacion"].Value = fechaC;

                    cmd.Parameters.Add("@fecha_registracion", SqlDbType.DateTime);
                    cmd.Parameters["@fecha_registracion"].Value = fechaR;

                    cmd.Parameters.Add("@documento", SqlDbType.VarChar);
                    cmd.Parameters["@documento"].Value = documento;

                    cmd.Parameters.Add("@jornada", SqlDbType.VarChar);
                    cmd.Parameters["@jornada"].Value = jornada;

                    cmd.Parameters.Add("@linea", SqlDbType.VarChar);
                    cmd.Parameters["@linea"].Value = linea;

                    cmd.Parameters.Add("@movimiento", SqlDbType.Int);
                    cmd.Parameters["@movimiento"].Value = movimiento;


                    System.Web.HttpContext.Current.Session["error"] = null;

                    try
                    {
                        myConn.Open();
                        cmd.ExecuteNonQuery();
                        valorRetorno = true;
                    }
                    catch (Exception ex)
                    {

                        System.Web.HttpContext.Current.Session["error"] = ex.ToString();
                    }
                    finally { myConn.Close(); }

                    return valorRetorno;
                }
            }
        }



        public static bool Agregar_Cuenta(int codigo, string desc)
        {
            bool valorRetorno = false;

            using (SqlConnection myConn = new SqlConnection(Conexion.conn))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Agregar_Cuenta", myConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@codigo", SqlDbType.Int);
                    cmd.Parameters["@codigo"].Value = codigo;

                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar);
                    cmd.Parameters["@descripcion"].Value = desc;

                    System.Web.HttpContext.Current.Session["error"] = null;

                    try
                    {
                        myConn.Open();
                        cmd.ExecuteNonQuery();
                        valorRetorno = true;
                    }
                    catch (Exception ex)
                    {

                        System.Web.HttpContext.Current.Session["error"] = ex.ToString();
                    }
                    finally { myConn.Close(); }

                    return valorRetorno;
                }
            }
        }


    }
}