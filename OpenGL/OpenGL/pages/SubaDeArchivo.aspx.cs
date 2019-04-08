using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using OpenGL.clases;
using System.Data.OleDb;
using ClosedXML.Excel;
using System.IO;



namespace OpenGL.pages
{
    public partial class SubaDeArchivo : System.Web.UI.Page
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

            lblMensaje.Visible = false;

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                //string conexion = "Provider = Microsoft.ACE.OleDb.12.0;Data Source = C:/Users/dtorres/Desktop/Horamar/1131008.xlsx ;Extended Properties = \"Excel 8.0;HDR = Yes\"";

                string path = Path.GetFileName(FileUpload1.FileName);
                path = path.Replace(" ", "");
                FileUpload1.SaveAs(Server.MapPath("/ExcelFile/") + path);
                String Excelpath = Server.MapPath("/ExcelFile/") + path;

                string conexion = "Provider = Microsoft.ACE.OleDb.12.0;Data Source = " + Excelpath + ";Extended Properties = \"Excel 8.0;HDR = Yes\"";


                OleDbConnection origen = default(OleDbConnection);
                origen = new OleDbConnection(conexion);

                OleDbCommand seleccion = default(OleDbCommand);
                seleccion = new OleDbCommand("select * from [Hoja1$]", origen);

                OleDbDataAdapter adaptador = new OleDbDataAdapter();

                adaptador.SelectCommand = seleccion;

                DataSet ds = new DataSet();

                adaptador.Fill(ds);


                grDatosSubidos.DataSource = ds.Tables[0];
                grDatosSubidos.DataBind();

                origen.Close();


                SqlConnection conexion_destino = new SqlConnection();

                conexion_destino.ConnectionString = "Data Source = (Local); Integrated Security = True; Initial Catalog = openGL ";

                conexion_destino.Open();

                SqlBulkCopy importar = default(SqlBulkCopy);
                importar = new SqlBulkCopy(conexion_destino);
                importar.DestinationTableName = "Modelotabla2";


                importar.WriteToServer(ds.Tables[0]);
                conexion_destino.Close();

                lblMensaje.Visible = true;                


            }
            catch (Exception ex)
            {

                
            }

        }


        protected void btnDescargarModelo1_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();

            page.EnableEventValidation = false;

            page.DesignerInitialize();

            page.Controls.Add(form);

            grDatos1.Columns[0].Visible = true;
            grDatos1.Columns[1].Visible = true;
            grDatos1.Columns[2].Visible = true;
            grDatos1.Columns[3].Visible = true;
            grDatos1.Columns[4].Visible = true;
            grDatos1.Columns[5].Visible = true;
            grDatos1.Columns[6].Visible = true;
            grDatos1.Columns[7].Visible = true;
            grDatos1.Columns[8].Visible = true;
            grDatos1.Columns[9].Visible = true;
            grDatos1.Columns[10].Visible = true;
            grDatos1.Columns[11].Visible = true;
            grDatos1.Columns[12].Visible = true;
            grDatos1.Columns[13].Visible = true;
            grDatos1.Columns[14].Visible = true;

            form.Controls.Add(grDatos1);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=TablaModelo1.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();


        }


        protected void cargar_datos()
        {

            DataTable dtDatos1 = null;
            string strConsulta = "select * from ModeloTabla1";

            dtDatos1 = Conexion.llenarGridFromConsulta(strConsulta);

            if (dtDatos1 == null)
            {
                if (Session["error"] != null)
                {
                    lblMensaje.Text = Session["error"].ToString();
                    lblMensaje.Visible = true;
                }
            }
            else
            {
                grDatos1.DataSource = dtDatos1;
                grDatos1.DataBind();
            }


        }




        protected void btnModelo1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PruebasAutoTabla1/SubaDeArchivoTable1.aspx");
        }

        protected void btnCargarTabla2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PruebasAutoTabla1/SubaDeArchivoTabla2.aspx");
        }


    }
}