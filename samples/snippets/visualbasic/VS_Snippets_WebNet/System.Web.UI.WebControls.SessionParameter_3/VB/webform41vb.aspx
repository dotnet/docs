<!-- <Snippet1> -->
<%@ Page language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
Private Sub Page_Load(sender As Object, e As EventArgs)

    Dim OdbcToSql As New SqlDataSource()

    ' Connect to SQL Server using an ODBC DSN.
    OdbcToSql.ProviderName= "System.Data.Odbc"
    OdbcToSql.ConnectionString = "dsn=MyOdbcDsn;"

    ' Use an ODBC parameterized query syntax.
    OdbcToSql.SelectCommand = "SELECT EmployeeID FROM Employees " & _
                              " WHERE Country = ? AND ReportsTo = ?"

    ' The country parameter has no default value, so be sure to set
    ' a Session variable named "country" to "UK" or "USA".
    Dim country As SessionParameter
    country = New SessionParameter("country",TypeCode.String,"country")

    Dim reportsTo As SessionParameter
    reportsTo = New SessionParameter("report",TypeCode.Int32,"report")
    reportsTo.DefaultValue = "2"

    OdbcToSql.SelectParameters.Add(country)
    OdbcToSql.SelectParameters.Add(reportsTo)

    ' Add the DataSourceControl to the page's Controls collection.
    Page.Controls.Add(OdbcToSql)

    DataGrid1.DataSource = OdbcToSql
    DataGrid1.DataBind()

End Sub ' Page_Load

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
      <asp:DataGrid
          id="DataGrid1"
          style="Z-INDEX: 101; LEFT: 56px; POSITION: absolute; TOP: 56px"
          runat="server" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->