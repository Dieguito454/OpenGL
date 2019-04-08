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
    public partial class PruebasAutomaticas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            cargarCuentas();
            cargarComprobantes();

            //if (!Page.IsPostBack)
            //{
            //    cargarCuentas();
            //    cargarComprobantes();

            //    cargarCuentas2();
            //    cargarComprobantes2();

            //    cargarCuentas3();
            //    cargarComprobantes3();

            //    cargarCuentas4();
            //    cargarComprobantes4();

            //    cargarCuentas5();
            //    cargarComprobantes5();

            //    cargarCuentas6();
            //    cargarComprobantes6();

            //    cargarCuentas7();
            //    cargarComprobantes7();

            //    cargarCuentas8();
            //    cargarComprobantes8();


            //    cargarCuentas11();
            //    cargarComprobantes11();

            //    cargarCuentas12();
            //    cargarComprobantes12();

            //    cargarCuentas15();
            //    cargarComprobantes15();

            //    cargarCuentas16();
            //    cargarComprobantes16();

            //    cargarCuentas17();
            //    cargarComprobantes17();

            //    cargarCuentas18();
            //    cargarComprobantes18();


            //    cargarCuentas19();
            //    cargarComprobantes19();

            //    cargarCuentas20();
            //    cargarComprobantes20();

            //    cargarCuentas21();
            //    cargarComprobantes21();


            //    cargarCuentas22();
            //    cargarComprobantes22();


            //    cargarCuentas23();
            //    cargarComprobantes23();

            //    cargarCuentas24();
            //    cargarComprobantes24();

            //    cargarCuentas25();
            //    cargarComprobantes25();

            //    cargarCuentas26();
            //    cargarComprobantes26();

            //}

        }


        #region Cuentas Predeterminadas

        protected void btnDesmarcar_Click(object sender, EventArgs e)
        {
            chkCuentas.ClearSelection();
        }

        protected void cargarCuentas()
        {
            DataTable dtCuentas = null;

            string strConsulta = "select distinct CodigoCuenta, CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

            dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

            chkCuentas.Items.Clear();

            chkCuentas.DataTextField = "CuentaDescripcion";

            chkCuentas.DataValueField = "CodigoCuenta";

            chkCuentas.DataSource = dtCuentas;

            chkCuentas.DataBind();

        }

        protected void cargarComprobantes()
        {
            DataTable dtComprobantes = null;

            string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

            dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

            cboComprobantes.Items.Clear();

            cboComprobantes.DataTextField = "CodigoComprobante";

            cboComprobantes.DataValueField = "CodigoComprobante";

            cboComprobantes.DataSource = dtComprobantes;

            cboComprobantes.DataBind();

            cboComprobantes.Items.Insert(0, "Seleccione");
        }

        protected void cargarDatos1()
        {
            int aux = 0;

            DataTable dtDatos = null;

            string strConsulta = " exec SP_TABLA1_Mostrar_ListaDeCuentasDeterminadas ";


            if (!String.IsNullOrEmpty(txtFechaDesde.Text))
            {
                if (aux == 1)
                {
                    strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde.Text + "'";
                }
                else
                {
                    strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde.Text + "'";
                    aux = 1;
                }
            }
            if (!String.IsNullOrEmpty(txtFechaHasta.Text))
            {
                if (aux == 1)
                {
                    strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta.Text + "'";
                }
                else
                {
                    strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta.Text + "'";
                    aux = 1;
                }
            }

            if (cboComprobantes.SelectedItem.Value != "Seleccione")
            {
                if (aux == 1)
                {
                    strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes.SelectedItem.ToString() + "'";
                }
                else
                {
                    strConsulta = strConsulta + " @comprobante = '" + cboComprobantes.SelectedItem.ToString() + "'";
                    aux = 1;
                }
            }

            int auxCuentas = 0;
            string cuentas = "";
            for (int i = 0; i < chkCuentas.Items.Count; i++)
            {
                if (chkCuentas.Items[i].Selected)
                {
                    if (auxCuentas == 0)
                    {
                        cuentas = " CodigoCuenta = " + chkCuentas.Items[i].Value + "";
                        auxCuentas = 1;
                    }
                    else
                    {
                        cuentas = cuentas + " or CodigoCuenta = " + chkCuentas.Items[i].Value + "";
                    }
                }

            }

            if (auxCuentas == 1)
            {
                if (aux == 1)
                {
                    strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

                }
                else
                {

                    strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
                    aux = 1;
                }
            }

            dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


            Session["CuentasPredeterminadas"] = dtDatos;

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            cargarDatos1();
            Response.Redirect("~/PruebasAutoTabla1/listadoCuentasDeterminadas.aspx");
        }

        #endregion

        //#region Cuentas con saldo sin movimiento


        //protected void btnDesmarcar_Click2(object sender, EventArgs e)
        //{
        //    chkCuentas2.ClearSelection();
        //}

        //protected void cargarCuentas2()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta, CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas2.Items.Clear();

        //    chkCuentas2.DataTextField = "CuentaDescripcion";

        //    chkCuentas2.DataValueField = "CodigoCuenta";

        //    chkCuentas2.DataSource = dtCuentas;

        //    chkCuentas2.DataBind();

        //}

        //protected void cargarComprobantes2()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes2.Items.Clear();

        //    cboComprobantes2.DataTextField = "CodigoComprobante";

        //    cboComprobantes2.DataValueField = "CodigoComprobante";

        //    cboComprobantes2.DataSource = dtComprobantes;

        //    cboComprobantes2.DataBind();

        //    cboComprobantes2.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos2()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_SaldoSinMovimiento ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde2.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde2.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde2.Text + "'";
        //            aux = 1;
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(txtFechaHasta2.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta2.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta2.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes2.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes2.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes2.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas2.Items.Count; i++)
        //    {
        //        if (chkCuentas2.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas2.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas2.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["CuentasSaldoSinMovimiento"] = dtDatos;


        //}

        //protected void btnFiltrar_Click2(object sender, EventArgs e)
        //{
        //    cargarDatos2();
        //    Response.Redirect("~/PruebasAutoTabla1/cuentaConSaldoSinMovimiento.aspx");
        //}


        //#endregion

        //#region Cuentas con movimientos de saldo cero


        //protected void btnDesmarcar_Click3(object sender, EventArgs e)
        //{
        //    chkCuentas3.ClearSelection();
        //}

        //protected void cargarCuentas3()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas3.Items.Clear();

        //    chkCuentas3.DataTextField = "CuentaDescripcion";

        //    chkCuentas3.DataValueField = "CodigoCuenta";

        //    chkCuentas3.DataSource = dtCuentas;

        //    chkCuentas3.DataBind();

        //}

        //protected void cargarComprobantes3()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes3.Items.Clear();

        //    cboComprobantes3.DataTextField = "CodigoComprobante";

        //    cboComprobantes3.DataValueField = "CodigoComprobante";

        //    cboComprobantes3.DataSource = dtComprobantes;

        //    cboComprobantes3.DataBind();

        //    cboComprobantes3.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos3()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_CuentaConMovimientoSaldoCero ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde3.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde3.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde3.Text + "'";
        //            aux = 1;
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(txtFechaHasta3.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta3.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta3.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes3.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes3.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes3.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas3.Items.Count; i++)
        //    {
        //        if (chkCuentas3.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas3.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas3.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["CuentasSaldoCeroConMovimiento"] = dtDatos;


        //}

        //protected void btnFiltrar_Click3(object sender, EventArgs e)
        //{
        //    cargarDatos3();
        //    Response.Redirect("~/PruebasAutoTabla1/cuentaMovimientoSaldoCero.aspx");
        //}

        //#endregion

        //#region CuentasConUsoMinimoPeroSignificativo

        //protected void btnDesmarcar_Click4(object sender, EventArgs e)
        //{
        //    chkCuentas4.ClearSelection();
        //}

        //protected void cargarCuentas4()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas4.Items.Clear();

        //    chkCuentas4.DataTextField = "CuentaDescripcion";

        //    chkCuentas4.DataValueField = "CodigoCuenta";

        //    chkCuentas4.DataSource = dtCuentas;

        //    chkCuentas4.DataBind();

        //}

        //protected void cargarComprobantes4()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes4.Items.Clear();

        //    cboComprobantes4.DataTextField = "CodigoComprobante";

        //    cboComprobantes4.DataValueField = "CodigoComprobante";

        //    cboComprobantes4.DataSource = dtComprobantes;

        //    cboComprobantes4.DataBind();

        //    cboComprobantes4.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos4()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_CuentaUsoMinimo ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde4.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde4.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde4.Text + "'";
        //            aux = 1;
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(txtFechaHasta4.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta4.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta4.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes4.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes4.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes4.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas4.Items.Count; i++)
        //    {
        //        if (chkCuentas4.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas4.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas4.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["CuentasUsoMinimoPeroSignificativo"] = dtDatos;

        //}

        //protected void btnFiltrar_Click4(object sender, EventArgs e)
        //{
        //    cargarDatos4();
        //    Response.Redirect("~/PruebasAutoTabla1/usoMinimoPeroSignificativo.aspx");
        //}

        //#endregion

        //#region Cuentas mas imputadas

        //protected void btnDesmarcar_Click5(object sender, EventArgs e)
        //{
        //    chkCuentas5.ClearSelection();
        //}

        //protected void cargarCuentas5()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas5.Items.Clear();

        //    chkCuentas5.DataTextField = "CuentaDescripcion";

        //    chkCuentas5.DataValueField = "CodigoCuenta";

        //    chkCuentas5.DataSource = dtCuentas;

        //    chkCuentas5.DataBind();

        //}

        //protected void cargarComprobantes5()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes5.Items.Clear();

        //    cboComprobantes5.DataTextField = "CodigoComprobante";

        //    cboComprobantes5.DataValueField = "CodigoComprobante";

        //    cboComprobantes5.DataSource = dtComprobantes;

        //    cboComprobantes5.DataBind();

        //    cboComprobantes5.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos5()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_CuentasMasImputadas ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde5.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde5.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde5.Text + "'";
        //            aux = 1;
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(txtFechaHasta5.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta5.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta5.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes5.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes5.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes5.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas5.Items.Count; i++)
        //    {
        //        if (chkCuentas5.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas5.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas5.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["CuentasMasImputadas"] = dtDatos;

        //}

        //protected void btnFiltrar_Click5(object sender, EventArgs e)
        //{
        //    cargarDatos5();
        //    Response.Redirect("~/PruebasAutoTabla1/cuentasMasImputadas.aspx");
        //}

        //#endregion

        //#region Ingresos y egresos de asientos diarios

        //protected void btnDesmarcar_Click6(object sender, EventArgs e)
        //{
        //    chkCuentas6.ClearSelection();
        //}

        //protected void cargarCuentas6()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas6.Items.Clear();

        //    chkCuentas6.DataTextField = "CuentaDescripcion";

        //    chkCuentas6.DataValueField = "CodigoCuenta";

        //    chkCuentas6.DataSource = dtCuentas;

        //    chkCuentas6.DataBind();

        //}

        //protected void cargarComprobantes6()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes6.Items.Clear();

        //    cboComprobantes6.DataTextField = "CodigoComprobante";

        //    cboComprobantes6.DataValueField = "CodigoComprobante";

        //    cboComprobantes6.DataSource = dtComprobantes;

        //    cboComprobantes6.DataBind();

        //    cboComprobantes6.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos6()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_CuentasMasImputadas ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde6.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde6.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde6.Text + "'";
        //            aux = 1;
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(txtFechaHasta6.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta6.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta6.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes6.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes6.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes6.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas6.Items.Count; i++)
        //    {
        //        if (chkCuentas6.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas6.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas6.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["IngresosEgresosAsientosDiarios"] = dtDatos;

        //}

        //protected void btnFiltrar_Click6(object sender, EventArgs e)
        //{
        //    cargarDatos6();
        //    Response.Redirect("~/PruebasAutoTabla1/AsientosConMayoresMontos.aspx");
        //}

        //#endregion

        //#region Cuentas con importes redondos

        //protected void btnDesmarcar_Click7(object sender, EventArgs e)
        //{
        //    chkCuentas7.ClearSelection();
        //}

        //protected void cargarCuentas7()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas7.Items.Clear();

        //    chkCuentas7.DataTextField = "CuentaDescripcion";

        //    chkCuentas7.DataValueField = "CodigoCuenta";

        //    chkCuentas7.DataSource = dtCuentas;

        //    chkCuentas7.DataBind();

        //}

        //protected void cargarComprobantes7()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes7.Items.Clear();

        //    cboComprobantes7.DataTextField = "CodigoComprobante";

        //    cboComprobantes7.DataValueField = "CodigoComprobante";

        //    cboComprobantes7.DataSource = dtComprobantes;

        //    cboComprobantes7.DataBind();

        //    cboComprobantes7.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos7()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_ImportesRedondos ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde7.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde7.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde7.Text + "'";
        //            aux = 1;
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(txtFechaHasta7.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta7.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta7.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes7.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes7.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes7.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas7.Items.Count; i++)
        //    {
        //        if (chkCuentas7.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas7.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas7.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["ImportesRedondos"] = dtDatos;

        //}

        //protected void btnFiltrar_Click7(object sender, EventArgs e)
        //{
        //    cargarDatos7();
        //    Response.Redirect("~/PruebasAutoTabla1/MontosRedondos.aspx");
        //}

        //#endregion

        //#region Importes finalizados en 99


        //protected void btnDesmarcar_Click8(object sender, EventArgs e)
        //{
        //    chkCuentas8.ClearSelection();
        //}

        //protected void cargarCuentas8()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas8.Items.Clear();

        //    chkCuentas8.DataTextField = "CuentaDescripcion";

        //    chkCuentas8.DataValueField = "CodigoCuenta";

        //    chkCuentas8.DataSource = dtCuentas;

        //    chkCuentas8.DataBind();

        //}

        //protected void cargarComprobantes8()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes8.Items.Clear();

        //    cboComprobantes8.DataTextField = "CodigoComprobante";

        //    cboComprobantes8.DataValueField = "CodigoComprobante";

        //    cboComprobantes8.DataSource = dtComprobantes;

        //    cboComprobantes8.DataBind();

        //    cboComprobantes8.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos8()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_Importes99 ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde8.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde8.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde8.Text + "'";
        //            aux = 1;
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(txtFechaHasta8.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta8.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta8.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes8.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes8.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes8.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas8.Items.Count; i++)
        //    {
        //        if (chkCuentas8.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas8.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas8.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["Finalizados99"] = dtDatos;

        //}

        //protected void btnFiltrar_Click8(object sender, EventArgs e)
        //{
        //    cargarDatos8();
        //    Response.Redirect("~/PruebasAutoTabla1/Finalizados99.aspx");
        //}


        //#endregion

        //#region Asientos que no balanceean

        //#endregion

        //#region Valores inusuales

        //#endregion

        //#region Top Ten Valores mas altos

        //protected void btnDesmarcar_Click11(object sender, EventArgs e)
        //{
        //    chkCuentas11.ClearSelection();
        //}

        //protected void cargarCuentas11()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas11.Items.Clear();

        //    chkCuentas11.DataTextField = "CuentaDescripcion";

        //    chkCuentas11.DataValueField = "CodigoCuenta";

        //    chkCuentas11.DataSource = dtCuentas;

        //    chkCuentas11.DataBind();

        //}

        //protected void cargarComprobantes11()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes11.Items.Clear();

        //    cboComprobantes11.DataTextField = "CodigoComprobante";

        //    cboComprobantes11.DataValueField = "CodigoComprobante";

        //    cboComprobantes11.DataSource = dtComprobantes;

        //    cboComprobantes11.DataBind();

        //    cboComprobantes11.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos11()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_TopTen ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde11.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde11.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde11.Text + "'";
        //            aux = 1;
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(txtFechaHasta11.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta11.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta11.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes11.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes11.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes11.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas11.Items.Count; i++)
        //    {
        //        if (chkCuentas11.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas11.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas11.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["TopTenValoresAltos"] = dtDatos;

        //}

        //protected void btnFiltrar_Click11(object sender, EventArgs e)
        //{
        //    cargarDatos11();
        //    Response.Redirect("~/PruebasAutoTabla1/TopTenValoresAltos.aspx");
        //}

        //#endregion

        //#region Valores menores a un parametro limite


        //protected void btnDesmarcar_Click12(object sender, EventArgs e)
        //{
        //    chkCuentas12.ClearSelection();
        //}

        //protected void cargarCuentas12()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta, CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas12.Items.Clear();

        //    chkCuentas12.DataTextField = "CuentaDescripcion";

        //    chkCuentas12.DataValueField = "CodigoCuenta";

        //    chkCuentas12.DataSource = dtCuentas;

        //    chkCuentas12.DataBind();

        //}

        //protected void cargarComprobantes12()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes12.Items.Clear();

        //    cboComprobantes12.DataTextField = "CodigoComprobante";

        //    cboComprobantes12.DataValueField = "CodigoComprobante";

        //    cboComprobantes12.DataSource = dtComprobantes;

        //    cboComprobantes12.DataBind();

        //    cboComprobantes12.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos12()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_ValoresMenoresParametro ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde12.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde12.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde12.Text + "'";
        //            aux = 1;
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(txtFechaHasta12.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta12.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta12.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes12.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes12.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes12.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (!String.IsNullOrEmpty(txtLimite.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @limite = '" + txtLimite.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @limite = '" + txtLimite.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas12.Items.Count; i++)
        //    {
        //        if (chkCuentas12.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas12.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas12.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["ValoresParametroLimite"] = dtDatos;

        //}

        //protected void btnFiltrar_Click12(object sender, EventArgs e)
        //{
        //    cargarDatos12();
        //    Response.Redirect("~/PruebasAutoTabla1/valoresMenoresAunParametro.aspx");
        //}

        //#endregion

        //#region Horas no habituales que se efectuan las transacciones


        ////protected void btnDesmarcar_Click14(object sender, EventArgs e)
        ////{
        ////    chkCuentas14.ClearSelection();
        ////}

        ////protected void cargarCuentas14()
        ////{
        ////    DataTable dtCuentas = null;

        ////    string strConsulta = "select distinct CodigoCuenta from Mayorizacion3 order by CodigoCuenta asc";

        ////    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        ////    chkCuentas14.Items.Clear();

        ////    chkCuentas14.DataTextField = "CodigoCuenta";

        ////    chkCuentas14.DataValueField = "CodigoCuenta";

        ////    chkCuentas14.DataSource = dtCuentas;

        ////    chkCuentas14.DataBind();

        ////}

        ////protected void cargarComprobantes14()
        ////{
        ////    DataTable dtComprobantes = null;

        ////    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        ////    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        ////    cboComprobantes14.Items.Clear();

        ////    cboComprobantes14.DataTextField = "CodigoComprobante";

        ////    cboComprobantes14.DataValueField = "CodigoComprobante";

        ////    cboComprobantes14.DataSource = dtComprobantes;

        ////    cboComprobantes14.DataBind();

        ////    cboComprobantes14.Items.Insert(0, "Seleccione");
        ////}

        ////protected void cargarDatos14()
        ////{
        ////    int aux = 0;

        ////    DataTable dtDatos = null;

        ////    string strConsulta = " exec SP_TABLA1_Mostrar_TopTen ";


        ////    if (!String.IsNullOrEmpty(txtFechaDesde11.Text))
        ////    {
        ////        if (aux == 1)
        ////        {
        ////            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde11.Text + "'";
        ////        }
        ////        else
        ////        {
        ////            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde11.Text + "'";
        ////            aux = 1;
        ////        }
        ////    }
        ////    if (!String.IsNullOrEmpty(txtFechaHasta11.Text))
        ////    {
        ////        if (aux == 1)
        ////        {
        ////            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta11.Text + "'";
        ////        }
        ////        else
        ////        {
        ////            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta11.Text + "'";
        ////            aux = 1;
        ////        }
        ////    }

        ////    if (cboComprobantes11.SelectedItem.Value != "Seleccione")
        ////    {
        ////        if (aux == 1)
        ////        {
        ////            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes11.SelectedItem.ToString() + "'";
        ////        }
        ////        else
        ////        {
        ////            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes11.SelectedItem.ToString() + "'";
        ////            aux = 1;
        ////        }
        ////    }

        ////    int auxCuentas = 0;
        ////    string cuentas = "";
        ////    for (int i = 0; i < chkCuentas11.Items.Count; i++)
        ////    {
        ////        if (chkCuentas11.Items[i].Selected)
        ////        {
        ////            if (auxCuentas == 0)
        ////            {
        ////                cuentas = " CodigoCuenta = " + chkCuentas11.Items[i].Value + "";
        ////                auxCuentas = 1;
        ////            }
        ////            else
        ////            {
        ////                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas11.Items[i].Value + "";
        ////            }
        ////        }

        ////    }

        ////    if (auxCuentas == 1)
        ////    {
        ////        if (aux == 1)
        ////        {
        ////            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        ////        }
        ////        else
        ////        {

        ////            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        ////            aux = 1;
        ////        }
        ////    }

        ////    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        ////    Session["TopTenValoresAltos"] = dtDatos;

        ////}

        ////protected void btnFiltrar_Click11(object sender, EventArgs e)
        ////{
        ////    cargarDatos11();
        ////    Response.Redirect("~/PruebasAutoTabla1/TopTenValoresAltos.aspx");
        ////}



        //#endregion

        //#region Dias no hanbituales


        //protected void btnDesmarcar_Click15(object sender, EventArgs e)
        //{
        //    chkCuentas15.ClearSelection();
        //}

        //protected void cargarCuentas15()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas15.Items.Clear();

        //    chkCuentas15.DataTextField = "CuentaDescripcion";

        //    chkCuentas15.DataValueField = "CodigoCuenta";

        //    chkCuentas15.DataSource = dtCuentas;

        //    chkCuentas15.DataBind();

        //}

        //protected void cargarComprobantes15()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes15.Items.Clear();

        //    cboComprobantes15.DataTextField = "CodigoComprobante";

        //    cboComprobantes15.DataValueField = "CodigoComprobante";

        //    cboComprobantes15.DataSource = dtComprobantes;

        //    cboComprobantes15.DataBind();

        //    cboComprobantes15.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos15()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_DiasNoHabituales ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde15.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde15.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde15.Text + "'";
        //            aux = 1;
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(txtFechaHasta15.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta15.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta15.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes15.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes15.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes15.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas15.Items.Count; i++)
        //    {
        //        if (chkCuentas15.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas15.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas15.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["DiasNoHabituales"] = dtDatos;

        //}

        //protected void btnFiltrar_Click15(object sender, EventArgs e)
        //{
        //    cargarDatos15();
        //    Response.Redirect("~/PruebasAutoTabla1/DiasNoHabituales.aspx");
        //}


        //#endregion

        //#region Transacciones efectuadas en dias no laborables


        //protected void btnDesmarcar_Click16(object sender, EventArgs e)
        //{
        //    chkCuentas16.ClearSelection();
        //}

        //protected void cargarCuentas16()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas16.Items.Clear();

        //    chkCuentas16.DataTextField = "CodigoCuenta";

        //    chkCuentas16.DataValueField = "CodigoCuenta";

        //    chkCuentas16.DataSource = dtCuentas;

        //    chkCuentas16.DataBind();

        //}

        //protected void cargarComprobantes16()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes16.Items.Clear();

        //    cboComprobantes16.DataTextField = "CodigoComprobante";

        //    cboComprobantes16.DataValueField = "CodigoComprobante";

        //    cboComprobantes16.DataSource = dtComprobantes;

        //    cboComprobantes16.DataBind();

        //    cboComprobantes16.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos16()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_DiasNoLaborables ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde16.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde16.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde16.Text + "'";
        //            aux = 1;
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(txtFechaHasta16.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta16.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta16.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes16.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes16.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes16.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas16.Items.Count; i++)
        //    {
        //        if (chkCuentas16.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas16.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas16.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["DiasNoLaborables"] = dtDatos;

        //}

        //protected void btnFiltrar_Click16(object sender, EventArgs e)
        //{
        //    cargarDatos16();
        //    Response.Redirect("~/PruebasAutoTabla1/DiasNoLaborables.aspx");
        //}

        //#endregion



        //#region Fechas cercanas al cierre


        //protected void btnDesmarcar_Click17(object sender, EventArgs e)
        //{
        //    chkCuentas17.ClearSelection();
        //}

        //protected void cargarCuentas17()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas17.Items.Clear();

        //    chkCuentas17.DataTextField = "CuentaDescripcion";

        //    chkCuentas17.DataValueField = "CodigoCuenta";

        //    chkCuentas17.DataSource = dtCuentas;

        //    chkCuentas17.DataBind();

        //}

        //protected void cargarComprobantes17()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes17.Items.Clear();

        //    cboComprobantes17.DataTextField = "CodigoComprobante";

        //    cboComprobantes17.DataValueField = "CodigoComprobante";

        //    cboComprobantes17.DataSource = dtComprobantes;

        //    cboComprobantes17.DataBind();

        //    cboComprobantes17.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos17()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_FechasCercanasAlCierre ";


        //    if (!String.IsNullOrEmpty(txtFecha.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFecha.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFecha.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes17.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes17.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes17.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas16.Items.Count; i++)
        //    {
        //        if (chkCuentas17.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas17.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas17.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["FechasCercanasAlCierre"] = dtDatos;

        //}

        //protected void btnFiltrar_Click17(object sender, EventArgs e)
        //{
        //    cargarDatos17();
        //    Response.Redirect("~/PruebasAutoTabla1/FechasCercanasAlCierre.aspx");
        //}


        //#endregion


        //#region Transacciones hechas con distinta fechas de carga

        //protected void btnDesmarcar_Click18(object sender, EventArgs e)
        //{
        //    chkCuentas18.ClearSelection();
        //}

        //protected void cargarCuentas18()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas18.Items.Clear();

        //    chkCuentas18.DataTextField = "CuentaDescripcion";

        //    chkCuentas18.DataValueField = "CodigoCuenta";

        //    chkCuentas18.DataSource = dtCuentas;

        //    chkCuentas18.DataBind();

        //}

        //protected void cargarComprobantes18()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes18.Items.Clear();

        //    cboComprobantes18.DataTextField = "CodigoComprobante";

        //    cboComprobantes18.DataValueField = "CodigoComprobante";

        //    cboComprobantes18.DataSource = dtComprobantes;

        //    cboComprobantes18.DataBind();

        //    cboComprobantes18.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos18()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_FechasCercanasAlCierre ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde18.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde18.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde18.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (!String.IsNullOrEmpty(txtFechaDesde18.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde18.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde18.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes18.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes18.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes18.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas18.Items.Count; i++)
        //    {
        //        if (chkCuentas17.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas18.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas18.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["FechasCercanasAlCierre"] = dtDatos;

        //}

        //protected void btnFiltrar_Click18(object sender, EventArgs e)
        //{
        //    cargarDatos18();
        //    Response.Redirect("~/PruebasAutoTabla1/FechasCercanasAlCierre.aspx");
        //}


        //#endregion


        //#region Durante un periodo determinado


        //protected void btnDesmarcar_Click19(object sender, EventArgs e)
        //{
        //    chkCuentas19.ClearSelection();
        //}


        //protected void cargarCuentas19()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas19.Items.Clear();

        //    chkCuentas19.DataTextField = "CuentaDescripcion";

        //    chkCuentas19.DataValueField = "CodigoCuenta";

        //    chkCuentas19.DataSource = dtCuentas;

        //    chkCuentas19.DataBind();

        //}

        //protected void cargarComprobantes19()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes19.Items.Clear();

        //    cboComprobantes19.DataTextField = "CodigoComprobante";

        //    cboComprobantes19.DataValueField = "CodigoComprobante";

        //    cboComprobantes19.DataSource = dtComprobantes;

        //    cboComprobantes19.DataBind();

        //    cboComprobantes19.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos19()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_TransaccionesPorUsuario ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde20.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde20.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde20.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (!String.IsNullOrEmpty(txtFechaHasta20.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta20.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta20.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes20.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes20.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes20.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas20.Items.Count; i++)
        //    {
        //        if (chkCuentas20.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas20.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas20.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["TransaccionPorUsuario"] = dtDatos;

        //}

        //protected void btnFiltrar_Click19(object sender, EventArgs e)
        //{
        //    cargarDatos19();
        //    Response.Redirect("~/PruebasAutoTabla1/PeriodoDeterminado.aspx");
        //}

        //#endregion

        //#region Total Transacciones por usuario

        //protected void btnDesmarcar_Click20(object sender, EventArgs e)
        //{
        //    chkCuentas20.ClearSelection();
        //}


        //protected void cargarCuentas20()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas20.Items.Clear();

        //    chkCuentas20.DataTextField = "CuentaDescripcion";

        //    chkCuentas20.DataValueField = "CodigoCuenta";

        //    chkCuentas20.DataSource = dtCuentas;

        //    chkCuentas20.DataBind();

        //}

        //protected void cargarComprobantes20()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes20.Items.Clear();

        //    cboComprobantes20.DataTextField = "CodigoComprobante";

        //    cboComprobantes20.DataValueField = "CodigoComprobante";

        //    cboComprobantes20.DataSource = dtComprobantes;

        //    cboComprobantes20.DataBind();

        //    cboComprobantes20.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos20()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_TransaccionesPorUsuario ";


        //    if (!String.IsNullOrEmpty(txtFechaDesde20.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde20.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde20.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (!String.IsNullOrEmpty(txtFechaHasta20.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta20.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta20.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes20.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes20.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes20.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas20.Items.Count; i++)
        //    {
        //        if (chkCuentas20.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas20.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas20.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["TransaccionPorUsuario"] = dtDatos;

        //}

        //protected void btnFiltrar_Click20(object sender, EventArgs e)
        //{
        //    cargarDatos20();
        //    Response.Redirect("~/PruebasAutoTabla1/TotalTransaccionesPorUsuario.aspx");
        //}


        //#endregion



        //#region Transaccione hechas por usuario nuevos

        //protected void btnDesmarcar_Click21(object sender, EventArgs e)
        //{
        //    chkCuentas21.ClearSelection();
        //}


        //protected void cargarCuentas21()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas21.Items.Clear();

        //    chkCuentas21.DataTextField = "CuentaDescripcion";

        //    chkCuentas21.DataValueField = "CodigoCuenta";

        //    chkCuentas21.DataSource = dtCuentas;

        //    chkCuentas21.DataBind();

        //}

        //protected void cargarComprobantes21()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes21.Items.Clear();

        //    cboComprobantes21.DataTextField = "CodigoComprobante";

        //    cboComprobantes21.DataValueField = "CodigoComprobante";

        //    cboComprobantes21.DataSource = dtComprobantes;

        //    cboComprobantes21.DataBind();

        //    cboComprobantes21.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos21()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_TransaccionesUsuarioNuevo";


        //    if (!String.IsNullOrEmpty(txtFechaDesde21.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde21.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde21.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (!String.IsNullOrEmpty(txtFechaHasta21.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta21.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta21.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes21.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes21.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes21.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas21.Items.Count; i++)
        //    {
        //        if (chkCuentas21.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas21.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas21.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["TransaccionPorUsuarioNuevo"] = dtDatos;

        //}

        //protected void btnFiltrar_Click21(object sender, EventArgs e)
        //{
        //    cargarDatos21();
        //    Response.Redirect("~/PruebasAutoTabla1/TransaccionesPorUsuarioNuevo.aspx");
        //}

        //#endregion


        //#region Transacciones por usuarios que no corresponde al sector

        //protected void btnDesmarcar_Click22(object sender, EventArgs e)
        //{
        //    chkCuentas22.ClearSelection();
        //}


        //protected void cargarCuentas22()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta, CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas22.Items.Clear();

        //    chkCuentas22.DataTextField = "CuentaDescripcion";

        //    chkCuentas22.DataValueField = "CodigoCuenta";

        //    chkCuentas22.DataSource = dtCuentas;

        //    chkCuentas22.DataBind();

        //}

        //protected void cargarComprobantes22()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes22.Items.Clear();

        //    cboComprobantes22.DataTextField = "CodigoComprobante";

        //    cboComprobantes22.DataValueField = "CodigoComprobante";

        //    cboComprobantes22.DataSource = dtComprobantes;

        //    cboComprobantes22.DataBind();

        //    cboComprobantes22.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos22()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_TransaccionesUsuarioNoCorrrespondeArea";


        //    if (!String.IsNullOrEmpty(txtFechaDesde22.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde22.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde22.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (!String.IsNullOrEmpty(txtFechaHasta22.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta22.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta22.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes22.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes22.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes22.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas22.Items.Count; i++)
        //    {
        //        if (chkCuentas22.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas22.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas22.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["TransaccionPorUsuarioNoCorrespondeAlArea"] = dtDatos;

        //}

        //protected void btnFiltrar_Click22(object sender, EventArgs e)
        //{
        //    cargarDatos22();
        //    Response.Redirect("~/PruebasAutoTabla1/NoCorrespondeSectorUsuario.aspx");
        //}

        //#endregion


        //#region Repeticiones por montos

        //protected void btnDesmarcar_Click23(object sender, EventArgs e)
        //{
        //    chkCuentas23.ClearSelection();
        //}


        //protected void cargarCuentas23()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta,CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas23.Items.Clear();

        //    chkCuentas23.DataTextField = "CuentaDescripcion";

        //    chkCuentas23.DataValueField = "CodigoCuenta";

        //    chkCuentas23.DataSource = dtCuentas;

        //    chkCuentas23.DataBind();

        //}

        //protected void cargarComprobantes23()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes23.Items.Clear();

        //    cboComprobantes23.DataTextField = "CodigoComprobante";

        //    cboComprobantes23.DataValueField = "CodigoComprobante";

        //    cboComprobantes23.DataSource = dtComprobantes;

        //    cboComprobantes23.DataBind();

        //    cboComprobantes23.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos23()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_RepeticionesMonto";


        //    if (!String.IsNullOrEmpty(txtFechaDesde23.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde23.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde23.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (!String.IsNullOrEmpty(txtFechaHasta23.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta23.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta23.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes23.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes23.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes23.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas23.Items.Count; i++)
        //    {
        //        if (chkCuentas23.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas23.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas23.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["RepeticionesPorMontos"] = dtDatos;

        //}

        //protected void btnFiltrar_Click23(object sender, EventArgs e)
        //{
        //    cargarDatos23();
        //    Response.Redirect("~/PruebasAutoTabla1/cantidadRepeticionesPorMontos.aspx");
        //}

        //#endregion


        //#region Histograma de cuentas

        //protected void btnDesmarcar_Click24(object sender, EventArgs e)
        //{
        //    chkCuentas24.ClearSelection();
        //}


        //protected void cargarCuentas24()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta, CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas24.Items.Clear();

        //    chkCuentas24.DataTextField = "CuentaDescripcion";

        //    chkCuentas24.DataValueField = "CodigoCuenta";

        //    chkCuentas24.DataSource = dtCuentas;

        //    chkCuentas24.DataBind();

        //}

        //protected void cargarComprobantes24()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes24.Items.Clear();

        //    cboComprobantes24.DataTextField = "CodigoComprobante";

        //    cboComprobantes24.DataValueField = "CodigoComprobante";

        //    cboComprobantes24.DataSource = dtComprobantes;

        //    cboComprobantes24.DataBind();

        //    cboComprobantes24.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos24()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_HistogramaUsoCuentas";


        //    if (!String.IsNullOrEmpty(txtFechaDesde24.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde24.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde24.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (!String.IsNullOrEmpty(txtFechaHasta24.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta24.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta24.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes24.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes24.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes24.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas24.Items.Count; i++)
        //    {
        //        if (chkCuentas24.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas24.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas24.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["HistogramaDeCuentas"] = dtDatos;

        //}

        //protected void btnFiltrar_Click24(object sender, EventArgs e)
        //{
        //    cargarDatos24();
        //    Response.Redirect("~/PruebasAutoTabla1/HistogramaUsoDeCuentas.aspx");
        //}


        //#endregion


        //#region Transacciones sin descripcion



        //protected void btnDesmarcar_Click25(object sender, EventArgs e)
        //{
        //    chkCuentas25.ClearSelection();
        //}


        //protected void cargarCuentas25()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta, CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas25.Items.Clear();

        //    chkCuentas25.DataTextField = "CuentaDescripcion";

        //    chkCuentas25.DataValueField = "CodigoCuenta";

        //    chkCuentas25.DataSource = dtCuentas;

        //    chkCuentas25.DataBind();

        //}

        //protected void cargarComprobantes25()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes25.Items.Clear();

        //    cboComprobantes25.DataTextField = "CodigoComprobante";

        //    cboComprobantes25.DataValueField = "CodigoComprobante";

        //    cboComprobantes25.DataSource = dtComprobantes;

        //    cboComprobantes25.DataBind();

        //    cboComprobantes25.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos25()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_SinDescripcion";


        //    if (!String.IsNullOrEmpty(txtFechaDesde25.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde25.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde25.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (!String.IsNullOrEmpty(txtFechaHasta25.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta25.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta25.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes25.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes25.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes25.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas25.Items.Count; i++)
        //    {
        //        if (chkCuentas25.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas25.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas25.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["TransaccionesSinDescripcion"] = dtDatos;

        //}

        //protected void btnFiltrar_Click25(object sender, EventArgs e)
        //{
        //    cargarDatos25();
        //    Response.Redirect("~/PruebasAutoTabla1/TransaccionesSinDescripcion.aspx");
        //}


        //#endregion


        //#region Transacciones con poca descripcion


        //protected void btnDesmarcar_Click26(object sender, EventArgs e)
        //{
        //    chkCuentas26.ClearSelection();
        //}
        //protected void cargarCuentas26()
        //{
        //    DataTable dtCuentas = null;

        //    string strConsulta = "select distinct CodigoCuenta, CuentaDescripcion from Mayorizacion3 order by CuentaDescripcion asc";

        //    dtCuentas = Conexion.llenarGridFromConsulta(strConsulta);

        //    chkCuentas26.Items.Clear();

        //    chkCuentas26.DataTextField = "CuentaDescripcion";

        //    chkCuentas26.DataValueField = "CodigoCuenta";

        //    chkCuentas26.DataSource = dtCuentas;

        //    chkCuentas26.DataBind();

        //}

        //protected void cargarComprobantes26()
        //{
        //    DataTable dtComprobantes = null;

        //    string strConsulta = "select distinct CodigoComprobante from Mayorizacion3 order by CodigoComprobante asc";

        //    dtComprobantes = Conexion.llenarGridFromConsulta(strConsulta);

        //    cboComprobantes26.Items.Clear();

        //    cboComprobantes26.DataTextField = "CodigoComprobante";

        //    cboComprobantes26.DataValueField = "CodigoComprobante";

        //    cboComprobantes26.DataSource = dtComprobantes;

        //    cboComprobantes26.DataBind();

        //    cboComprobantes26.Items.Insert(0, "Seleccione");
        //}

        //protected void cargarDatos26()
        //{
        //    int aux = 0;

        //    DataTable dtDatos = null;

        //    string strConsulta = " exec SP_TABLA1_Mostrar_PocaDescripcion";


        //    if (!String.IsNullOrEmpty(txtFechaDesde26.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaDesde = '" + txtFechaDesde26.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaDesde = '" + txtFechaDesde26.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (!String.IsNullOrEmpty(txtFechaHasta26.Text))
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @fechaHasta = '" + txtFechaHasta26.Text + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @fechaHasta = '" + txtFechaHasta26.Text + "'";
        //            aux = 1;
        //        }
        //    }

        //    if (cboComprobantes26.SelectedItem.Value != "Seleccione")
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @comprobante = '" + cboComprobantes26.SelectedItem.ToString() + "'";
        //        }
        //        else
        //        {
        //            strConsulta = strConsulta + " @comprobante = '" + cboComprobantes26.SelectedItem.ToString() + "'";
        //            aux = 1;
        //        }
        //    }

        //    int auxCuentas = 0;
        //    string cuentas = "";
        //    for (int i = 0; i < chkCuentas26.Items.Count; i++)
        //    {
        //        if (chkCuentas26.Items[i].Selected)
        //        {
        //            if (auxCuentas == 0)
        //            {
        //                cuentas = " CodigoCuenta = " + chkCuentas26.Items[i].Value + "";
        //                auxCuentas = 1;
        //            }
        //            else
        //            {
        //                cuentas = cuentas + " or CodigoCuenta = " + chkCuentas26.Items[i].Value + "";
        //            }
        //        }

        //    }

        //    if (auxCuentas == 1)
        //    {
        //        if (aux == 1)
        //        {
        //            strConsulta = strConsulta + ", @cuenta = '" + cuentas + "'";

        //        }
        //        else
        //        {

        //            strConsulta = strConsulta + " @cuenta = '" + cuentas + "'";
        //            aux = 1;
        //        }
        //    }

        //    dtDatos = Conexion.llenarGridFromConsulta(strConsulta);


        //    Session["TransaccionesPocaDescripcion"] = dtDatos;

        //}

        //protected void btnFiltrar_Click26(object sender, EventArgs e)
        //{
        //    cargarDatos26();
        //    Response.Redirect("~/PruebasAutoTabla1/TransaccionPocaDescripcion.aspx");
        //}



        //#endregion

    }
}