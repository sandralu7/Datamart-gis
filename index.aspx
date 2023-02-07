<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Spatial BI Metas Sociales y Financieras ICBF.</title>
    <link href="css/redmond/jquery-ui-1.8.custom.css" rel="stylesheet" type="text/css" />
    <link href="css/index.geos.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" media="screen" href="css/all-examples.css" />
    <link rel="stylesheet" type="text/css" href="css/superfish.css" media="screen"/>
    <link href="css/AeroWindow.css?r=123" rel="stylesheet" type="text/css" />
    <link href="css/estilos.css" rel="Stylesheet" type="text/css" />
    <link href="index-files/styles_qz7vq.css" type="text/css" rel="stylesheet"/>
    <noscript>
        <style type="text/css">
            #dock
            {
                top: 0;
                left: 100px;
            }
            a.dock-item
            {
                position: relative;
                float: left;
                margin-right: 10px;
            }
            .dock-item span
            {
                display: block;
            }
            .stack
            {
                top: 0;
            }
            .stack ul li
            {
                position: relative;
            }
        </style>
    </noscript>

    <script src="js/external/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/external/jquery-ui-1.7.3.custom.min.js"></script>

    <script src="js/external/json2.js" type="text/javascript"></script>

    <script src="js/geos/mapguide.geos.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/external/hoverIntent.js"></script>

    <script type="text/javascript" src="js/external/superfish.js"></script>

    <script src="js/index.js" type="text/javascript"/> 
        
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>

    <script type="text/javascript" src="js/external/fisheye-iutil.min.js"></script>

    <script type="text/javascript" src="js/external/dock-example1.js"></script>

    <script type="text/javascript" src="js/external/jquery.jqDock.min.js"></script>

    <script type="text/javascript" src="js/external/stack-1.js"></script>

    <script type="text/javascript" src="js/external/stack-2.js"></script>

    <script type="text/javascript" src="js/external/jquery.easing.1.3.js"></script>

    <script type="text/javascript" src="js/external/jquery-AeroWindow.js"></script>    

</head>
<body>
    <form id="form1" runat="server">
    
<!-- Menu -->
<div id="menu">

<ul id="vbUL_qz7vq" class="vbULqz7vq" runat="server"  style="visibility:hidden;">
<li><a title="Consultar Programación vs Ejecución" target="_blank" onclick='showForm("Modules/Cartera/ConsultarIndicadores.aspx");' >Consultar Programación vs Ejecución</a></li>
<li ><a title="Consultar Por Indicadores" target="_blank" onclick='showForm("Modules/ConsultarPorIndicador/ConsultarPorIndicadores.aspx");'>Consultar Por Indicadores</a>
</li>
</ul>
<ul id="vbUL_mz7vq" class="vbULqz7vq" style="visibility:hidden;">

<li><a title="Consultar tema específico" target="_blank" onclick='showForm("Modules/ConsultarTemaEspecifico/ConsultarTemaEspecifico.aspx");'>Consultar tema específico</a>
</li>
<li><a title="Consulta Comparativos" target="_blank" onclick='showForm("Modules/ConsultaComparativos/ConsultarComparativos.aspx");'>Consulta Comparativos</a>
</li>
<li><a title="Registros Atípicos/Deseables" target="_blank" onclick='showForm("Modules/ConsultaRegistrosAtipicosDeseables/ConsultaRegistrosAtipicosDeseables.aspx");'>Registros atípicos</a>
</li>
<li><a title="Árboles de Decisión" target="_blank" onclick='showForm("Modules/Mineria de Datos/ConsultarProbabilidad.aspx");'>Árboles de Decisión</a>
</li>
</ul>

<script type="text/javascript" src="index-files/scqz7vq.js"></script>
<table id="vista-buttons.com:idqz7vq" width=0 cellpadding=0 cellspacing=0 border=0><tr><td style="padding-right:0px" >
<a id="icr" runat="server" visible="true" onMouseOver='xpe("qz7vqo");xpshow("qz7vq",0,this);xpsmover(this);' onMouseOut='xpsmout(this);' onMouseDown='xpe("qz7vqc");'><img id="xpi_qz7vq" src="index-files/btqz7vq_0.gif" name="vbqz7vq" border="0" alt="Programación Metas Sociales" runat="server" style="visibility:show" /></a></td><td style="padding-right:0px" >
<a id="fag" runat="server" visible="true" onMouseOver='xpe("mz7vqo");xpshow("mz7vq",0,this);xpsmover(this);' onMouseOut='xpsmout(this);' onMouseDown='xpe("mz7vqc");'><img id="xpi_mz7vq" src="index-files/btmz7vq_0.gif" name="vbmz7vq" border="0" alt="Ejecución Metas Sociales" runat="server" style="visibility:show"/></a></td><td style="padding-right:0px" >
<!--<a id="cartera" runat="server" visible="false" onMouseOver='xpe("5z7vqo");xpshow("5z7vq",0,this);xpsmover(this);' onMouseOut='xpsmout(this);' onMouseDown='xpe("5z7vqc");'><img id="xpi_5z7vq" src="index-files/bt5z7vq_0.gif" name="vb5z7vq" border="0" alt="Cartera" runat="server" style="visibility:hidden"/></a></td><td style="padding-right:0px" title ="Visitas">
<a id="visitas" runat="server" visible="false" onMouseOver='xpe("az7vqo");xpshow("az7vq",0,this);xpsmover(this);' onMouseOut='xpsmout(this);' onMouseDown='xpe("az7vqc");'><img id="xpi_az7vq" src="index-files/btaz7vq_0.gif" name="vbaz7vq" border="0" alt="Visitas" runat="server" style="visibility:hidden"/></a></td><td style="padding-right:0px" title ="Seguridad">
<a id="seguridad" runat="server" visible="false" onMouseOver='xpe("sz7vqo");xpshow("sz7vq",0,this);xpsmover(this);' onMouseOut='xpsmout(this);' onMouseDown='xpe("sz7vqc");'><img id="xpi_sz7vq" src="index-files/btsz7vq_0.gif" name="vbsz7vq" border="0" alt="Seguridad" runat="server" style="visibility:hidden"/></a></td>--></tr></table>
<noscript><a href="#"></a></noscript>
    
