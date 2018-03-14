<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 
  protected void Page_Init(object sender, EventArgs e)
  {
    // Registers the data-bound control with
    // the DynamicDataManager control.
    DynamicDataManager1.RegisterControl(ProductsGridView);
    
    // Initializes the URL for the View All link 
    // to the current page.
    ViewAllLink.NavigateUrl = Request.Path;

  }

  protected string GetFilterPath()
  {
    // Retrieves the current data item.
    var productItem = (Product)GetDataItem();
    if (productItem.ProductCategory != null)
    {
      // Creates a URL that has a query string value
      // set to the foreign key value.      
      return Request.Path + "?ProductCategoryID=" 
        + productItem.ProductCategoryID.ToString();
    }
    return string.Empty;
  }

  protected string GetProductCategory()
  {
    // Returns the value for the Name column
    // in the relationship table.    
    var productItem = (Product)GetDataItem();
    if (productItem.ProductCategory != null)
    {
      return productItem.ProductCategory.Name;
    }
    return string.Empty;
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>DynamicQueryStringParameter Example</title>
  <link href="~/Site.css" rel="stylesheet" type="text/css" />
</head>
<body class="template">
  <form id="form1" runat="server">
    <div>
    
      <h2>DynamicQueryStringParameter Example</h2>
      
      <asp:DynamicDataManager ID="DynamicDataManager1" runat="server"
        AutoLoadForeignKeys="true" />
              
      <asp:GridView ID="ProductsGridView" runat="server"
        AutoGenerateColumns="false"
        DataSourceID="ProductsDataSource"
        AllowPaging="true"
        CssClass="gridview">
        <Columns>
          <asp:DynamicField DataField="Name" />
          <asp:DynamicField DataField="ProductNumber" />
          <asp:DynamicField DataField="Color" />
          <asp:TemplateField HeaderText="Category">
            <ItemTemplate>
              <a runat="server" href='<%# GetFilterPath() %>'>
                <asp:Label runat="server" ID="ProductCategory" Text='<%# GetProductCategory() %>' />
              </a>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
      <br />
      
      <div class="bottomhyperlink">
        <asp:HyperLink runat="server" ID="ViewAllLink" Text="View All Records" />
      </div>


      <!-- This example uses Microsoft SQL Server and connects   -->
      <!-- to the AdventureWorksLT sample database.              -->
      <asp:LinqDataSource ID="ProductsDataSource" runat="server" 
        TableName="Products"
        ContextTypeName="AdventureWorksLTDataContext" >
        <WhereParameters>
          <asp:DynamicQueryStringParameter Name="ProductCategory" />
        </WhereParameters>
      </asp:LinqDataSource>
      
    </div>
  </form>
</body>
</html>
<!-- </Snippet1> -->