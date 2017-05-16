<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>DataPager PagedControlID Example</title>
</head>
<body>
    <form id="form1" runat="server">
      
      <h3>DataPager PagedControlID Example</h3>
      
      <asp:DataPager ID="DepartmentsPager" runat="server" 
        PagedControlID="DepartmentsListView">
        <Fields>
          <asp:NumericPagerField />
        </Fields>
      </asp:DataPager>
      
      <asp:ListView ID="DepartmentsListView" 
        DataSourceID="DepartmentsDataSource"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="500px">
            <tr>
              <th>Department Name</th>
              <th>Group</th>
            </tr>
            <tr runat="server" id="itemPlaceholder"></tr>
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
              <asp:Label ID="GroupNameLabel" runat="server" Text='<%# Eval("GroupName") %>' />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="DepartmentsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"            
        SelectCommand="SELECT Name, GroupName FROM HumanResources.Department" >
      </asp:SqlDataSource>
    </form>
  </body>
</html>
<%-- </Snippet1> --%>