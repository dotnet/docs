<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>DataPagerField Example</title>    
    <style type="text/css">
      body  
      {
      	text-align: center; 
      	font: 13px Tahoma, Arial, Helvetica;
      }
      .item
      {
        border-bottom: solid 1px #FFA500;
        font-weight:bold;
      }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>DataPagerField Example</h3>
          
      <asp:ListView ID="ProductsListView" 
        DataSourceID="ContactsDataSource"
        runat="server">
        <LayoutTemplate>
          <table runat="server" id="tblProducts" width="350">
            <tr runat="server" id="itemPlaceholder" />
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td class="item">
              <asp:Label ID="NameLabel" runat="server" 
                Text='<%#Eval("Name") %>' />
            </td>
          </tr>
          <tr runat="server">
            <td>
              <asp:Label ID="DescriptionLabel" runat="server" 
                Text='<%#Eval("Description")%>' />
            </td>
          </tr>
        </ItemTemplate>
        <ItemSeparatorTemplate>
          <tr runat="server">
            <td>&nbsp;</td>
          </tr>
        </ItemSeparatorTemplate>
      </asp:ListView>
      <br />

      <asp:DataPager runat="server" 
        ID="ProductsDataPager" 
        PageSize="5"
        PagedControlID="ProductsListView">
        <Fields>
          <asp:TemplatePagerField>
            <PagerTemplate>
            <b>
            Page
            <asp:Label runat="server" ID="CurrentPageLabel" 
              Text="<%# IIf(Container.TotalRowCount>0, (Container.StartRowIndex / Container.PageSize) + 1, 0) %>" />
            of
            <asp:Label runat="server" ID="TotalPagesLabel" 
              Text="<%# Math.Ceiling (System.Convert.ToDouble(Container.TotalRowCount) / Container.PageSize) %>" />
            </b>
            <br /><br />            
            </PagerTemplate>
          </asp:TemplatePagerField>
          
          <asp:NextPreviousPagerField
            ShowFirstPageButton="true"
            ShowNextPageButton="false"
            ShowPreviousPageButton="false" />
          
          <asp:NumericPagerField 
            PreviousPageText="&lt;&lt;"
            NextPageText="&gt;&gt;"
            ButtonCount="10" />
            
          <asp:NextPreviousPagerField
            ShowLastPageButton="true"
            ShowNextPageButton="false"
            ShowPreviousPageButton="false" />
        </Fields>
      </asp:DataPager>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT P.Name, PD.Description 
                      FROM Production.ProductModel AS PM 
                      INNER JOIN Production.Product AS P ON PM.ProductModelID = P.ProductModelID 
                      INNER JOIN Production.ProductModelProductDescriptionCulture AS PMPDC 
                      ON PM.ProductModelID = PMPDC.ProductModelID 
                      INNER JOIN Production.ProductDescription AS PD 
                      ON PMPDC.ProductDescriptionID = PD.ProductDescriptionID 
                      WHERE (PMPDC.CultureID = 'en')">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>