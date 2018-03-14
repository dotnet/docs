<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomersGridView_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs)
  
    ' Use the Exception property to determine whether an exception
    ' occurred during the update operation.
    If e.Exception Is Nothing Then
    
      ' Sometimes an error might occur that does not raise an 
      ' exception, but prevents the update operation from 
      ' completing. Use the AffectedRows property to determine 
      ' whether the record was actually updated. 
      If e.AffectedRows = 1 Then
      
        ' Use the Keys property to get the value of the key field.
        Dim keyFieldValue As String = e.Keys("CustomerID").ToString()

        ' Display a confirmation message.
        Message.Text = "Record " & keyFieldValue & _
          " updated successfully. "

        ' Display the new and original values.
        DisplayValues(CType(e.NewValues, OrderedDictionary), CType(e.OldValues, OrderedDictionary))

      Else
      
        ' Display an error message.
        Message.Text = "An error occurred during the update operation."

        ' When an error occurs, keep the GridView
        ' control in edit mode.
        e.KeepInEditMode = True
        
      End If
    
    Else
    
      ' Insert the code to handle the exception.
      Message.Text = e.Exception.Message

      ' Use the ExceptionHandled property to indicate that the 
      ' exception is already handled.
      e.ExceptionHandled = True

      e.KeepInEditMode = True
    
    End If
  
  End Sub

  Sub DisplayValues(ByVal newValues As OrderedDictionary, ByVal oldValues As OrderedDictionary)

    Message.Text &= "<br/></br>"

    ' Iterate through the new and old values. Display the
    ' values on the page.
    Dim i As Integer
    For i = 0 To oldValues.Count - 1
    
      Message.Text &= "Old Value=" & oldValues(i).ToString() & _
        ", New Value=" & newValues(i).ToString() & "<br/>"
    Next

    Message.Text &= "</br>"

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewUpdatedEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewUpdatedEventArgs Example</h3>
            
      <!-- The GridView control automatically sets the columns     -->
      <!-- specified in the datakeynames property as read-only.    -->
      <!-- No input controls are rendered for these columns in     -->
      <!-- edit mode.                                              -->
      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="true"
        autogenerateeditbutton="true"
        allowpaging="true" 
        datakeynames="CustomerID"
        onrowupdated="CustomersGridView_RowUpdated" 
        runat="server">
      </asp:gridview>
      
      <br/>
      
      <asp:label id="Message"
        forecolor="Red"          
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