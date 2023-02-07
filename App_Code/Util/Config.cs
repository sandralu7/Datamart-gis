using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Util
{
    /// <summary>
    /// Tiene en cuenta los parametros de MapGuide establecidos en el archivo web.config.
    /// <author> Sandra Rodríguez.</author>
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Constructor de la clase config.
        /// </summary>
        public Config()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// Obtiene  la ruta de la libreria del  repositorio de capas del proyecto
        /// </summary>
        /// <returns></returns>
        public static String getMapRepositoryRoot()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("strMapRepositoryRoot");
        }
        /// <summary>
        /// obtiene los parametros de la configuracion inicial del MapGuide.
        /// </summary>
        /// <returns></returns>
        public static String getMapguideWebConfigIni()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("strMapguideWebConfigIni");
        }
        /// <summary>
        /// Obtiene el nombre del mapa del proyecto
        /// </summary>
        /// <returns></returns>
        public static String getMapName()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("strMapName");
        }
        /// <summary>
        /// Obtiene el nombre del usuario para establecer la conexión con MapGuide.
        /// </summary>
        /// <returns></returns>
        public static String getMGUser()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("strMGUser");
        }
        /// <summary>
        /// Obtiene la contraseña para establecer la conexión con MapGuide.
        /// </summary>
        /// <returns></returns>
        public static String getMGPassword()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("strMGPassword");
        }
        /// <summary>
        /// Obtiene la llave para la conexión con Gooogle Maps
        /// </summary>
        /// <returns></returns>
        public static String getGoogleKey()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("strGoogleKey");
        }
        /// <summary>
        /// Obtiene la condición de la capa.
        /// </summary>
        /// <returns></returns>
        public static String getLayerConditionDefault()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("strLayerConditionDefault");
        }

        public static String getLayerConditionEtiqueta()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("strEtiquetaMapa");
        }


        public static String getTooltipConditionDefault(String nombreToltip)
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get(nombreToltip);
        }
        public static int getNumReglasDefault()
        {
            return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("strNumReglas"));
        }
        
        public static String getRangoDefault(int rango)
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("strRango"+rango);
        }

        public static String getEtiquetaRangoDefault(int nivelRango)
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("strEtiquetaRango"+nivelRango);
        }     
        public static String getRangoCapa(String rango, String capa)
        {
            String rangoCapa = "str" + rango + capa;
            return System.Configuration.ConfigurationManager.AppSettings.Get(rangoCapa);
        }

	  public static System.Web.UI.Page pageIndex;

	  public static void setPageIndex(System.Web.UI.Page page)
        {
            pageIndex = page;
        }

	  public static System.Web.UI.Page getPageIndex()
        {
            return pageIndex;
        }
    }

   
}