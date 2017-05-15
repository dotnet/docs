<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView Tiled Layout Example</title>
    <style type="text/css">        
        .header
        {
          background-color:#B0C4DE;
          border-top:solid 1px #9dbbcc;
          border-bottom:solid 1px #9dbbcc;
        }
        .separator { border-right: 1px solid #ccc; }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView Tiled Layout Example</h3>
      
      <%-- <Snippet2> --%>
      <asp:ListView ID="ProductsListView" 
        DataSourceID="ProductsDataSource" 
        GroupItemCount="2"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="640px" runat="server" id="tblProducts">
            <tr runat="server" class="header">
              <th runat="server" colspan="3">PRODUCTS LIST</th>
            </tr>
            <tr runat="server" id="groupPlaceholder" />
          </table>
        </LayoutTemplate>
        <GroupTemplate>
          <tr runat="server" id="ProductsRow">
            <td runat="server" id="itemPlaceholder" />
          </tr>
        </GroupTemplate>
        <GroupSeparatorTemplate>
          <tr runat="server">
            <td colspan="3"><hr /></td>
          </tr>
        </GroupSeparatorTemplate>
        <ItemTemplate>
          <td align="center" style="width:300px" runat="server">
            <asp:HyperLink ID="ProductLink" runat="server" 
               Text='<%# Eval("Name") %>' 
             NavigateUrl='<%# "ProductDetails.aspx?productID=" & Eval("ProductID") %>' /><br />
            <asp:Image ID="ProductImage" runat="server"
               ImageUrl='<%# "~/images/thumbnails/" & Eval("ThumbnailPhotoFileName") %>' /><br />
            <b>Price:</b>
            <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("ListPrice", "{0:c}")%>' /><br />
          </td>
        </ItemTemplate>
        <ItemSeparatorTemplate>
          <td class="separator" runat="server">&nbsp;</td>
        </ItemSeparatorTemplate>
      </asp:ListView>
      <br />

      <asp:DataPager runat="server" ID="ProductsDataPager" 
        PagedControlID="ProductsListView">
        <Fields>
          <asp:NextPreviousPagerField ButtonType="Button"
            ShowFirstPageButton="true"
            ShowNextPageButton="false" 
            ShowPreviousPageButton="false" />
          <asp:NumericPagerField ButtonCount="10" />
          <asp:NextPreviousPagerField ButtonType="Button"
            ShowLastPageButton="true"
            ShowNextPageButton="false" 
            ShowPreviousPageButton="false" />
        </Fields>
      </asp:DataPager>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ProductsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT P.ProductID, P.Name, P.Color, P.ListPrice, 
          PF.ThumbnailPhotoFileName
          FROM Production.Product AS P 
          INNER JOIN Production.ProductProductPhoto AS PPF ON P.ProductID = PPF.ProductID 
          INNER JOIN Production.ProductPhoto AS PF ON PPF.ProductPhotoID = PF.ProductPhotoID">
      </asp:SqlDataSource>
      <%-- </Snippet2> --%>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>