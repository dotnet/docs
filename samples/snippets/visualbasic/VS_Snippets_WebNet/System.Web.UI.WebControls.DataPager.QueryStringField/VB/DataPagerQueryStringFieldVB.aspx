<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DataPager QueryStringField Example</h3>
      
      <asp:DataPager runat="server" ID="DataPager1"
        PagedControlID="CountriesListView" 
        QueryStringField="pageNumber">
        <Fields>
          <asp:NumericPagerField />
        </Fields>
      </asp:DataPager>
      <br /><br />

      <asp:ListView ID="CountriesListView" 
        DataSourceID="CountryDataSource"
        runat="server" >
        <LayoutTemplate>
          <table cellpadding="4" width="500" runat="server" id="tblCountries">
            <tr runat="server">
              <th runat="server">Code</th>
              <th runat="server">Name</th>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr>
            <td>
              <asp:Label ID="CountryCodeLabel" runat="server" 
                Text='<%# Eval("CountryRegionCode")%>' />
            </td>          
            <td>
              <asp:Label ID="NameLabel" runat="server" 
                Text='<%# Eval("Name")%>' />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>
      <br />

      <!-- The second DataPager control. -->
      <asp:DataPager runat="server" ID="DataPager2"
        PagedControlID="CountriesListView" 
        QueryStringField="pageNumber">
        <Fields>
          <asp:NumericPagerField />
        </Fields>
      </asp:DataPager>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="CountryDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [CountryRegionCode], [Name]
          FROM [Person].[CountryRegion]">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>