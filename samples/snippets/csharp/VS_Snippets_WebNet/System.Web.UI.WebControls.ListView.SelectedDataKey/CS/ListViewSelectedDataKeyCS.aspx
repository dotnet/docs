<!-- <Snippet1> -->
<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void ProductInventoryListView_PagePropertiesChanging(object sender, 
    PagePropertiesChangingEventArgs e)
  {
    ProductInventoryListView.SelectedIndex = -1;
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView SelectedDataKey Example</title>
    <style type="text/css">
      .header
      {
      	border: 1px solid #008080;
      	background-color: #008080;
      	color: White;
      }
      .item td { border: 1px solid #008080; }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
    
      <h3>ListView SelectedDataKey Example</h3>
      
      <asp:ListView runat="server" 
        ID="ProductInventoryListView"
        DataSourceID="ProductInventoryDataSource" 
        DataKeyNames="LocationID,ProductID" 
	      OnPagePropertiesChanging="ProductInventoryListView_PagePropertiesChanging">
        <LayoutTemplate>
          <b>Product Inventory</b>
          <br />
          <table width="400px" runat="server" id="tblProducts">
            <tr class="header" runat="server">
              <th runat="server">&nbsp;</th>
              <th runat="server">Product ID</th>
              <th runat="server">Location ID</th>
              <th runat="server">Shelf</th>
              <th runat="server">Bin</th>
              <th runat="server">Quantity</th>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="ProductInventoryPager">
            <Fields>
              <asp:NextPreviousPagerField ShowFirstPageButton="true"
                ShowLastPageButton="true" />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr class="item" runat="server">
            <td>
              <asp:ImageButton runat="server" 
                ID="SelectButton" 
                Width="15"
                Height="15"
                ImageUrl="~/images/select.jpg" 
                CommandName="Select" />
            </td>
            <td>
              <asp:Label runat="server" ID="ProductIDLabel" Text='<%#Eval("ProductID") %>' />
            </td>
            <td>
              <asp:Label runat="server" ID="LocationIDLabel" Text='<%#Eval("LocationID") %>' />
            </td>
            <td>
              <asp:Label runat="server" ID="ShelfLabel" Text='<%#Eval("Shelf") %>' />
            </td>
            <td>
              <asp:Label runat="server" ID="BinLabel" Text='<%#Eval("Bin") %>' />
            </td>
            <td>
              <asp:Label runat="server" ID="QuantityLabel" Text='<%#Eval("Quantity") %>' />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>
      <br /><br />
          
      <asp:ListView runat="server" ID="ProductListView"
        DataSourceID="ProductDataSource">
        <LayoutTemplate>
          <b>Product Details</b>          
          <table runat="server" id="tblDetails">
            <tr runat="server" id="itemPlaceholder" />
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td class="header">Product ID:</td>
            <td>
              <asp:Label runat="server" ID="ProductLabel" Text='<%#Eval("ProductID") %>' />
            </td>
          </tr>
          <tr runat="server">
            <td class="header">Name:</td>
            <td>
              <asp:Label runat="server" ID="NameLabel" Text='<%#Eval("Name") %>' />
            </td>
          </tr>
          <tr runat="server">
            <td class="header">Color:</td>
            <td>
              <asp:Label runat="server" ID="ColorLabel" Text='<%#Eval("Color") %>' />
            </td>
          </tr>
          <tr runat="server">
            <td class="header">Price:</td>
            <td>
              <asp:Label runat="server" ID="ListPriceLabel" Text='<%#Eval("ListPrice", "{0:c}") %>' />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>
       
      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ProductInventoryDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ProductID], [LocationID], [Shelf], [Bin], [Quantity]
                       FROM Production.ProductInventory">
      </asp:SqlDataSource>
      
      <asp:SqlDataSource ID="ProductDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ProductID], [Name], [Color], [ListPrice], [ProductNumber]
                         FROM Production.Product
                         WHERE ProductID = @ProductID
                         ORDER BY [Name]">
          <SelectParameters>
            <asp:ControlParameter Name="ProductID" 
              DefaultValue="0"
              ControlID="ProductInventoryListView" 
              PropertyName="SelectedDataKey[1]"  />
          </SelectParameters>
      </asp:SqlDataSource>
       
    </form>
  </body>
</html>
<!-- </Snippet1> -->