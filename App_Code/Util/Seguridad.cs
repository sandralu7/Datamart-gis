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
using Util;

using System.Collections.Generic;

/// <summary>
/// Clase encargada de la seguridad del sistema.
/// </summary>
/// <author>
/// Sandra Lucia Rodríguez Torres
/// </author>
public class Seguridad : System.Web.UI.Page
{
    
    /// <summary>
    /// Constructor de la clase.
    /// </summary>
    public Seguridad()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Metodo encargado de validar el usuario y establecer los permisos que tiene sobre 
    /// los distintos modulos del sistema.
    /// </summary>
    /// <param name="idFuncionalidad"></param>
    /// <returns></returns>
    public Boolean validateSession(Int32 idFuncionalidad, Boolean permisoDenegado)
    {
        //Comentar la siguiente linea para habilitar la seguridad.
        //return true;
        //Se evalua que la sesion del usuario no sea null

      /* if (Session["ID_USUARIO"] != null)
        {

            GeosDataSet.USUARIORow usuario = Entidades.BuscarUsuarioPorId(Int32.Parse(Session["ID_USUARIO"].ToString()));
            //Se evalua que un usuario con ese Id exista
            if (usuario != null)
            {
                DataTable dtPerfilesFuncionalidad = adapterPerfil.PerfilesByFuncionalidad(idFuncionalidad);
                //DataTable dtPerfilesByFuncionalidad = perfilFuncionalidadAdapter.PerfilesByFuncionalidad(idFuncionalidad);
                DataTable dtPerfilesByUsuario = adapterPerfil.PerfilesByUsuario(Int32.Parse(usuario.ID_USUARIO.ToString()));
                if (validRol(dtPerfilesByUsuario, dtPerfilesFuncionalidad))
                {
                    RunAuthorization();
                    return true;
                }
                else
                {
                    //Si no tiene el rol permitido enviarlo a la página de inicio
                    if (permisoDenegado.Equals(true))
                    {
                        Response.Redirect("~/permissionDenied.aspx");
                    }
                    return false;

                }
            }
            else
            {
                //Si no tiene el rol permitido enviarlo a la página de inicio
                Response.Redirect("~/Quit.aspx");
                return false;

            }
        }
        else
        {
           //Si no se encuentra un usuario registrado se asigna la cuenta de un usuario invitado 
            GeosDataSet.USUARIORow usuario = Entidades.BuscarUsuarioPorId(3);
            Session["ID_USUARIO"] = usuario.ID_USUARIO;
            validateSession(idFuncionalidad, false);
           

        }*/
        return true;

    }

    /// <summary>
    /// Metodo encargado de validar que los perfiles del usuario coincidan con los perfiles 
    /// asociados con la funcionalidad.
    /// </summary>
    /// <param name="dtPerfilesByUsuario"></param>
    /// <param name="dtPerfilesByFuncionalidad"></param>
    /// <returns></returns>
    public Boolean validRol(DataTable dtPerfilesByUsuario, DataTable dtPerfilesByFuncionalidad)
    {
        //for recorre los roles de la pagina 
    /*    if (dtPerfilesByFuncionalidad.Rows.Count > 0)
        {
            foreach (DataRow rowPerfilByFuncionalidad in dtPerfilesByFuncionalidad.Rows)
            {
                //si el usuario tiene roles asociados entonces
                GeosDataSet.PERFILRow myRowPerfilByFuncionalidad = (GeosDataSet.PERFILRow)rowPerfilByFuncionalidad;
                if (dtPerfilesByUsuario.Rows.Count > 0)
                {
                    //recorrer los roles del usuario
                    foreach (DataRow row in dtPerfilesByUsuario.Rows)
                    {
                        //si el rol del usuario es igual al rol de la pagina que se esta evaluando se devuelve true
                        GeosDataSet.PERFILRow myRowPerfilByUsuario = (GeosDataSet.PERFILRow)row;
                        if (myRowPerfilByUsuario.ID_PERFIL == myRowPerfilByFuncionalidad.ID_PERFIL)
                        {
                            return true;
                        }
                    }
                }
            }
        }*/
        return true;
    }

