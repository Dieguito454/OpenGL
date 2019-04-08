using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using OpenGL.clases;

namespace OpenGL.pages
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioLogin"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (!Page.IsPostBack)
            {
                cargar_datos();
            }
        }

        protected void cargar_datos()
        {

            DataTable dtDatos = null;

            string strConsulta = "exec SP_Mostrar_verEntradas";

            dtDatos = Conexion.llenarGridFromConsulta(strConsulta);

            grDatos.DataSource = dtDatos;
            grDatos.DataBind();
        }


        protected void grDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Detalles")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grDatos.Rows[index];
                    Session["VerTransaccion_Detallado"] = Server.HtmlDecode(row.Cells[0].Text);

                    Response.Redirect("~/Menu/verEntradasDetalle.aspx");
                }

            }
            catch { }
        }




       

    }
}