<!-- <Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <!-- This example uses a Northwind database that is hosted by an ODBC-compliant
         database. To run this sample, create an ODBC DSN to any database that hosts
         the Northwind database, including Microsoft SQL Server or Microsoft Access,
         change the name of the DSN in the ConnectionString, and view the page.
    -->
    <form id="form1" runat="server">
      <asp:SqlDataSource
          id="SqlDataSource1"
          runat="server"
          ProviderName="System.Data.Odbc"
          ConnectionString="dsn=myodbc3dsn;"
          SelectCommand="SELECT LastName FROM Employees;">
      </asp:SqlDataSource>

      <asp:ListBox
          id="ListBox1"
          runat="server"
          DataSourceID="SqlDataSource1"
          DataTextField="LastName">
      </asp:ListBox>

    </form>
  </body>
</html>
<!-- </Snippet1> -->