using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Reflection;



/// <summary>
/// Esta clase provee metodos de utilidad para las tareas basicas de la aplicacion.
/// </summary>
/// <author> Sandra Lucia Rodríguez</author>
public class Utils
{
    /// <summary>
    ///  Constructor de la clase utils 
    /// </summary>
    public Utils()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void ChangeTimeout(Component component, int timeout)
    {
        if (!component.GetType().Name.Contains("TableAdapter"))
        {
            return;
        }

        PropertyInfo adapterProp = component.GetType().GetProperty("CommandCollection", BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.Instance);
        if (adapterProp == null)
        {
            return;
        }

        System.Data.SqlClient.SqlCommand[] command = adapterProp.GetValue(component, null) as System.Data.SqlClient.SqlCommand[];

        if (command == null)
        {
            return;
        }

        command[0].CommandTimeout = timeout;
    }

    /// <summary>
    /// Metodo encargado de registrar un script para que sea posible ejecutarlo.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="key"></param>
    /// <param name="scriptIn"></param>
    /// <param name="control"></param>
    public static void RegisterClientScriptBlock(System.Web.UI.Page page, String key, String scriptIn, Control control)
    {
        
        String script = "<script language='javascript'>";
        script += scriptIn;
        script += "</script>";

        if (control != null)
            ToolkitScriptManager.RegisterClientScriptBlock(control, page.GetType(), key, script, false);
        else
        page.ClientScript.RegisterClientScriptBlock(page.GetType(), key, script);
    }
    /// <summary>
    /// Esta clase obtiente la secuencia del identificador de una tabla pasada
    /// como parametro.
    /// </summary>
    /// <param name="tabla"></param>
    /// <returns></returns>
    public static int GetSequence(String tabla)
    {

     //   QueriesTableAdapter adapterQueries = new QueriesTableAdapter();
        //adapterQueries.FechaActualQuery();
       // Object obj = adapterQueries.SeqActividad();
        //if(tabla="ACTIVIDAD")
        //  return adapterQueries.SeqActividad();
        return 0;
    }
    