    /// <summary>
    /// Autoriza al usuario a visualizar o no componentes relacionados con la edición, 
    /// actualización, creación y lectura de datos.
    /// </summary>
    public void RunAuthorization()
    {
       /* if (Session["ID_USUARIO"] != null)
        {
            GeosDataSet.USUARIORow usuario = Entidades.BuscarUsuarioPorId(Int32.Parse(Session["ID_USUARIO"].ToString()));
            if (usuario != null)
            {

                DataTable dtPerfilesByUsuario = adapterPerfil.PerfilesByUsuario(Int32.Parse(usuario.ID_USUARIO.ToString()));
                if (getInsertButtons() != null)
                {
                    DataTable dtPerfilesCrearActualizar = adapterPerfil.PerfilesCrearActualizar();
                    if (!validRol(dtPerfilesByUsuario, dtPerfilesCrearActualizar))
                    {
                        foreach (ImageButton ib in getInsertButtons())
                        {
                            //ib.ImageUrl = "";AQUI SE PONE EL PATH DEL BOTON DESHABILITADO
                            ib.Visible = false;

                        }
                    }
                }

                if (getInsertLinks() != null)
                {
                    DataTable dtPerfilesCrearActualizar = adapterPerfil.PerfilesCrearActualizar();
                    if (!validRol(dtPerfilesByUsuario, dtPerfilesCrearActualizar))
                    {

                        foreach (LinkButton ib in getInsertLinks())
                        {
                            //ib.ImageUrl = "";AQUI SE PONE EL PATH DEL BOTON DESHABILITADO
                            ib.Visible = false;
                        }
                    }
                }

                if (getModifyButtons() != null)
                {
                    DataTable dtPerfilesCrearActualizar = adapterPerfil.PerfilesCrearActualizar();
                    if (!validRol(dtPerfilesByUsuario, dtPerfilesCrearActualizar))
                    {
                        foreach (ImageButton ib in getModifyButtons())
                        {
                            //ib.ImageUrl = "";AQUI SE PONE EL PATH DEL BOTON DESHABILITADO
                            ib.Visible = false;
                        }
                    }
                }

                if (getDeleteButtons() != null)
                {
                    DataTable dtPerfilesAdministrador = adapterPerfil.GetAdministrator();
                    if (!validRol(dtPerfilesByUsuario, dtPerfilesAdministrador))
                    {

                        foreach (ImageButton ib in getDeleteButtons())
                        {
                            //ib.ImageUrl = "";AQUI SE PONE EL PATH DEL BOTON DESHABILITADO
                            ib.Visible = false;
                        }
                    }
                }

                if (getCommandInsert() != null)
                {
                    DataTable dtPerfilesCrearActualizar = adapterPerfil.PerfilesCrearActualizar();
                    if (!validRol(dtPerfilesByUsuario, dtPerfilesCrearActualizar))
                    {

                        CommandField comando = getCommandInsert();
                        comando.ShowInsertButton = false;
                    }
                }
                if (getCommandEdit() != null)
                {
                    DataTable dtPerfilesCrearActualizar = adapterPerfil.PerfilesCrearActualizar();
                    if (!validRol(dtPerfilesByUsuario, dtPerfilesCrearActualizar))
                    {

                        CommandField comando = getCommandEdit();
                        comando.ShowEditButton = false;
                    }
                }
                if (getCommandDelete() != null)
                {
                    DataTable dtPerfilAdministrador = adapterPerfil.GetAdministrator();
                    if (!validRol(dtPerfilesByUsuario, dtPerfilAdministrador))
                    {

                        CommandField comando = getCommandDelete();
                        comando.ShowDeleteButton = false;
                    }
                }
                if (getColumna() != null)
                {
                    DataTable dtPerfilAdministrador = adapterPerfil.GetAdministrator();
                    if (!validRol(dtPerfilesByUsuario, dtPerfilAdministrador))
                    {

                        DataControlField comando = getColumna();
                        comando.Visible = false;
                    }
                }
            }
        }*/
    }
    /// <summary>
    /// Metodo abstracto que implementan las distintas paginas para permitir la visualización 
    /// o no del boton insertar.
    /// </summary>
    /// <returns></returns>
    protected virtual List<ImageButton> getInsertButtons()
    {
        return null;
    }
    /// <summary>
    /// Metodo abstracto que implementan las distintas paginas para permitir la visualización 
    /// o no del boton Link Insertar.
    /// </summary>
    protected virtual List<LinkButton> getInsertLinks()
    {
        return null;
    }
    /// <summary>
    /// Metodo abstracto que implementan las distintas paginas para permitir la visualización 
    /// o no del boton modificar.
    /// </summary>
    protected virtual List<ImageButton> getModifyButtons()
    {
        return null;
    }
    /// <summary>
    /// Metodo abstracto que implementan las distintas paginas para permitir la visualización 
    /// o no del boton eliminar.
    /// </summary>
    protected virtual List<ImageButton> getDeleteButtons()
    {
        return null;
    }
    /// <summary>
    /// Metodo abstracto que implementan las distintas paginas para permitir la visualización 
    /// o no del comando insertar.
    /// </summary>
    protected virtual CommandField getCommandInsert()
    {
        return null;
    }
    /// <summary>
    /// Metodo abstracto que implementan las distintas paginas para permitir la visualización 
    /// o no del comando editar.
    /// </summary>
    protected virtual CommandField getCommandEdit()
    {
        return null;
    }
    /// <summary>
    /// Metodo abstracto que implementan las distintas paginas para permitir la visualización 
    /// o no del comando eliminar.
    /// </summary>
    protected virtual CommandField getCommandDelete()
    {
        return null;
    }
    /// <summary>
    /// Metodo abstracto que implementan las distintas paginas para permitir la visualización 
    /// o no del comando columna.
    /// </summary>
    protected virtual DataControlField getColumna()
    {
        return null;
    }



}