</div>
        
    <!-- END DOCK 1 ============================================================ -->
    <iframe id="ViewerFrame" name="ViewerFrame" src="/mapguide/mapviewerajax/?SESSION=<%= sessionId %>&&WEBLAYOUT=Library%3a%2f%2fDataMart%2fdefault.WebLayout&LOCALE=en">
    </iframe>
    <div id="cargandoLbl" class="backgroundTransparent">
        <img class="" src="images/cargando.gif"  alt="cargando"/>
    </div>
    
    <div>
        <iframe id="OpenlayersFrame" style="display: none"></iframe>
    </div>
    <div id="dock">
        <div class="dock-container ui-draggable geos-toolbar">
            <b class="geos-toolbar-bloque"><b class="geos-toolbar-borde1"></b><b class="geos-toolbar-borde2">
            </b><b class="geos-toolbar-borde3"></b><b class="geos-toolbar-borde4"><b></b></b><b
                class="geos-toolbar-borde5"><b></b></b></b><b class="geos-toolbar-bloque"><b class="geos-toolbar-borde5">
                </b><b class="geos-toolbar-borde4"></b><b class="geos-toolbar-borde3"></b><b class="geos-toolbar-borde2">
                    <b></b></b><b class="geos-toolbar-borde1"><b></b></b></b>
                   
                    <a class="dock-item "><span>
                                Activar&nbsp;Capas</span>
                                <img class="ver-leyenda command-tool" src="images/layers-sm.png" alt="Activar Capas" />
                                <img class="ocultar-leyenda" src="images/layers-sm.png" alt="" />
                    </a>
                    <a class="dock-item"><span>
                        Imprimir</span>
                        <img id="tool35" class="command-tool" src="images/print-sm.png" alt="Imprimir" />
                    </a> 
                    <a class="dock-item"><span>
                        Vista&nbsp;Inicial</span>
                        <img id="tool39" class="command-tool" src="images/resize-sm.png" alt="Vista Inicial" />
                    </a>
                    <a class="dock-item"><span>
                        Acercamiento&nbsp;por&nbsp;Área</span>
                        <img id="tool37"
                        class="tool" src="images/target.png" alt="Acercamiento por Área" />
                    </a> 
                    <a class="dock-item"><span>
                        Acercar</span><img id="tool42" class="tool" src="images/zoom_in-sm.png" alt="Acercar" />
                    </a>
                    <a class="dock-item"><span>
                        Alejar</span><img id="tool43" class="tool" src="images/zoom_out-sm.png"
                        alt="Alejar" />
                    </a> 
                    <a class="dock-item"><span>
                        Seleccionar</span><img id="tool36"
                        class="tool tool-selected tool-selected-border" src="images/wizard-sm.png"
                        alt="Seleccionar" />
                    </a> 
                    <a class="dock-item"><span>
                        Mover</span><img id="tool33"
                        class="tool" src="images/mover-sm.png" alt="Mover" />
                    </a> 
                    <a class="dock-item"><span>
                        Limpiar&nbsp;Selección</span><img
                        id="tool17" class="command-tool" src="images/close-sm.png" alt="Limpiar Selección" />
                    </a>
                     <a class="dock-item">
                        <span>Medir&nbsp;Distancias</span>
                        <img
					     id="tool29" class="command-tool" src="images/ruler_square-sm.png" alt="Medir Distancias" />
                    </a>
                    <a class="dock-item">
                        <span>Vista&nbsp;Anterior</span>
                        <img
					     id="tool34" class="command-tool" src="images/redo-sm.png" alt="Zoom Anterior" />
                    </a>
                    
        </div>
        <!-- end div .dock-container -->
    </div>
    <!-- end div .dock #dock --> 
    <div id="MyFrameContainer" style="display: none;">
        <iframe id="MyFrame" class="geos-tbody" name="MyFrame" src="cargando.html"></iframe>
    </div>
    
    <div id="MyFrameContainer2" style="display: none;">
        <iframe id="MyFrame2" class="geos-tbody" name="MyFrame2" src="cargando.html"></iframe>
    </div>
    
    <div id="MyFrameContainer3" style="display: none;">
        <iframe id="MyFrame3" class="geos-tbody" name="MyFrame3" src="cargando.html"></iframe>
    </div>
    <div class="geos-properties" style="display: none;" id="geos-properties">
        <table class="Grid" cellspacing="0" cellpadding="0" border="1" id="table">
            <tbody class="geos-properties-body geos-tbody">
            </tbody>
        </table>
    </div>
    
    <div id="visorArchivosDiv">
        <iframe id="visorArchivos" width="100%" height="100%" />
    </div>
    </form>    
</body>
</html>
