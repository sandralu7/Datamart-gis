using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml;
using OSGeo.MapGuide;
using Util;
using System.Diagnostics;


/// <summary>
/// Summary description for GeografiaServiceMapGuide
/// </summary>
public class GeografiaServiceMapGuide
{
    private DataTable myDataTable;

    public GeografiaServiceMapGuide()
    {
    }
  /*  public static void listaCapasRepositorio(String sessionId)
    {
        try
        {
            MgUserInformation userInfo = new MgUserInformation(sessionId);
            MgSiteConnection siteConnection = new MgSiteConnection();
            siteConnection.Open(userInfo);
            MgResourceService resService = (MgResourceService)siteConnection.CreateService(MgServiceType.ResourceService);
            MgResourceIdentifier rid = new MgResourceIdentifier("Library://");
            MgByteReader byteRead = resService.EnumerateResources(rid, -1, "");
            string br = byteRead.ToString();
            String a = br;
            //return listaNombreXML(br);
        }
        catch (MgException e)
        {
            // TODO Auto-generated catch block

        }
        
    }

    public static void adicionarCapa(System.Web.UI.Page page, String nombre, String capaReferencia, String sessionId)
    {
        
        adicionarCapa2(getLayerDefinitionName(capaReferencia), nombre, sessionId);
    }

    private static String getLayerDefinitionName(String capaReferencia)
    {
        return capaReferencia + ".LayerDefinition";
    }


    private static void adicionarCapa2(String capaReferencia, String nombreLeyenda, String sessionId)
    {
        try
        {
            MgUserInformation userInfo = new MgUserInformation(sessionId);
            MgSiteConnection siteConnection = new MgSiteConnection();
            siteConnection.Open(userInfo);
            MgResourceService resService = (MgResourceService)siteConnection
                    .CreateService(MgServiceType.ResourceService);

            MgMap map = new MgMap();
            map.Open(resService, Util.Config.getMapName());
            MgResourceIdentifier rid = new MgResourceIdentifier(capaReferencia);
            MgLayer newLayer = GetNewLayer(resService, rid, nombreLeyenda);

            MgLayerCollection lc = map.GetLayers();
            if (!lc.Contains(newLayer.GetName()))
            {
                lc.Insert(0, newLayer);

            }
            map.Save();
        }
        catch (MgException e)
        {
            throw (new GeoMapException("La capa " + capaReferencia + " no se ha encontrado"));
        }

    }

    private static MgLayer GetNewLayer(MgResourceService resService, MgResourceIdentifier rid,
        String nombreLeyenda)
    {

        MgLayer newLayer = new MgLayer(rid, resService);
        newLayer.SetVisible(true);
        newLayer.SetDisplayInLegend(true);
        newLayer.SetName(rid.Name);
        newLayer.SetSelectable(true);
        newLayer.SetLegendLabel(nombreLeyenda);
        return newLayer;
    }

    private static void filtrarCapaBase(String nombreRecursoCapa, String sessionId)
    {
        try
        {
            MgUserInformation userInfo = new MgUserInformation(sessionId);
            MgSiteConnection siteConnection = new MgSiteConnection();
            siteConnection.Open(userInfo);
            MgResourceService resService = (MgResourceService)siteConnection
                    .CreateService(MgServiceType.ResourceService);

            MgMap map = new MgMap();
            map.Open(resService, Util.Config.getMapName());

            MgLayerCollection lc = map.GetLayers();
            IEnumerator<MgLayerBase> iE = lc.GetEnumerator();
            while (iE.MoveNext())
            {
                MgLayerBase mgBa = iE.Current;
                string str = mgBa.LayerDefinition.ToString();
                if (!str.Equals(nombreRecursoCapa))
                    mgBa.SetSelectable(false);
                else
                {
                    mgBa.SetSelectable(true);
                    mgBa.SetVisible(true);
                }

            }
            map.Save();

        }
        catch (MgException e)
        {
            throw (new GeoMapException("La capa " + nombreRecursoCapa + " no se ha encontrado"));
        }
    }
  
    protected void initMyDataTable()
    {
        myDataTable = new DataTable();

        myDataTable.Columns.Add("CODIGO", typeof(string));
        myDataTable.Columns.Add("MATERIAL", typeof(string));
        myDataTable.Columns.Add("TIPO", typeof(string));
        myDataTable.Columns.Add("COLUMNA_CODIGO", typeof(string));
    }

    public DataTable GetSelectionReport(String selection, String sessionId)
    {
        try
        {
            initMyDataTable();
            MgUserInformation userInfo = new MgUserInformation(sessionId);
            MgSiteConnection siteConnection = new MgSiteConnection();
            siteConnection.Open(userInfo);

            MgResourceService resService = (MgResourceService)siteConnection
                    .CreateService(MgServiceType.ResourceService);
            MgFeatureService featService = (MgFeatureService)siteConnection
                    .CreateService(MgServiceType.FeatureService);

            MgMap map = new MgMap();
            map.Open(resService, Util.Config.getMapName());
            MgSelection mapSelection = new MgSelection(map, selection);
            mapSelection.FromXml(selection);

            MgReadOnlyLayerCollection layers = mapSelection.GetLayers();
            MgFeatureReader featReader = null;

            if (layers != null)
            {
                for (int i = 0; i < layers.GetCount(); i++)
                {
                    MgLayerBase layer = layers.GetItem(i);
                    //logger.info(layer.GetName());
                    if (layer != null)
                    {
                        String layerClassName = layer.GetFeatureClassName();
                        String selectString = mapSelection.GenerateFilter(
                                layer, layerClassName);

                        String layerFeatureIdString = layer
                                .GetFeatureSourceId();
                        MgResourceIdentifier layerResId = new MgResourceIdentifier(
                                layerFeatureIdString);

                        MgFeatureQueryOptions queryOptions = new MgFeatureQueryOptions();
                        queryOptions.SetFilter(selectString);
                        featReader = featService.SelectFeatures(layerResId,
                                layerClassName, queryOptions);

                        while (featReader.ReadNext())
                        {
                            string nombreCapa = layer.Name;
                            string material = getAttr(featReader, "MAPS");
                            string codigo = "" + getAttr(featReader, "FeatId");
                            string codigoColumna = "FeatId";
                            
                            myDataTable.Rows.Add(codigo, material, layer.Name, codigoColumna);

                        }
                    }
                }
            }
        }
        catch (MgException e)
        {
            // logger.error(e.getCause());
        }
        catch (Exception e)
        {
            // logger.error(e.getCause());
        }
        return myDataTable;
    }

    protected String getAttr(MgFeatureReader featReader, String prop)
    {
        try
        {
            return featReader.GetString(prop);
        }
        catch (MgException e)
        {
            //e.printStackTrace();
        }
        return "";
    }

    protected Double getAttrDouble(MgFeatureReader featReader, String prop)
    {
        try
        {
            return featReader.GetDouble(prop);
        }
        catch (MgException e)
        {
            //e.printStackTrace();
        }
        return -1;
    }
*/
    public static void adicionarCapa(System.Web.UI.Page page, String nombre, String capaReferencia, String sessionId)
    {

        adicionarCapa2(getLayerDefinitionName(capaReferencia), nombre, sessionId);

        // adicionarCapa2(getLayerDefinitionName(nombreSimple), nombreLeyenda, sessionId);
        // filtrarCapaBase(getLayerDefinitionName(nombreSimpleCapaBase), sessionId);
    }

