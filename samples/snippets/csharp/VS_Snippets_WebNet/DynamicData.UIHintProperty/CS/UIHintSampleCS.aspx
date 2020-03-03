<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<script runat="server">
    
  protected void Page_Init(object sender, EventArgs e) 
  {
    DynamicDataManager1.RegisterControl(ProductsGridView);
  }
  
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UIHint Property Sample</title>
    <link href="~/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>

  <form id="form1" runat="server">
    <div>
      <h2><%= ProductsDataSource.TableName%> table</h2>

      <asp:DynamicDataManager ID="DynamicDataManager1" runat="server"
        AutoLoadForeignKeys="true" />
        
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"/>
      
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>        

          <asp:GridView ID="ProductsGridView" runat="server" DataSourceID="ProductsDataSource"
            AutoGenerateEditButton="true"
            AutoGenerateColumns="false"
            AllowSorting="true"
            AllowPaging="true">
            <Columns>
              <asp:DynamicField DataField="Name" />
              <asp:DynamicField DataField="ProductNumber" />
              <asp:DynamicField DataField="DiscontinuedDate" UIHint="DateCalendar" />
            </Columns>        
            <EmptyDataTemplate>
              There are currently no items in this table.
            </EmptyDataTemplate>
          </asp:GridView>

          <asp:LinqDataSource ID="ProductsDataSource" runat="server" 
            EnableUpdate="true"
            TableName="Products" 
            ContextTypeName="AdventureWorksLTDataContext" />
          
          </ContentTemplate>
        </asp:UpdatePanel>

    </div>
  </form>
</body>
</html>
<!-- </Snippet1> -->