<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView Flow Layout Example</title>
    <style type="text/css">
      .plainBox {
          font-family: Verdana, Arial, sans-serif;
          font-size: 11px;
          background: #ffffff;
          border:1px solid #336666;
          }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">

      <h3>ListView Flow Layout Example</h3>
      
      Select the color:
      <asp:DropDownList ID="ColorList" runat="server" 
        AutoPostBack="True" 
        DataSourceID="ColorDataSource" 
        DataTextField="Color" 
        DataValueField="Color">
      </asp:DropDownList><br /><br />
      
      <asp:ListView runat="server" ID="ProductListView"
        DataSourceID="ProductsDataSource"
        DataKeyNames="ProductID">
        <LayoutTemplate>
          <div runat="server" id="lstProducts">
            <div runat="server" id="itemPlaceholder" />
          </div>
          <asp:DataPager runat="server" PageSize="5" >
            <Fields>
              <asp:NextPreviousPagerField 
                ButtonType="Button"
                ShowFirstPageButton="True" 
                ShowLastPageButton="True" />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <asp:Image ID="ProductImage" runat="server"
            ImageUrl='<%# "~/images/thumbnails/" + Eval("ThumbnailPhotoFileName") %>' />	        
          <div class="plainBox" runat="server">
            <asp:HyperLink ID="ProductLink" runat="server" Text='<%# Eval("Name") %>' 
              NavigateUrl='<%# "ProductDetails.aspx?productID=" + Eval("ProductID") %>' />
            <br /><br />
            <b>Price:</b> 
            <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("ListPrice", "{0:c}")%>' /> <br />
          </div>
          <br />
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
          INNER JOIN Production.ProductPhoto AS PF ON PPF.ProductPhotoID = PF.ProductPhotoID
          WHERE P.Color = @Color" >
        <SelectParameters>
          <asp:ControlParameter ControlID="ColorList" Name="Color" 
            PropertyName="SelectedValue" />
        </SelectParameters>
      </asp:SqlDataSource>

      <asp:SqlDataSource ID="ColorDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>" 
        SelectCommand="SELECT DISTINCT Color FROM Production.Product">
      </asp:SqlDataSource>

    </form>
  </body>
</html>
<%-- </Snippet1> --%>