<!--<Snippet1>-->
<%@ Page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
Private Sub Page_Load(sender As Object, e As EventArgs)
    Dim param1 As New QueryStringParameter("employee", "employee")
    MyAccessDataSource.SelectParameters.Add(param1)

    Dim param2 As New QueryStringParameter("country", "country")
    MyAccessDataSource.SelectParameters.Add(param2)
End Sub ' Page_Load
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">

      <!-- Use a Query String that includes employee=1&country=USA -->
      <asp:gridview
        id ="GridView1"
        runat="server"
        datasourceid="MyAccessDataSource" />

<!-- Security Note: The SqlDataSource uses a QueryStringParameter,
     Security Note: which does not perform validation of input from the client.
     Security Note: To validate the value of the QueryStringParameter, handle the Selecting event. -->

      <asp:accessdatasource
        id="MyAccessDataSource"
        runat="server"
        datafile="Northwind.mdb"
        selectcommand="SELECT EmployeeID, LastName, FirstName
                       FROM Employees
                       WHERE EmployeeID = ? AND Country = ? ">
      </asp:accessdatasource>
    </form>
  </body>
</html>
<!--</Snippet1>-->