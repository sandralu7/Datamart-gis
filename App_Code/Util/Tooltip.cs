using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using GeosDataSetTableAdapters;

/// <summary>
/// Clase que maneja la entidad usuario
/// </summary>
/// <author> Sandra Lucia Rodríguez Torres</author>
public class Tooltip
{
    String nombre;
    String regla;

    /// <summaray>
    /// Constructor de la case usuario.
    /// </summary>
    public Tooltip(String nombre, String regla)
    {
        this.nombre = nombre;
        this.regla = regla;
    }

    public String getNombre()
    {
        return this.nombre;
    }

    public void setNombre(String nombre)
    {
        this.nombre = nombre;
    }

    public String getRegla()
    {
        return this.regla;
    }

    public void setRegla(String regla)
    {
        this.regla = regla;
    }
}
