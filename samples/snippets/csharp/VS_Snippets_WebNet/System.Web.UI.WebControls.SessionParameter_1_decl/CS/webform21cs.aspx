<!-- <Snippet1> -->
<%@ Page language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
      <p>Show My Orders:</p>

      <asp:SqlDataSource
          id="OdbcDataSource1"
          runat="server"
          ProviderName="System.Data.Odbc"
          ConnectionString="dsn=MyOdbcDsn;"
          SelectCommand="SELECT OrderId, CustomerId, OrderDate
                         FROM Orders
                         WHERE EmployeeID = ?
                         ORDER BY CustomerId ASC;">
          <SelectParameters>
              <asp:SessionParameter
                Name="empid"
                SessionField="empid"
                DefaultValue="5" />
          </SelectParameters>
      </asp:SqlDataSource>

      <p>
      <asp:GridView
          id="GridView1"
          runat="server"
          DataSourceID="OdbcDataSource1" />
      </p>
    </form>
  </body>
</html>
<!-- </Snippet1> -->