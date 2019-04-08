using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using OpenGL.clases;

namespace OpenGL
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Session["usuarioLogin"] = null;
                Session["contraseñaLogin"] = null;
                Session["emails"] = null;
                Session["nombreUsuarioID"] = null;
                Session["fechaAlta"] = null;

            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            getUsuario(txtUsuario.Text, txtPass.Text);


            if (Session["usuarioLogin"] != null)
            {
                lblMensaje.Visible = false;
                Response.Redirect("pages/Principal.aspx");

            }


            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "El usuario o la contraseña son incorrectos";
            }
        }

        //protected void btnRegistrar_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("pages/Registro.aspx");
        //}

        protected bool tieneRegistros(DataSet ds)
        {
            return (ds.Tables[0].Rows.Count > 0);

        }

        protected void getUsuario(string usuario, string contraseña)
        {
            DataSet dsUsuario = null;

            try
            {
                dsUsuario = clsUsuario.getUsuario(usuario, contraseña);

                if (dsUsuario == null)
                {
                    lblMensaje.Visible = true;
                    if (!(Session["errorGetusuario"] == null))
                    {
                        lblMensaje.Text = Session["errorGetUsuario"].ToString();
                    }

                    Session["usuarioLogin"] = null;
                    Session["contraseñaLogin"] = null;
                    Session["emails"] = null;
                    Session["nombreUsuarioID"] = null;
                    Session["fechaAlta"] = null;
                }

                if (dsUsuario != null)
                {
                    if (tieneRegistros(dsUsuario))
                    {

                        Session["usuarioLogin"] = dsUsuario.Tables[0].Rows[0]["nombreapellido_usuario"].ToString();
                        Session["contraseñaLogin"] = dsUsuario.Tables[0].Rows[0]["contraseña"].ToString();
                        Session["emails"] = dsUsuario.Tables[0].Rows[0]["email"].ToString();
                        string esAdmin = dsUsuario.Tables[0].Rows[0]["esAdmin"].ToString();
                        Session["nombreUsuarioID"] = dsUsuario.Tables[0].Rows[0]["id_usuario"].ToString();
                        Session["fechaAlta"] = dsUsuario.Tables[0].Rows[0]["fecha_alta"].ToString();


                        if (esAdmin == "Si")
                        {
                            Session["esAdmin"] = "esAdminSI";

                        }
                        else
                        {
                            Session["esAdmin"] = null;
                        }

                        //cargarInformacion();
                    }
                    else
                    {
                        Session["usuarioLogin"] = null;
                        Session["contraseñaLogin"] = null;
                        Session["emails"] = null;
                        Session["nombreUsuarioID"] = null;
                        Session["fechaAlta"] = null;
                    }
                }
            }
            catch { }


        }

    }
}