    private static String getLayerDefinitionName(String capaReferencia)
    {
        return capaReferencia + ".LayerDefinition";
    }


    private static void adicionarCapa2(String capaReferencia, String nombreLeyenda, String sessionId)
    {
        try
        {
            MgUserInformation userInfo = new MgUserInformation(sessionId);
            MgSiteConnection siteConnection = new MgSiteConnection();
            siteConnection.Open(userInfo);
            MgResourceService resService = (MgResourceService)siteConnection
                    .CreateService(MgServiceType.ResourceService);

            MgMap map = new MgMap();
            map.Open(resService, Util.Config.getMapName());
            MgResourceIdentifier rid = new MgResourceIdentifier(capaReferencia);
            MgLayer newLayer = GetNewLayer(resService, rid, nombreLeyenda);

            MgLayerCollection lc = map.GetLayers();
            if (!lc.Contains(newLayer.GetName()))
            {
                lc.Insert(0, newLayer);

            }
            map.Save();
        }
        catch (MgException e)
        {
            throw (new GeoMapException("La capa " + capaReferencia + " no se ha encontrado"));
        }

    }

    private static MgLayer GetNewLayer(MgResourceService resService, MgResourceIdentifier rid,
        String nombreLeyenda)
    {

        MgLayer newLayer = new MgLayer(rid, resService);
        newLayer.SetVisible(true);
        newLayer.SetDisplayInLegend(true);
        newLayer.SetName(rid.Name);
        newLayer.SetSelectable(true);
        newLayer.SetLegendLabel(nombreLeyenda);
        return newLayer;
    }



