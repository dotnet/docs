<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>NumericPagerField Example</title>
  </head>
  <body>
    <form id="form1" runat="server">

      <h3>NumericPagerField Example</h3>
      
      <h4>Products List</h4>
      	      
      <asp:ListView runat="server" ID="ProductListView"
        DataSourceID="ProductsDataSource"
        DataKeyNames="ProductID"
        GroupItemCount="2">
        <LayoutTemplate>
          <table cellpadding="2" width="640px" runat="server" id="tblProducts">
            <tr runat="server" id="groupPlaceholder">
            </tr>
          </table>
          <br />
          <asp:DataPager ID="DataPager1" runat="server" PageSize="6" >
            <Fields>                
              <asp:NumericPagerField                
                ButtonType="Button"
                ButtonCount="15"
                NextPageText="Next >>"
                PreviousPageText="Previous <<" />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <GroupTemplate>
          <tr runat="server" id="ProductRow">
            <td runat="server" id="itemPlaceholder"></td>
          </tr>
        </GroupTemplate>
        <ItemTemplate>
          <td runat="server">
            <asp:Image ID="ProductImage" runat="server"
              ImageUrl='<%#"~/images/" & Eval("ThumbnailPhotoFileName") %>' />
            <div>
              <asp:Label ID="ProductName" runat="server" 
                Text='<%# Eval("Name") %>' 
                Font-Italic="true" />
              <br />
              Price:
              <asp:Label ID="Price" runat="server" Text='<%# Eval("ListPrice", "{0:c}")%>' />
              <br /><br />
            </div>
          </td>
        </ItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ProductsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT P.ProductID, P.Name, P.Color, P.ListPrice, 
          PF.ThumbnailPhotoFileName, P.Size
          FROM Production.Product AS P 
          INNER JOIN Production.ProductProductPhoto AS PPF ON P.ProductID = PPF.ProductID 
          INNER JOIN Production.ProductPhoto AS PF ON PPF.ProductPhotoID = PF.ProductPhotoID" >
      </asp:SqlDataSource>

    </form>
  </body>
</html>
<%-- </Snippet1> --%>