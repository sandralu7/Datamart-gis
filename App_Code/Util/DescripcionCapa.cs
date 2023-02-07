using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DescripcionCapa
/// </summary>
public class DescripcionCapa
{
    private String id_metadato;
    private String nombre_capa;
    private String descripcion; 
    private String nombre;
    
    public DescripcionCapa() { }

    public string Id_metadato{
        get{
            return this.id_metadato;
        }
        set{
            this.id_metadato = value;
        }
    }

    public string Nombre_capa
    {
        get
        {
            return this.nombre_capa;
        }
        set
        {
            this.nombre_capa = value;
        }
    }

    public string Descripcion
    {
        get
        {
            return this.descripcion;
        }
        set
        {
            this.descripcion = value;
        }
    }

    public string Nombre
    {
        get
        {
            return this.nombre;
        }
        set
        {
            this.nombre = value;
        }
    }


}
