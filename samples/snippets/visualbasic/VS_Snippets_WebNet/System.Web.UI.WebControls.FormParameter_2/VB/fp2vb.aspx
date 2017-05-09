<!-- <Snippet1> -->
<%@Page  Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

Private Sub Page_Load(sender As Object, e As EventArgs)

  ' You can add a FormParameter to the AccessDataSource control's
  ' SelectParameters collection programmatically.
  AccessDataSource1.SelectParameters.Clear()

  ' Security Note: The AccessDataSource uses a FormParameter,
  ' Security Note: which does not perform validation of input from the client.
  ' Security Note: To validate the value of the FormParameter,
  ' Security Note: handle the Selecting event.

  Dim formParam As New FormParameter("lastname","LastNameBox")
  formParam.Type=TypeCode.String
  AccessDataSource1.SelectParameters.Add(formParam)
End Sub ' Page_Load

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <asp:accessdatasource
          id="AccessDataSource1"
          runat="server"
          datasourcemode="DataSet"
          datafile="Northwind.mdb"
          selectcommand="SELECT OrderID,CustomerID,OrderDate,RequiredDate,ShippedDate
                         FROM Orders WHERE EmployeeID =
                         (SELECT EmployeeID FROM Employees WHERE LastName = @lastname)">
      </asp:accessdatasource>

      <br />Enter the name "Davolio" or "King" in the text box and click the button.

      <br />
      <asp:textbox
        id="LastNameBox"
        runat="server" />

      <br />
      <asp:button
        id="Button1"
        runat="server"
        text="Get Records" />

      <br />
      <asp:gridview
          id="GridView1"
          runat="server"
          allowsorting="True"
          datasourceid="AccessDataSource1">
      </asp:gridview>

    </form>
  </body>
</html>
<!-- </Snippet1> -->