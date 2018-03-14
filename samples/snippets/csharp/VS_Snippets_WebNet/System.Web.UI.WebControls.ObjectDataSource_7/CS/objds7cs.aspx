<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS" Assembly="Samples.AspNet.CS" %>
<%@ Page language="c#" %>

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
    <cache>
      <sqlCacheDependency enabled="true">
        <databases>
          <add
            name="Northwind"
            connectionStringName="MyNorthwind"
            pollTime="120000" />
        </databases>
      </sqlCacheDependency>
    </cache>

  </system.web>
</configuration>
-->



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ObjectDataSource - C# Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">

        <asp:gridview
          id="GridView1"
          runat="server"
          datasourceid="ObjectDataSource1" />

        <asp:objectdatasource
          id="ObjectDataSource1"
          runat="server"
          typename="Samples.AspNet.CS.EmployeeLogic"
          selectmethod="GetAllEmployeesAsDataSet"
          enablecaching="True"
          cacheduration="300"
          cacheexpirationpolicy="Absolute"
          sqlcachedependency="Northwind:Employees" />

    </form>
  </body>
</html>
<!-- </Snippet1> -->