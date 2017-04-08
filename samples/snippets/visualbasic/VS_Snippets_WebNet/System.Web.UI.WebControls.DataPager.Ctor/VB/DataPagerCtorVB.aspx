<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  ' <Snippet2>  
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    ' Create a new DataPager object.
    Dim CountryDataPager As New DataPager()
        
    ' Set the DataPager object's properties.
    CountryDataPager.PagedControlID = CountryListView.ID
    CountryDataPager.PageSize = 15
    CountryDataPager.Fields.Add(New NumericPagerField())
        
    ' Add the DataPager object to the Controls collection
    ' of the form.
    form1.Controls.Add(CountryDataPager)

    CountryListView.DataBind()
    
  End Sub
  ' </Snippet2>
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>DataPager Constructor Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
      
      <h3>DataPager Constructor Example</h3>

      <asp:ListView ID="CountryListView" 
        DataSourceID="CountryDataSource"
        runat="server">
        <LayoutTemplate>
          <ul runat="server" id="CountryList">
            <li runat="server" id="itemPlaceholder"></li>
          </ul>
        </LayoutTemplate>
        <ItemTemplate>
          <li runat="server">
            <asp:Label runat="server" ID="CountryLabel" 
              Text='<%# Eval("CountryRegionCode") & " - " & Eval("Name") %>' />
          </li>
        </ItemTemplate>
      </asp:ListView>

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