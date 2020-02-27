<!-- <Snippet1> -->
<%@ Page Language="C#" MasterPageFile="~/Site.master" %>

<script runat="server">

    protected void Page_Init(object sender, EventArgs e) {
        DynamicDataManager1.RegisterControl(GridView1);
    }

</script>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1> DynamicDataManager VB Sample</h1>
    
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" 
        AutoLoadForeignKeys="true" />
    
    <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource" AllowPaging="True"
        AllowSorting="True" CssClass="gridview">
    </asp:GridView>
    
    <asp:LinqDataSource ID="GridDataSource" runat="server" EnableDelete="true">
       
    </asp:LinqDataSource>
    
</asp:Content>
<!-- </Snippet1> -->