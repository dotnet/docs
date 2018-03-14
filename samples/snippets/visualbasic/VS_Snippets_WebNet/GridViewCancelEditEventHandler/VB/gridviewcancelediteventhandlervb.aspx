<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        
    ' Create a new GridView object.
    Dim customerGridView As New GridView()
         
    ' Set the GridView object's properties.
    customerGridView.ID = "CustomersGridView"
    customerGridView.DataSourceID = "CustomersSqlDataSource"
    customerGridView.AutoGenerateColumns = True
    customerGridView.AutoGenerateEditButton = True
    customerGridView.DataKeyNames = New [String]() {"CustomerID"}
        
    ' Programmatically register the event-handling methods.
    AddHandler customerGridView.RowCancelingEdit, AddressOf CustomersGridView_RowCancelingEdit
    AddHandler customerGridView.RowUpdated, AddressOf CustomersGridView_RowUpdated
        
    ' Add the GridView object to the Controls collection
    ' of the PlaceHolder control.
    GridViewPlaceHolder.Controls.Add(customerGridView)
        
  End Sub
    
  Sub CustomersGridView_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
    
    ' Display a message indicating that the update operation was canceled.
    Message.Text = "Update for row " + e.RowIndex.ToString() + " canceled."
    
  End Sub
    
  Sub CustomersGridView_RowUpdated(ByVal sender As Object, ByVal e As GridViewUpdatedEventArgs)

    ' The update operation was successful. Clear the message label.
    Message.Text = ""

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewCancelEditEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewCancelEditEventHandler Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
                
      <br/>
            
      <asp:placeholder id="GridViewPlaceHolder"
        runat="Server"/>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        updatecommand="Update Customers SET CompanyName=@CompanyName, Address=@Address, City=@City, PostalCode=@PostalCode, Country=@Country WHERE (CustomerID = @CustomerID)"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->