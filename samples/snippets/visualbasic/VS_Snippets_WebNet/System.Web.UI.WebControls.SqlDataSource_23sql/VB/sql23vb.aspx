<!-- <Snippet1> -->
<%@ Page language="vb" %>

<!--

The page uses an example configuration that includes
connection strings and a defined SqlCacheDependecy.

<?xml version="1.0"?>
<configuration>

  <connectionStrings>
    <add name="MyNorthwind"
         connectionString="Data Source="localhost";Integrated Security="SSPI";Initial Catalog="Northwind""
         providerName="System.Data.SqlClient" />
  </connectionStrings>

  <system.web>
    <caching>
      <sqlCacheDependency enabled="true">
        <databases>
          <add
            name="Northwind"
            connectionStringName="MyNorthwind"
            pollTime="120000" />
        </databases>
      </sqlCacheDependency>
    </caching>

  </system.web>
</configuration>
-->

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">

        <asp:gridview
          id="GridView1"
          runat="server"
          datasourceid="SqlDataSource1" />

        <asp:sqldatasource
          id="SqlDataSource1"
          runat="server"
          connectionstring="<%$ ConnectionStrings:MyNorthwind%>"
          selectcommand="SELECT EmployeeID,FirstName,Lastname FROM Employees"
          enablecaching="True"
          cacheduration="300"
          cacheexpirationpolicy="Absolute"
          sqlcachedependency="Northwind:Employees" />

    </form>
  </body>
</html>
<!-- </Snippet1> -->