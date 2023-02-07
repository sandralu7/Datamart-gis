<%@ Page Language="C#" MasterPageFile="~/Modules/Detalle.master" AutoEventWireup="true"
    CodeFile="permissionDenied.aspx.cs" Inherits="permissionDenied" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 300px;
            font-weight: normal;
            background-color: #FFFFFF;
            font-size: large;
        }
        .style2
        {
            color: #006E3A;
            font-size: large;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-weight: normal;
            height: 300px;
            width: 985px;
            background-color: #FFFFFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" style="width: 100%; height:100%; font-family: Arial, Helvetica, sans-serif;">
        <tr>
            <td align="center" >
                <table align="center" style="border: thin solid #14380C; width: 100%; font-family: Arial, Helvetica, sans-serif;
                    font-size: x-large; font-weight: bold; color: #003300;">
                    <tr>
                        <td align="center" valign="middle" class="style2">
                            NO TIENE PERMISOS SUFICIENTES PARA ACCEDER A ESTA FUNCIONALIDAD
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