    /// <summary>
    /// Esta clase obtiente la fecha actual manejada por la base de datos
    /// </summary>
    /// <returns></returns>
    public static DateTime GetFechaActual()
    {

     //   QueriesTableAdapter adapterQueries = new QueriesTableAdapter();
        //adapterQueries.FechaActualQuery();

     //   Object obj = adapterQueries.FechaActualQuery();
        return new DateTime();
    }
    /// <summary>
    ///  Verifica si la fecha es "" y le asigna el valor null
    /// </summary>
    /// <param name="fecha"></param>
    public static String validarFecha(String fecha)
    {
        if (fecha.Equals(""))
            fecha = null;
        return fecha;        
    }
    /// <summary>
    ///  Carga un dropdownlist con los meses del año 
    /// </summary>
    /// <param name="fecha"></param>
    public static DropDownList meses(DropDownList meses)
    {
        
        meses.Items.Add(new System.Web.UI.WebControls.ListItem("Enero", "01"));
        meses.Items.Add(new System.Web.UI.WebControls.ListItem("Febrero", "02"));
        meses.Items.Add(new System.Web.UI.WebControls.ListItem("Marzo", "03"));
        meses.Items.Add(new System.Web.UI.WebControls.ListItem("Abril", "04"));
        meses.Items.Add(new System.Web.UI.WebControls.ListItem("Mayo", "05"));
        meses.Items.Add(new System.Web.UI.WebControls.ListItem("Junio", "06"));
        meses.Items.Add(new System.Web.UI.WebControls.ListItem("Julio", "07"));
        meses.Items.Add(new System.Web.UI.WebControls.ListItem("Agosto", "08"));
        meses.Items.Add(new System.Web.UI.WebControls.ListItem("Septiembre", "09"));
        meses.Items.Add(new System.Web.UI.WebControls.ListItem("Octubre", "10"));
        meses.Items.Add(new System.Web.UI.WebControls.ListItem("Noviembre", "11"));
        meses.Items.Add(new System.Web.UI.WebControls.ListItem("Diciembre", "12"));
        return meses;
    }
    /// <summary>
    ///  Carga un dropdownlist con los meses del año 
    /// </summary>
    /// <param name="fecha"></param>
    public static DropDownList anios(DropDownList anios)
    {

        for (int i = 2007; i <= DateTime.Now.Year; i++)
        {
            anios.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString()));
        }
        return anios;
    }

    /// <summary>
    ///  Verifica que la fecha inicial sea menor o igual que la fecha final
    /// </summary>
    /// <param name="anioInicial"></param>
    /// <param name="anioFinal"></param>
    /// <param name="mesInicial"></param>
    /// <param name="mesFinal"></param>
    /// 

    public static Boolean validarFecha(String anioInicial, String anioFinal, String mesInicial, String mesFinal)
    {
        int fechaInicial = int.Parse(anioInicial + mesInicial);
        int fechaFinal = int.Parse(anioFinal + mesFinal);
        if (fechaInicial <= fechaFinal)
            return true;
        else
            return false;
    }

    /// <summary>
    ///  Exporta a Excel un Gridview
    /// </summary>
    /// <param name="fecha"></param>
    /// 

    public static String exportToExcel(System.Web.UI.WebControls.GridView Resultados)
    {

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        Resultados.AllowPaging = false;
        HtmlForm frm = new HtmlForm();
        Resultados.Parent.Controls.Add(frm);
        frm.Attributes["runat"] = "server";
        Label titulo = new Label();
        Label space = new Label();
        titulo.Text = "Instituto Colombiano de Bienestar Familiar";
        frm.Controls.Add(titulo);       
        frm.Controls.Add(Resultados);
        frm.RenderControl(hw);
        return sw.ToString();
        

    }

   

    /// <summary>
    /// Reemplaza el estado de una entidad por habilitado o deshabilitado segun sea 0 o 1.
    /// </summary>
    /// <param name="estadoEliminado"></param>
    /// <param name="Eliminar"></param>
    /// <param name="eliminar"></param>
    public static void estadoItem(Label estadoEliminado, ImageButton Eliminar, LinkButton eliminar)
    {
        if ((estadoEliminado != null))
        {
            switch (estadoEliminado.Text.Trim())
            {
                case "1":
                    estadoEliminado.Text = "Deshabilitado";
                    if (Eliminar != null) { Eliminar.ImageUrl="../../images/habilitarbtn.gif"; }
                    if (eliminar != null) { eliminar.Text = "Habilitar"; }
                    break;
                case "0":
                    estadoEliminado.Text = "Habilitado";
                    if (Eliminar != null) { Eliminar.ImageUrl = "../../images/deshabilitarbtn.gif"; }
                    if (eliminar != null) { eliminar.Text = "Deshabilitar"; }
                    break;
                case "":
                    estadoEliminado.Text = "Habilitado";
                    if (Eliminar != null) { Eliminar.ImageUrl = "../../images/deshabilitarbtn.gif"; }
                    if (eliminar != null) { eliminar.Text = "Deshabilitar"; }
                    break;

            }
        }

    }

    /// <summary>
    /// Método encargado de cambiar el boton habilitar o deshabilitar, segun el estado de un 
    /// registro.
    /// </summary>
    /// <param name="estadoEliminado"></param>
    /// <param name="Eliminar"></param>
    /// <param name="eliminar"></param>
    public static void estadoItemGV(Label estadoEliminado, ImageButton Eliminar, LinkButton eliminar)
    {
        if ((estadoEliminado != null))
        {
            switch (estadoEliminado.Text.Trim())
            {
                case "1":
                    estadoEliminado.Text = "DESHABILITADO";
                    if (Eliminar != null) { Eliminar.ImageUrl = "../../images/habilitarbtn2.gif"; Eliminar.ToolTip = "Habilitar"; }
                    if (eliminar != null) { eliminar.Text = "Habilitar"; }
                    break;
                case "0":
                    estadoEliminado.Text = "HABILITADO";
                    if (Eliminar != null) { Eliminar.ImageUrl = "../../images/deshabilitarbtn2.gif"; Eliminar.ToolTip = "Deshabilitar"; }
                    if (eliminar != null) { eliminar.Text = "Deshabilitar"; }
                    break;
                case "":
                    estadoEliminado.Text = "HABILITADO";
                    if (Eliminar != null) { Eliminar.ImageUrl = "../../images/deshabilitarbtn2.gif"; Eliminar.ToolTip = "Deshabilitar"; }
                    if (eliminar != null) { eliminar.Text = "Deshabilitar"; }
                    break;

            }
        }

    }
    /// <summary>
    ///  Muestra un mensaje de confirmacion cuando se ha insertado o actualizado un registro.
    /// </summary>
    /// <param name="cambios"></param>
    /// <param name="dv"></param>
    /// <param name="gv"></param>
    /// <param name="mensaje"></param>
    public static void informacionSatisfactoria(Label cambios, DetailsView dv, GridView gv, String mensaje)
    {
        if (dv != null)
        {
            dv.DataBind();
        }
        if (gv != null)
        {
            gv.DataBind();
        }
        cambios.Visible = true;
        cambios.Text = mensaje;
    }


    /// <summary>
    ///  Metodo encargado de poner un entero en nulo cuando no existe un registro en la base de
    ///  datos.
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static Int32? isNull(Int32? valor)
    {
        if (valor == 0)
        {
            valor = null;
        }
        return valor;
    }

    /// <summary>
    ///  Metodo encargado de poner un decimal en nulo cuando no existe un registro en la base 
    ///  de datos.
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static Decimal? isNullDec(String valor)
    {
        Decimal? valorD = null;
        if (valor.Equals(""))
        {
            valorD = null;
        }
        else
        {
            valorD = Decimal.Parse(valor);
        }
        return valorD;
    }
    /// <summary>
    ///  Metodo encargado de poner en nulo un string vacio.
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static String isNullText(String valor)
    {
        if (valor.Equals(""))
        {
            valor = null;
        }
        return valor;
    }
    /// <summary>
    /// Método encargado de habilitar el botón volver o cerrar segun la pagina sea nueva o 
    /// por el contrario, provenga de una pagina anterior.
    /// </summary>
    /// <param name="Request"></param>
    /// <param name="VolverB"></param>
    /// <param name="Cancelar"></param>
    public static void habilitarVolverBtn(HttpRequest Request, ImageButton VolverB, ImageButton Cancelar )
    {
        if (Request.QueryString.Get("v") == null)
        {
            VolverB.Visible = false;
        }
        else if(Cancelar!=null)
        {
            Cancelar.Visible = false;
        }
    }

    public static String getCondicion(DataTable tbl_registros, bool isCentroZonal)
    {
        String condicion = null;
        if(tbl_registros.Rows.Count!=0)
        {
        if (isCentroZonal.Equals(true))
        {
            DataRow rowCentroZonal = null;
            String condicionCentroZonal = "CENT_ID in (";
            foreach (DataRow row in tbl_registros.Rows)
            {
               //rowDepto = (GeosDataSet.spConsultarDetalleCarteraDeptoRow)row;
                rowCentroZonal = row;
                condicionCentroZonal = condicionCentroZonal + rowCentroZonal["CENT_ID"].ToString() + ",";
            }
            condicionCentroZonal = condicionCentroZonal.Remove(condicionCentroZonal.Length - 1);
            condicionCentroZonal = condicionCentroZonal + ")";
            condicion = condicionCentroZonal;
        }
        else if (isCentroZonal.Equals(false))
        {
            DataRow rowMun = null;
            String condicionMun = "MUNI_ID in (";
            foreach (DataRow row in tbl_registros.Rows)
            {
                rowMun = row;
                condicionMun = condicionMun +"'" + rowMun["MUNI_ID"].ToString() + "',";
            }
            condicionMun = condicionMun.Remove(condicionMun.Length - 1);
            condicionMun = condicionMun + ")";
            condicion = condicionMun;
        }
        }
        else
        {
            condicion = "0=1";
        }
        return condicion;

    }

    public static String getCondicionVisitas(DataTable tbl_registros, bool isDepto)
    {
        String condicion = null;
        if (isDepto.Equals(true))
        {
            DataRow rowDepto = null;
            String condicionDepto = "departamento_id in (";
            foreach (DataRow row in tbl_registros.Rows)
            {
                //rowDepto = (GeosDataSet.spConsultarDetalleCarteraDeptoRow)row;
                rowDepto = row;
                condicionDepto = condicionDepto + rowDepto["departamento_id"].ToString() + ",";
            }
            condicionDepto = condicionDepto.Remove(condicionDepto.Length - 1);
            condicionDepto = condicionDepto + ")";
            condicion = condicionDepto;
        }
        else if (isDepto.Equals(false))
        {
            DataRow rowMun = null;
            String condicionMun = "municipio_id in (";
            foreach (DataRow row in tbl_registros.Rows)
            {
                rowMun = row;
                condicionMun = condicionMun + rowMun["municipio_id"].ToString() + ",";
            }
            condicionMun = condicionMun.Remove(condicionMun.Length - 1);
            condicionMun = condicionMun + ")";
            condicion = condicionMun;
        }
        return condicion;
    }

    public static String getCondicionTooltip(DataTable tbl_registros, bool isCentroZonal, String atributobuscado, bool isDinero, bool isPalabra)
    {
        String condicion = null;
        String diseñoTablaHeader = " - (";
        
        //String diseñoTablaHeader = " ";
        //String diseñoTablaFooter = " ";
        if (isCentroZonal.Equals(true))
        {
            DataRow rowCentroZonal = null;
            String condicionCentroZonal = "Lookup(CENT_ID, 'Sin Registros' ,";
            foreach (DataRow row in tbl_registros.Rows)
            {
                rowCentroZonal = row;
                if(isDinero)
                    condicionCentroZonal = condicionCentroZonal + rowCentroZonal["CENT_ID"].ToString() + ",'" + String.Format("${0:###,##0.}", Convert.ToDouble(rowCentroZonal[atributobuscado].ToString())) + "',";
                else if(isPalabra)
                    condicionCentroZonal = condicionCentroZonal + rowCentroZonal["CENT_ID"].ToString() + ",'" + rowCentroZonal[atributobuscado].ToString() + "',";
                else
                    condicionCentroZonal = condicionCentroZonal + rowCentroZonal["CENT_ID"].ToString() + ",'" + String.Format("{0:###,##0.}", Convert.ToDouble(rowCentroZonal[atributobuscado].ToString())) + "',";
            }
            condicionCentroZonal = condicionCentroZonal.Remove(condicionCentroZonal.Length - 1);
            condicionCentroZonal = condicionCentroZonal + ")";
            condicion = condicionCentroZonal;
        }
        else if (isCentroZonal.Equals(false))
        {
            DataRow rowMun = null;
            String condicionMun = "Lookup(MUNI_ID, 'Sin Registros' ,";
            foreach (DataRow row in tbl_registros.Rows)
            {
                rowMun = row;
                if (isDinero)
                    condicionMun = condicionMun + rowMun["MUNI_ID"].ToString() + ",'" + String.Format("${0:###,##0.}", Convert.ToDouble(rowMun[atributobuscado].ToString()))+ "',";
                else if(isPalabra)
                    condicionMun = condicionMun + rowMun["MUNI_ID"].ToString() + ",'" + rowMun[atributobuscado].ToString() + "',";
                else
                    condicionMun = condicionMun + rowMun["MUNI_ID"].ToString() + ",'" + String.Format("{0:###,##0.}", Convert.ToDouble(rowMun[atributobuscado].ToString())) + "',";

            }
            condicionMun = condicionMun.Remove(condicionMun.Length - 1);
            condicionMun = condicionMun + ")";
            condicion = condicionMun;
        }
        return condicion;
    }

    public static String getCondicionLabelMapa(List<RangoPorcentaje> tbl_registros, bool isCentroZonal,  bool isDinero)
    {
        String condicion = null;
        if (isCentroZonal.Equals(true))
        {
            RangoPorcentaje rowCentroZonal = null;
            String condicionCentroZonal = "Lookup(CENT_ID, 'Sin Registros' ,";
            foreach (RangoPorcentaje row in tbl_registros)
            {
                rowCentroZonal = row;
                if (isDinero)
                    condicionCentroZonal = condicionCentroZonal + rowCentroZonal.getIdMunicipioCentro().ToString() + ",'" + String.Format("${0:###,##0.}", Convert.ToDouble(rowCentroZonal.getPorcentaje().ToString())) + "',";
                else
                    condicionCentroZonal = condicionCentroZonal + rowCentroZonal.getIdMunicipioCentro().ToString() + ",'" + String.Format("{0:###,##0.}", Convert.ToDouble(rowCentroZonal.getPorcentaje().ToString())) + "',";
            }
            condicionCentroZonal = condicionCentroZonal.Remove(condicionCentroZonal.Length - 1);
            condicionCentroZonal = condicionCentroZonal + ")";
            condicion = condicionCentroZonal;
        }
        else if (isCentroZonal.Equals(false))
        {
            RangoPorcentaje rowMun = null;
            String condicionMun = "Lookup(MUNI_ID, 'Sin Registros' ,";
            foreach (RangoPorcentaje row in tbl_registros)
            {
                rowMun = row;
                if (isDinero)
                    condicionMun = condicionMun + rowMun.getIdMunicipioCentro().ToString() + ",'" + String.Format("${0:###,##0.}", Convert.ToDouble(rowMun.getPorcentaje().ToString())) + "',";
                else
                    condicionMun = condicionMun + rowMun.getIdMunicipioCentro().ToString() + ",'" + String.Format("{0:###,##0.}", Convert.ToDouble(rowMun.getPorcentaje().ToString())) + "',";

            }
            condicionMun = condicionMun.Remove(condicionMun.Length - 1);
            condicionMun = condicionMun + ")";
            condicion = condicionMun;
        }
        return condicion;
    }


    public static List<String> getRango (String rango)
    {
        String[] listaValores = null;
        String[] listaTotal = null;
        List<String> lista = new List<string>();
        listaValores = rango.Split(',');
        foreach (string valor in listaValores)
        {
            listaTotal = valor.Split('=');
            foreach (string total in listaTotal)
            {
                if(Regex.Match(total, @"^[0-9]+$").Success == true)
                {lista.Add(total);}    
            }
        }
        return lista;

    }

    public static string getEtiqueta(String min, String max)
    {
        String Etiqueta = null;
        if(max==null)
        {
            Etiqueta = "Mayor a " + String.Format("${0:###,##0.}", Convert.ToDouble(min));
        }
        else
        {
            Etiqueta = "De " + String.Format("${0:###,##0.}", Convert.ToDouble(min)) + " a " + String.Format("${0:###,##0.}", Convert.ToDouble(max));
        }
        return Etiqueta;
    }

    public static List<String> etiquetaAchurados(String capa, int numeroReglas)
    {
        List<String> listaCondiciones = new List<string>();
        for (int i = 1; i <= numeroReglas; i++)
        {
            List<String> listaTotalesRango = Utils.getRango(Util.Config.getRangoCapa("Rango" + i, capa));
            if (listaTotalesRango.Count < 2)
                listaTotalesRango.Add(null);
            listaCondiciones.Add(Utils.getEtiqueta(listaTotalesRango[0], listaTotalesRango[1]));
        }
        return listaCondiciones;
    }


    public static List<String> etiquetaAchurados2(List<Rango> listaRangos)
    {
        List<String> listaCondiciones = new List<string>();
        foreach (Rango rango in listaRangos)
        {
            listaCondiciones.Add(rango.getNombreRango());
        }
        return listaCondiciones;
    }


    public static List<RangoPorcentaje> hallarPorcentajeElemento(decimal sumatoriaParametro, DataTable dataTable, bool isCentroZonal, String atributoSeleccionado) {

        List<RangoPorcentaje> listaPorcentajes = new List<RangoPorcentaje>();
        foreach (DataRow row in dataTable.Rows)
        {
            decimal id= 0;
            decimal valor = (decimal)row[atributoSeleccionado];
            if(isCentroZonal)
                id = (Decimal)row["CENT_ID"];
            else
                id = (Decimal)Convert.ToDecimal(row["MUNI_ID"]);

            decimal porcentaje = Math.Round((valor * 100) / sumatoriaParametro);
            RangoPorcentaje rangoPorcentaje = new RangoPorcentaje();
            rangoPorcentaje.setIdMunicipioCentro(id);
            rangoPorcentaje.setIsCentroZonal(isCentroZonal);
            rangoPorcentaje.setPorcentaje(porcentaje);
            listaPorcentajes.Add(rangoPorcentaje);
        }

        return listaPorcentajes;       


    }

    public static List<RangoPorcentaje> hallarPorcentajeElemento(DataTable dataTable, bool isCentroZonal, String atributoSeleccionado)
    {

        List<RangoPorcentaje> listaPorcentajes = new List<RangoPorcentaje>();
        foreach (DataRow row in dataTable.Rows)
        {
            decimal id = 0;
            decimal valor = (decimal)Math.Round((Double)row[atributoSeleccionado]);
            if (isCentroZonal)
                id = (Decimal)row["CENT_ID"];
            else
                id = (Decimal)Convert.ToDecimal(row["MUNI_ID"]);

            decimal porcentaje = Math.Round(valor);
            RangoPorcentaje rangoPorcentaje = new RangoPorcentaje();
            rangoPorcentaje.setIdMunicipioCentro(id);
            rangoPorcentaje.setIsCentroZonal(isCentroZonal);
            rangoPorcentaje.setPorcentaje(porcentaje);
            listaPorcentajes.Add(rangoPorcentaje);
        }

        return listaPorcentajes;


    }


    public static List<RangoPorcentaje> hallarPorcentajeElemento(string atributoPlaneacion, DataTable dataTable, bool isCentroZonal, String atributoEjecucion)
    {

        List<RangoPorcentaje> listaPorcentajes = new List<RangoPorcentaje>();
        foreach (DataRow row in dataTable.Rows)
        {
            decimal id = 0;
            decimal valor = (decimal)row[atributoEjecucion];
            decimal valorPlaneacion = Convert.ToDecimal(row[atributoPlaneacion]);
            if (isCentroZonal)
                id = (Decimal)row["CENT_ID"];
            else
                id = (Decimal)Convert.ToDecimal(row["MUNI_ID"]);

            decimal porcentaje = 0;
            if (valorPlaneacion != 0)
            {
              porcentaje = Math.Round((valor * 100) / valorPlaneacion);
            }
            RangoPorcentaje rangoPorcentaje = new RangoPorcentaje();
            rangoPorcentaje.setIdMunicipioCentro(id);
            rangoPorcentaje.setIsCentroZonal(isCentroZonal);
            rangoPorcentaje.setPorcentaje(porcentaje);
            listaPorcentajes.Add(rangoPorcentaje);
        }

        return listaPorcentajes;


    }

    public static List<Rango> calcularRangos(decimal sumatoriaParametro, int numeroReglasDefault, String capa) {
        List<Rango> listaRango = new List<Rango>();
        decimal valorMinimo = 0;
        decimal valorMaximo = 0;
        for (int i = 1; i <= numeroReglasDefault; i++)
        {
            List<String> listaTotalesRango = Utils.getRango(Util.Config.getRangoCapa("Rango" + i, capa));
            decimal valorMinimoCapa = Convert.ToDecimal(listaTotalesRango[0]);
            decimal valorMaximoCapa = Convert.ToDecimal(listaTotalesRango[1]);
            valorMinimo = valorMaximo+1;
            valorMaximo = Math.Round((sumatoriaParametro * valorMaximoCapa) / 100);
            Rango rango = new Rango();
            rango.setNombreRango("De: " + valorMinimoCapa + "% hasta:" + valorMaximoCapa + "%");
            rango.setValorMaximo(valorMaximo);
            rango.setValorMinimo(valorMinimo);
            listaRango.Add(rango);
        }
        return listaRango;
    }

    public static List<Rango> calcularRangosValor(decimal valorMaximoHallado, int numeroReglasDefault) { 
    
     List<Rango> listaRango = new List<Rango>();
        decimal valorMinimo = 0;
        decimal valorMaximo = 0;
        decimal valorPromedio = Math.Round(valorMaximoHallado / numeroReglasDefault);

        for (int i = 1; i <= numeroReglasDefault; i++)
        {
            valorMinimo = valorMaximo + 1;
            valorMaximo = valorMinimo + valorPromedio;
            Rango rango = new Rango();
            rango.setNombreRango("De: " + valorMinimo + " hasta:" + valorMaximo + "");
            rango.setValorMaximo(valorMaximo);
            rango.setValorMinimo(valorMinimo);
            listaRango.Add(rango);
        }
        return listaRango;
    
    }


}
