<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create a new GridView control.
    Dim customersGridView As New GridView()
    
    ' Set the GridView control's properties.
    customersGridView.ID = "CustomersGridView"
    customersGridView.DataSourceID = "CustomersSqlDataSource"
    customersGridView.AutoGenerateColumns = True
    customersGridView.AutoGenerateEditButton = True
    customersGridView.AllowPaging = True
    
    Dim keyArray() As String = {"CustomerID"}
    customersGridView.DataKeyNames = keyArray

    ' Programmatically register the event-handling method
    ' for the RowDeleted event of the GridView control.
    AddHandler customersGridView.RowUpdated, AddressOf CustomersGridView_RowUpdated
    AddHandler customersGridView.RowCancelingEdit, AddressOf CustomersGridView_RowCancelingEdit
    AddHandler customersGridView.RowEditing, AddressOf CustomersGridView_RowEditing
    
    ' Add the GridView control to the Controls collection
    ' of the PlaceHolder control.
    GridViewPlaceHolder.Controls.Add(customersGridView)
    
  End Sub

  Sub CustomersGridView_RowUpdated(ByVal sender As Object, ByVal e As GridViewUpdatedEventArgs)
    
    ' Indicate whether the update operation succeeded.
    If e.Exception Is Nothing Then
    
      Message.Text = "Row updated successfully."
    
    Else
    
      e.ExceptionHandled = True
      Message.Text = "An error occurred while attempting to update the row."
    
    End If
    
  End Sub

  Sub CustomersGridView_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        
    ' The update operation was canceled. Clear the message label.
    Message.Text = ""
    
  End Sub

  Sub CustomersGridView_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
  
    ' The GridView control is entering edit mode. Clear the message label.
    Message.Text = ""
    
  End Sub
    

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView GridViewUpdatedEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView GridViewUpdatedEventHandler Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"          
        runat="server"/>
                
      <br/>
            
      <asp:placeholder id="GridViewPlaceHolder"
        runat="server"/>
            
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