<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs)
        DynamicDataManager1.RegisterControl(ProductsFormView)
    End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>DynamicControl.DataField Sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:DynamicDataManager ID="DynamicDataManager1" runat="server"
        AutoLoadForeignKeys="true" />
        
      <asp:FormView ID="ProductsFormView" runat="server" DataSourceID="ProductsDataSource" 
        DataKeyNames="ProductID" AllowPaging="True" 
        PagerSettings-PageButtonCount="15">
        <ItemTemplate>
          Name:
          <asp:DynamicControl runat="server" DataField="Name" />
          <br />
          Product Number:
          <asp:DynamicControl runat="server" DataField="ProductNumber" />
          <br />
          Product Category:
          <asp:DynamicControl runat="server" DataField="ProductCategory" />
          <br />
        </ItemTemplate>
      </asp:FormView>

      <!-- This example uses Microsoft SQL Server and connects   -->
      <!-- to the AdventureWorksLT sample database.              -->
      <asp:EntityDataSource ID="ProductsDataSource" runat="server"
        ContextTypeName="AdventureWorksLT_DataModel.AdventureWorksLT_DataEntities"
        EntitySetName="Product"
        Where='it.Size="L"'>
      </asp:EntityDataSource>
      
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->