    public String SeleccionarElemento(System.Web.UI.Page page, String nombreCapa, String condicion,
        String sessionId, System.Web.UI.Control control)
    {
        String selectionXML = null;
        try
        {
            MgUserInformation userInfo = new MgUserInformation(sessionId);
            MgSiteConnection siteConnection = new MgSiteConnection();
            siteConnection.Open(userInfo);
            MgResourceService resService = (MgResourceService)siteConnection
                    .CreateService(MgServiceType.ResourceService);
            MgFeatureService featureService = (MgFeatureService)siteConnection
                    .CreateService(MgServiceType.FeatureService);

            MgMap map = new MgMap();
            map.Open(resService, Util.Config.getMapName());

            // Get Geometry object: districtGeometry
            MgFeatureQueryOptions dptoQuery = new MgFeatureQueryOptions();
            dptoQuery.SetFilter(condicion);

            MgLayerBase layerFound = getLayerBaseByName(map, nombreCapa);

            if (layerFound != null)
            {
                MgResourceIdentifier dptoId = new MgResourceIdentifier(layerFound.FeatureSourceId);
                MgFeatureReader featureReader = featureService.SelectFeatures(
                        dptoId, layerFound.FeatureClassName, dptoQuery);

                // Highlight the query result on the map
                MgSelection selection = new MgSelection(map);

                selection.AddFeatures(layerFound, featureReader, 0);
                selectionXML = selection.ToXml();

                //logger.info(selectionXML);

                if (featureReader != null)
                    featureReader.Close();


                if (selection.GetSelectedFeaturesCount(layerFound, layerFound.FeatureClassName) > 0)
                    selectJavascriptCall(selectionXML, nombreCapa, page, control);
                else
                    throw new GeoMapException("No se encontraron datos para la condición dada");
            }
            else
            {
                throw new GeoMapException("No pudo encontrar la capa " + nombreCapa + " recuerde cargarla con el botón Añadir Capa");
            }

        }
        catch (MgException e)
        {
            throw new GeoMapException("No pudo encontrar en " + nombreCapa + " el objeto con la condicion: " + condicion);

        }
        return selectionXML;
    }
    protected MgLayerBase getLayerBaseByName(MgMap map, String nombreCapa)
    {
        MgLayerCollection lc = map.GetLayers();
        IEnumerator<MgLayerBase> iE = lc.GetEnumerator();

        while (iE.MoveNext())
        {
            MgLayerBase mgBa = iE.Current;
            string str = mgBa.Name;
            if (str.Equals(nombreCapa))
            {
                return mgBa;
            }
        }
        return null;
    }
    public static void Refresh(System.Web.UI.Page page, System.Web.UI.Control control)
    {
        String script = "top.getMapFrame().Refresh();";
        Utils.RegisterClientScriptBlock(page, "Refresh", script, control);
    }
    public static void clearSelection(System.Web.UI.Page page, System.Web.UI.Control control)
    {
        String script = "top.getMapFrame().ExecuteMapAction(17);";
        Utils.RegisterClientScriptBlock(page, "clearSelection", script, control);
    }
    public static void ZoomToSelected(System.Web.UI.Page page, System.Web.UI.Control control)
    {
        String script = "top.getMapFrame().ExecuteMapAction(10);";
        Utils.RegisterClientScriptBlock(page, "ZoomToSelected", script, control);
    }
    public static void ZoomToMaxExtents(System.Web.UI.Page page, System.Web.UI.Control control)
    {
        String script = "top.getMapFrame().ExecuteMapAction(11);";
        Utils.RegisterClientScriptBlock(page, "ZoomToMaxExtents", script, control);
    }
    private static void selectJavascriptCall(String selectionXML, String capa, System.Web.UI.Page page, System.Web.UI.Control control)
    {
        String script = "top.getMapFrame().SetSelectionXML('" + selectionXML + "');top.setCapaSeleccionada('" + capa + "');";
        Utils.RegisterClientScriptBlock(page, "Selection", script, control);
    }
    public static void ZoomToView(System.Web.UI.Page page, String scale, System.Web.UI.Control control)
    {

        String script = "top.getMapFrame().ZoomToView(top.getMapFrame().GetCenter().X, top.getMapFrame().GetCenter().Y, " + scale + ", true);";
        Utils.RegisterClientScriptBlock(page, "ZoomToView", script, control);
    }



}