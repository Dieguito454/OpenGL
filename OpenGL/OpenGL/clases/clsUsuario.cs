using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace OpenGL.clases
{
    public class clsUsuario
    {

        #region variables
        private string _username;
        private string _contraseña;
        private string _nombreApellido;
        private DateTime _fechaAlta;
        private string _email;
        private bool _esAdmin;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        public string NombreApellido
        {
            get { return _nombreApellido; }
            set { _nombreApellido = value; }
        }

        public DateTime FechaAlta
        {
            get { return _fechaAlta; }
            set { _fechaAlta = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public bool EsAdmin
        {
            get { return _esAdmin; }
            set { _esAdmin = value; }
        }

        #endregion


        #region constructor
        public clsUsuario(string username, string contraseña, string nombreApellido, DateTime fecha, string email, bool esAdmin)
        {
            _username = username;
            _contraseña = contraseña;
            _nombreApellido = nombreApellido;
            _fechaAlta = fecha;
            _email = email;
            _esAdmin = esAdmin;
        }

        #endregion


        public static DataSet getUsuario(string usuario, string contraseña)
        {
            DataSet newDs = new DataSet();

            System.Web.HttpContext.Current.Session["ErrorGetUsuario"] = null;

            using (SqlConnection Myconn = new SqlConnection(Conexion.conn))
            {
                using (SqlCommand cmd = new SqlCommand("GetUsuario", Myconn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
#pragma warning disable CS0618 // 'SqlParameterCollection.Add(string, object)' está obsoleto: 'Add(String parameterName, Object value) has been deprecated.  Use AddWithValue(String parameterName, Object value).  http://go.microsoft.com/fwlink/?linkid=14202'
                    cmd.Parameters.Add("@username", usuario);
#pragma warning restore CS0618 // 'SqlParameterCollection.Add(string, object)' está obsoleto: 'Add(String parameterName, Object value) has been deprecated.  Use AddWithValue(String parameterName, Object value).  http://go.microsoft.com/fwlink/?linkid=14202'
#pragma warning disable CS0618 // 'SqlParameterCollection.Add(string, object)' está obsoleto: 'Add(String parameterName, Object value) has been deprecated.  Use AddWithValue(String parameterName, Object value).  http://go.microsoft.com/fwlink/?linkid=14202'
                    cmd.Parameters.Add("@contraseña", contraseña);
#pragma warning restore CS0618 // 'SqlParameterCollection.Add(string, object)' está obsoleto: 'Add(String parameterName, Object value) has been deprecated.  Use AddWithValue(String parameterName, Object value).  http://go.microsoft.com/fwlink/?linkid=14202'
                    cmd.Connection = Myconn;
                    using (SqlDataAdapter myDa = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            myDa.Fill(newDs);
                        }
                        catch (Exception ex)
                        {

                            System.Web.HttpContext.Current.Session["errorGetUsuario"] = ex.Message;
                        }

                        return newDs;
                    }
                }
            }
        }
    }
}