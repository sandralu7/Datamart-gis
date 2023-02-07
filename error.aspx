<%@ Page Language="C#" MasterPageFile="~/Modules/Detalle.master" AutoEventWireup="true"
    CodeFile="error.aspx.cs" Inherits="permissionDenied" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 300px;
            font-weight: normal;
            background-color: #FFFFFF;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" style="width: 100%; height:100%; font-family: Arial, Helvetica, sans-serif;">
        <tr>
            <td align="center" >
                <table align="center" style="border: thin solid #FF6600; width: 100%; font-family: Arial, Helvetica, sans-serif;
                    font-size: x-large; font-weight: bold; color: #003300;">
                    <tr>
                        <td align="center" valign="middle" class="style1">
                            HA OCURRIDO UN ERROR EN LA DE CONEXIÓN
                            <br />
                            PONGASE EN CONTACTO CON EL ADMINISTRADOR DEL SITIO.</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
