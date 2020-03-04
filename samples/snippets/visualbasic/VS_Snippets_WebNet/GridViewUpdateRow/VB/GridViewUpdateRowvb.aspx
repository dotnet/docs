<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub UpdateRowButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      
    ' Programmatically update the current record in edit mode.
    CustomersGridView.UpdateRow(CustomersGridView.EditIndex, True)
    
  End Sub

  Sub CustomersGridView_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
  
    ' Enable the UpdateRowButton button only when the GridView control
    ' is in edit mode.
    Select Case e.CommandName
    
      Case "Edit"
        UpdateRowButton.Enabled = True
      Case "Cancel"
        UpdateRowButton.Enabled = False
      Case "Update"
        UpdateRowButton.Enabled = False
      Case Else
        UpdateRowButton.Enabled = False
    
    End Select
    
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView UpdateRow Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView UpdateRow Example</h3>
      
      <asp:button id="UpdateRowButton"
        text="Update Record"
        enabled="false"
        onclick="UpdateRowButton_Click" 
        runat="server"/>
        
      <hr/>

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
        runat="server">
      </asp:gridview>
            
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