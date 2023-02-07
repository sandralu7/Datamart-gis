using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OSGeo.MapGuide;
using OSGeo;



public partial class index : Seguridad, System.Web.UI.ICallbackEventHandler
{
    protected String sessionId;
    protected void Page_Load(object sender, EventArgs e)
    {

        //Util.Config.setPageIndex(this);	
       // validarPermisos();
            try
            {

                ClientScriptManager cm = Page.ClientScript;
                String cbReference = cm.GetCallbackEventReference(this, "arg",
                    "ReceiveServerData", "");
                String callbackScript = "function CallServer(arg, context) {" +
                    cbReference + "; }";
                cm.RegisterClientScriptBlock(this.GetType(),
                    "CallServer", callbackScript, true);

                if (Session["sessionId"] == null)
                {
                    MapGuideApi.MgInitializeWebTier(Util.Config.getMapguideWebConfigIni());
                    MgUserInformation userInfo = new MgUserInformation(Util.Config.getMGUser(), Util.Config.getMGPassword());
                    MgSite Sitio = new MgSite();
                    Sitio.Open(userInfo);
                    sessionId = Sitio.CreateSession();
                    Session.Add("sessionId", sessionId);


                }
                sessionId = (String)Session["sessionId"];
            }
            catch (Exception ex)
            {

            }
        
    }

    public void validarPermisos()
    {
    /*    if (validateSession(1,false))
        {
            xpi_qz7vq.Style.Value = "visibility:show";
            icr.Visible = true;
        }
        if (validateSession(2,false))
        {
            xpi_mz7vq.Style.Value = "visibility:show";
            fag.Visible = true;
        }
        if (validateSession(3, false))
        {
            xpi_5z7vq.Style.Value = "visibility:show";
            cartera.Visible = true;
        }
        if (validateSession(4, false))
        {
            xpi_az7vq.Style.Value = "visibility:show";
            visitas.Visible = true;
        }
        if (validateSession(5, false))
        {
            xpi_sz7vq.Style.Value = "visibility:show";
            seguridad.Visible = true;
        }

        if ((Session["ID_USUARIO"] != null) && (!Session["ID_USUARIO"].ToString().Equals("3")))
        {
            

        }*/
        
    }
    public void RaiseCallbackEvent(String eventArgument)
    {
        Session.Add("selectionXML", eventArgument);

    }
    public string GetCallbackResult()
    {
        return "hello";
    }
    private String getAttr(MgFeatureReader featReader, String prop)
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
}
