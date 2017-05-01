<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>DataPager Example</title>
    <style type="text/css">        
      th
      {
        background-color:#eef4fa;
        border-top:solid 1px #9dbbcc;
        border-bottom:solid 1px #9dbbcc;
      }
      .itemSeparator { border-right: 1px solid #ccc }
      .groupSeparator
      {
        height: 1px;
        background-color: #cccccc;
      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DataPager Example</h3>
      
      <!-- The first DataPager control. -->
      <asp:DataPager runat="server" ID="BeforeListDataPager"
        PagedControlID="ProductsListView" 
        PageSize="18">
        <Fields>
          <asp:NextPreviousPagerField ButtonType="Image"
            ShowFirstPageButton="true"
            ShowNextPageButton="false"
            ShowPreviousPageButton="false"
            FirstPageImageUrl="~/images/first.gif" />
          <asp:NumericPagerField ButtonCount="10" />
          <asp:NextPreviousPagerField ButtonType="Image"
            ShowLastPageButton="true"
            ShowNextPageButton="false"
            ShowPreviousPageButton="false"
            LastPageImageUrl="~/images/last.gif" />
        </Fields>
      </asp:DataPager>

      <asp:ListView ID="ProductsListView" 
        DataSourceID="ProductsDataSource" 
        GroupItemCount="3"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="640px" id="tbl1" runat="server">
            <tr>
              <th colspan="5">PRODUCTS LIST</th>
            </tr>
            <tr runat="server" id="groupPlaceholder"></tr>
          </table>
        </LayoutTemplate>
        <GroupTemplate>
          <tr runat="server" id="tr1">
            <td runat="server" id="itemPlaceholder"></td>
          </tr>
        </GroupTemplate>
        <GroupSeparatorTemplate>
          <tr runat="server">
            <td colspan="5">
	            <div class="groupSeparator"><hr></div>
	          </td>
          </tr>
        </GroupSeparatorTemplate>
        <ItemTemplate>
          <td align="center" runat="server">
            <asp:HyperLink ID="ProductLink" runat="server" 
              Text='<%# Eval("Name") %>' 
              NavigateUrl='<%# "ProductDetails.aspx?productID=" + Eval("ProductID") %>' /><br />
            <asp:Image ID="ProductImage" runat="server"
              ImageUrl='<%#"~/images/thumbnails/" + Eval("ThumbnailPhotoFileName") %>' /><br />
            <b>Price:</b> <%# Eval("ListPrice", "{0:c}")%> <br />
          </td>
        </ItemTemplate>
        <ItemSeparatorTemplate>
          <td class="itemSeparator" runat="server">&nbsp;</td>
        </ItemSeparatorTemplate>
      </asp:ListView>

      <!-- The second DataPager control. -->
      <asp:DataPager runat="server" ID="AfterListDataPager"
        PagedControlID="ProductsListView" 
        PageSize="18">
        <Fields>
          <asp:NextPreviousPagerField ButtonType="Image"
            ShowFirstPageButton="true"
            ShowNextPageButton="false"
            ShowPreviousPageButton="false"
            FirstPageImageUrl="~/images/first.gif" />
          <asp:NumericPagerField ButtonCount="10" />
          <asp:NextPreviousPagerField ButtonType="Image"
            ShowLastPageButton="true"
            ShowNextPageButton="false"
            ShowPreviousPageButton="false"
            LastPageImageUrl="~/images/last.gif" />
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
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>