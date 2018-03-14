<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        
    ' Create a new GridView object.
    Dim customersGridView As New GridView()
         
    ' Set the GridView object's properties.
    customersGridView.ID = "CustomersGridView"
    customersGridView.DataSourceID = "CustomersSource"
    customersGridView.AutoGenerateColumns = True
        
    ' Add the GridView object to the Controls collection
    ' of the PlaceHolder control.
    GridViewPlaceHolder.Controls.Add(customersGridView)
        
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>GridView Constructor Example</h3>

      <asp:placeholder id="GridViewPlaceHolder"
        runat="Server"/>

      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSource"
        selectcommand="Select [CustomerID], [CompanyName], [City] From [Customers]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->