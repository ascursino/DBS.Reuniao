using System;
using System.Data;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Text;
using System.Web.UI.WebControls;

namespace DBS.Reuniao.Layouts.DBS.Reuniao
{
    public partial class DBS : LayoutsPageBase
    {
        SPWeb web = SPContext.Current.Site.RootWeb;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MontaGridConteudo("");
            }
            catch (Exception ex)
            {
                lblErro.Text = ex.ToString();
            }
        }


        public void MontaGridConteudo(string varParamBusca)
        {
            string varLinha = "";
            string varLinkForum = "";
            string varLinkDocto = "";

            int varIDForum;
            int varIDDocto;

            //Acessando a lista
            SPList lstLista = web.Lists["Reuniao"];

            //Construindo a Query CAML
            SPQuery oQuery = new SPQuery();

            oQuery.Query =  "<Where>" +
                            "    <Geq>" +
                            "        <FieldRef Name='In_x00ed_cio' />" +
                            "        <Value IncludeTimeValue='TRUE' Type='DateTime'>" + DateTime.Today.ToString("yyyy-MM-dd") + "</Value>" +
                            "    </Geq>" +
                            "</Where>" +
                            "<OrderBy>" +
                            "   <FieldRef Name='In_x00ed_cio' Ascending='True' />" +
                            "</OrderBy>";

            //Criando uma coleção de itens, utilizando a Query CAML
            SPListItemCollection collListItems = lstLista.GetItems(oQuery);

            //Recupera o item
            foreach (SPListItem oListItem in collListItems)
            {
                StringBuilder sbLinha = new StringBuilder();

                varIDForum = BuscaIDForum(AjustaCampo(oListItem["Title"].ToString()));

                if (varIDForum == 0)
                {
                    varLinkForum = "<img src='/images/img_forum_off.png' alt='Fórum' border='0'/>&nbsp;&nbsp;&nbsp;";
                }
                else
                {
                    varLinkForum = "<a href='/Lists/Forum_Reuniao/Flat.aspx?RootFolder=%2FLists%2FForum%5FReuniao%2F" + varIDForum + "%5F%2E000' target='blank'><img src='/images/img_forum_on.png' alt='Fórum' border='0'/></a>&nbsp;&nbsp;&nbsp;";
                }

                varIDDocto = BuscaIDDocto(AjustaCampo(oListItem["Title"].ToString()));

                if (varIDDocto == 0)
                {
                    varLinkDocto = "<img src='/images/img_doctos_off.png' alt='Documentação' border='0'/>";
                }
                else
                {
                    varLinkDocto = "<a href=\"#\" onclick=\"AbreLinkDocto('" + AjustaCampo(oListItem["Title"].ToString()) + "');\"><img src='/images/img_doctos_on.png' alt='Documentação' border='0'/></a>";
                }

                //Monta linha da grid com os resultados
                sbLinha.Append("<tr class='grid_conteudo'>");
                sbLinha.Append("<td>&nbsp;" + AjustaCampo(oListItem["In_x00ed_cio"].ToString()) + "</td>");

                //sbLinha.Append("<td>&nbsp;" + AjustaCampo(oListItem["Title"].ToString()) + "</td>");

                sbLinha.Append("<td>&nbsp;<a href=\"#\" onclick=\"openDialog2('/_layouts/listform.aspx?PageType=4&ListId={1C1B2F66-5F96-4976-8AAA-A26AF0A737E9}&ID=" + AjustaCampo(oListItem["ID"].ToString()) + "',1050,'Detalhes da Reunião');\">" + AjustaCampo(oListItem["Title"].ToString()) + "</a></td>");

            //openDialog2('/_layouts/listform.aspx?PageType=4&ListId={1C1B2F66-5F96-4976-8AAA-A26AF0A737E9}&ID=51',1050,'Reunião')
                
                sbLinha.Append("<td>&nbsp;" + AjustaCampo(oListItem["Local"].ToString()) + "</td>");
                sbLinha.Append("<td align='center'>");
                sbLinha.Append(varLinkForum);
                sbLinha.Append(varLinkDocto);
                sbLinha.Append("</td></tr>");

                varLinha += sbLinha.ToString();
            }

            ltrConteudo.Text = varLinha.ToString();
        }


        public string AjustaCampo(string vCampo)
        {
            if (vCampo.IndexOf(";#") > 0)
            {
                vCampo = vCampo.Substring(vCampo.IndexOf("#") + 1);
            }
            return vCampo;
        }


        public int BuscaIDForum(string varParam)
        {
            int vIDForum = 0;

            //Acessando a lista
            SPList lstLista = web.Lists["Forum_Reuniao"];

            //Construindo a Query CAML
            SPQuery oQuery = new SPQuery();

            oQuery.Query = "<Where>" +
                            "    <Eq>" +
                            "        <FieldRef Name='Title' />" +
                            "        <Value Type='Text'>" + varParam.ToString() +"</Value>" +
                            "    </Eq>" +
                            "</Where>";

            //Criando uma coleção de itens, utilizando a Query CAML
            SPListItemCollection collListItems = lstLista.GetItems(oQuery);

            //Recupera o item
            foreach (SPListItem oListItem in collListItems)
            {
                if (collListItems.Count > 0)
                {
                    vIDForum = int.Parse(AjustaCampo(oListItem["ID"].ToString()));
                }
            }

            return vIDForum;
        }


        public int BuscaIDDocto(string varParam)
        {
            int vIDDocto = 0;

            //Acessando a lista
            SPList lstLista = web.Lists["Documentos de Reunião"];

            //Construindo a Query CAML
            SPQuery oQuery = new SPQuery();

            oQuery.Query = "<Where>" +
                            "    <Eq>" +
                            "        <FieldRef Name='Title' />" +
                            "        <Value Type='Text'>" + varParam.ToString() + "</Value>" +
                            "    </Eq>" +
                            "</Where>";

            //Criando uma coleção de itens, utilizando a Query CAML
            SPListItemCollection collListItems = lstLista.GetItems(oQuery);

            //Recupera o item
            foreach (SPListItem oListItem in collListItems)
            {
                if (collListItems.Count > 0)
                {
                    vIDDocto = int.Parse(AjustaCampo(oListItem["ID"].ToString()));
                }
            }

            return vIDDocto;
        }


    }
}
