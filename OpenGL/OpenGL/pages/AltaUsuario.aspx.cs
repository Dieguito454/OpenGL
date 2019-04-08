using OpenGL.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenGL.pages
{
    public partial class AltaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
        }

        protected void btnCargarUsuario_Click(object sender, EventArgs e)
        {
            limpiarCampos();

            if (!AgregarNuevo())
            {
                lblMensaje.Text = Session["error"].ToString();
                lblMensaje.Visible = true;
            }

            Response.Redirect("Principal.aspx");
        }

        protected bool AgregarNuevo()
        {
            bool valorRetorno = false;
            int aux = 0;
            DateTime fecha = DateTime.Now;


            try
            {
                if (String.IsNullOrEmpty(txtUsername.Text))
                {
                    aux = 1;
                    //lblUsuairo.ForeColor = System.Drawing.Color.Red;
                    //lblUsuairo.Text = "* Usuario";
                    //Session["error"] = "Ingresar datos faltantes";

                }

                if (String.IsNullOrEmpty(txtContraseña.Text))
                {
                    aux = 1;
                    //lblContraseña.ForeColor = System.Drawing.Color.Red;
                    //lblContraseña.Text = "* Contraseña";
                    //Session["error"] = "Ingresar datos faltantes";

                }

                if (String.IsNullOrEmpty(txtNombreApellido.Text))
                {
                    aux = 1;
                    //lblNombreApellido.ForeColor = System.Drawing.Color.Red;
                    //lblNombreApellido.Text = "* Nombre y apellido";
                    //Session["error"] = "Ingresar datos faltantes";

                }

                if (String.IsNullOrEmpty(txtCargo.Text))
                {
                    aux = 1;
                    //lblCargo.ForeColor = System.Drawing.Color.Red;
                    //lblCargo.Text = "* Cargo";
                    //Session["error"] = "Ingresar datos faltantes";

                }

                if (String.IsNullOrEmpty(txtEmail.Text))
                {
                    aux = 1;
                    //lblEmail.ForeColor = System.Drawing.Color.Red;
                    //lblEmail.Text = "* Email";
                    //Session["error"] = "Ingresar datos faltantes";

                }

                bool valorAdmin = false;
                try
                {
                    if (cboAdministrador.SelectedValue == "1")
                    {
                        valorAdmin = true;
                    }
                }
                catch
                {

                    aux = 1;
                }

                if (aux == 0)
                {
                    valorRetorno = clsActualizaciones.Agregar_usuario(txtUsername.Text, txtContraseña.Text, txtNombreApellido.Text, txtEmail.Text, valorAdmin, fecha, txtCargo.Text);
                }
            }
            catch { }

            return valorRetorno;
        }


        private void limpiarCampos()
        {
            Session["error"] = null;
            lblMensaje.Visible = false;
        }
    }
}