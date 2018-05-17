<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBS.Reuniao.aspx.cs" Inherits="DBS.Reuniao.Layouts.DBS.Reuniao.DBS" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script type="text/javascript">
    function AbreLinkDocto(vTitulo) {
        var vCaminho = "/Doctos_Reuniao/Forms/AllItems.aspx?RootFolder=%2FDoctos%5FReuniao%2F" + escapeProperly(vTitulo);
        window.open(vCaminho, "_blank");
    }

</script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Label runat="server" ID = "lblErro" ForeColor="Red"></asp:Label>

    <p class="subtitulo_pagina">:: Reunião</p>
    <p>&nbsp;</p>

    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="grid_tabela">
      <tr class="grid_cabecalho">
        <td width="20%">Início</td>
        <td width="*">Assunto</td>
        <td width="30%">Local</td>
        <td width="15%">&nbsp;</td>
      </tr>

      <asp:Literal ID="ltrConteudo" runat="server" />

      <!--
      <tr class="grid_conteudo">
        <td>99/99/9999 99:00</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td align="center">
    	    <img src="images/img_forum.png" width="26" height="26" alt="Fórum" /> &nbsp;&nbsp;&nbsp;
            <img src="img_doctos.png" width="26" height="26" alt="Documentação" />
        </td>
      </tr>
      -->

    </table>
    <p>&nbsp;</p>
    <p><img src="/images/img_adicionar.png" alt="" />&nbsp;<a class="ms-addnew" id="idHomePageNewItem" href="/_layouts/listform.aspx?PageType=8&amp;ListId={1C1B2F66-5F96-4976-8AAA-A26AF0A737E9}&amp;RootFolder=" onclick="javascript:NewItem2(event, &quot;/_layouts/listform.aspx?PageType=8&amp;ListId={1C1B2F66-5F96-4976-8AAA-A26AF0A737E9}&amp;RootFolder=&quot;);javascript:return false;" target="_self">Adicionar novo item</a></p>

</asp:Content>


