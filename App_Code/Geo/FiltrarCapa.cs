using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OSGeo.MapGuide;
using OSGeo;

/// <summary>
/// Summary description for FiltrarClientes
/// </summary>
public class FiltrarCapaService : GeografiaServiceMapGuide
{
    public FiltrarCapaService()
    {
    }
    public void filtrar(String nombreRecursoCapa, String nombreLeyenda, String condicion, String sessionId, List<Tooltip> tooltip, List<String> listaReglasTematicos, List<String> listaEtiquetasLeyenda, int numReglas, String etiquetaMapa)
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
            MgResourceIdentifier rid = new MgResourceIdentifier(nombreRecursoCapa);


            MgLayer newLayer = GetNewLayer(resService, getMgResourceIdentifier(rid, condicion, nombreLeyenda, sessionId, resService, tooltip, listaReglasTematicos, listaEtiquetasLeyenda, numReglas, etiquetaMapa), nombreLeyenda);
            //lc.RemoveAt(0);
            MgLayerCollection lc = map.GetLayers();
            IEnumerator<MgLayerBase> iE = lc.GetEnumerator();
            int i = 0, j = -1;
            while (iE.MoveNext())
            {
                MgLayerBase mgBa = iE.Current;
                if (mgBa.GetName().Contains(nombreLeyenda))
                {
                    j = i;
                    newLayer.Visible = mgBa.Visible;
                }
                i++;
            }
            if (j != -1)
                lc.RemoveAt(j);
            lc.Insert(0, newLayer);
            map.Save();

        }
        catch (MgException e)
        {
            Console.WriteLine("Attempted divide by zero.");
            String error = e.StackTrace;
            throw (new GeoMapException("La capa " + nombreRecursoCapa + " no se ha encontrado"));
        }
    }
    private MgLayer GetNewLayer(MgResourceService resService, MgResourceIdentifier rid,
        String nombreLeyenda)
    {

        MgLayer newLayer = new MgLayer(rid, resService);
        newLayer.SetDisplayInLegend(true);
        newLayer.SetName(rid.Name);
        newLayer.SetSelectable(true);
        newLayer.SetLegendLabel(nombreLeyenda);
        return newLayer;
    }
    private MgResourceIdentifier getMgResourceIdentifier(MgResourceIdentifier rid, String condicion, String nombreLeyenda, String sessionId, MgResourceService resService, List<Tooltip> tooltip, List<String> listaReglasTematicos, List<String> listaEtiquetasLeyenda, int numReglas, String etiqueta)
    {

        if (condicion != Util.Config.getLayerConditionDefault())
        {

            MgByteReader byteReader = resService.GetResourceContent(rid);
            String xml_ = byteReader.ToString();
            xml_ = xml_.Replace(Util.Config.getLayerConditionDefault(), condicion);
            if (etiqueta != null) {
                xml_ = xml_.Replace(Util.Config.getLayerConditionEtiqueta(), etiqueta);
            
            }
            if (tooltip != null)
            {
                for (int i = 0; i < tooltip.Count; i++)
                {
                    xml_ = xml_.Replace(tooltip[i].getNombre(), tooltip[i].getRegla());
                }
            }
            if(listaReglasTematicos!=null)
            {
                for(int i=1; i<=numReglas;i++)
                {
                    xml_ = xml_.Replace(Util.Config.getRangoDefault(i), listaReglasTematicos[i-1]);
                }
            }
            if(listaEtiquetasLeyenda!=null)
            {
                for(int i=1; i<=numReglas;i++)
                {
                    xml_ = xml_.Replace(Util.Config.getEtiquetaRangoDefault(i), listaEtiquetasLeyenda[i-1]);
                }
            }
            MgResourceIdentifier layerResId = new MgResourceIdentifier(
                    "Session:" + sessionId + "//" + nombreLeyenda
                            + ".LayerDefinition");
            resService.SetResource(layerResId, new MgByteReader(xml_,
                    "text/xml"), null);
            return layerResId;
        }
        return rid;
    }
}
