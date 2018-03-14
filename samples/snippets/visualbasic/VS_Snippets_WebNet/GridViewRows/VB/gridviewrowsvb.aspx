<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomersGridView_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
    
    ' Clear the message label when the user enters edit mode.
    If e.CommandName = "Edit" Then
      Message.Text = ""
    End If
    
  End Sub
  
  Sub CustomersGridView_RowUpdated(ByVal sender As Object, ByVal e As GridViewUpdatedEventArgs)
   
    ' The update operation was successful. Retrieve the row being edited.
    Dim index As Integer = CustomersGridView.EditIndex
    Dim row As GridViewRow = CustomersGridView.Rows(index)
        
    ' Notify the user that the update was successful.
    Message.Text = "Updated record " & row.Cells(1).Text + "."
    
  End Sub

  Sub CustomersGridView_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
   
    ' The update operation was canceled. Display the appropriate message.
    Message.Text = "Update operation canceled."
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView Rows Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView Rows Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
                
      <br/>    
            
      <!-- The GridView control automatically sets the columns     -->
      <!-- specified in the datakeynames property as read-only.    -->
      <!-- No input controls are rendered for these columns in     -->
      <!-- edit mode.                                              -->
      <asp:gridview id="CustomersGridView"
        allowpaging="true" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="true"
        autogenerateeditbutton="true"
        datakeynames="CustomerID"
        onrowcommand="CustomersGridView_RowCommand"
        onrowupdated="CustomersGridView_RowUpdated"
        onrowcancelingedit="CustomersGridView_RowCancelingEdit"  
        runat="server">
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        updatecommand="Update Customers SET CompanyName=@CompanyName, Address=@Address, City=@City, PostalCode=@PostalCode, Country=@Country WHERE (CustomerID = @CustomerID)"
        deletecommand="Delete from Customers where CustomerID = @CustomerID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->