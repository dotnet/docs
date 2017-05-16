
<%-- 
C:\_ricka08\code\DD\Snippet\DynamicControlParameter\vb_DynamicControlParameter\DynamicData\CustomPages\CustomerAddresses\List.aspx
C:\sdtree\Orcas\Web.NET\System.Web.DynamicData.DynamicDataManager
 --%>
<%-- <Snippet1> --%>
<%@ Page Language="VB" MasterPageFile="~/Site.master" %>

<script runat="server">

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        DynamicDataManager1.RegisterControl(GridView1)
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        
<h1> DynamicDataManager CS Sample</h1>

    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server"
         AutoLoadForeignKeys="true" />

    <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource"
        AllowPaging="True" AllowSorting="True" CssClass="gridview">
    </asp:GridView>

    <asp:LinqDataSource ID="GridDataSource" runat="server" EnableDelete="true">
    </asp:LinqDataSource>
    
</asp:Content>
<%-- </Snippet1>--%>