using OpenGL.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenGL.pages
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            limpiarCampos();

            if (!AgregarNuevo())
            {
                lblMensaje.Text = Session["error"].ToString();
                lblMensaje.Visible = true;
            }

            Response.Redirect("../Default.aspx");
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
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

                }

                if (String.IsNullOrEmpty(txtContraseña.Text))
                {
                    aux = 1;

                }

                if (String.IsNullOrEmpty(txtNombreApellido.Text))
                {
                    aux = 1;

                }

                if (String.IsNullOrEmpty(txtCargo.Text))
                {
                    aux = 1;

                }

                if (String.IsNullOrEmpty(txtEmail.Text))
                {
                    aux = 1;

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