<!-- <Snippet1> -->

<%@ Page language="VB" autoeventwireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomerDetailsView_ItemInserted(ByVal sender As Object, _
    ByVal e As DetailsViewInsertedEventArgs) _
    Handles CustomerDetailsView.ItemInserted

    ' Use the Exception property to determine whether an exception
    ' occurred during the insert operation.
    If e.Exception Is Nothing And e.AffectedRows = 1 Then
    
      ' Use the Values property to get the value entered by 
      ' the user for the CompanyName field.
      Dim name As String = e.Values("CompanyName").ToString()

      ' Display a confirmation message.
      MessageLabel.Text = name & " added successfully. "
    
    Else
    
      ' Insert the code to handle the exception.
      MessageLabel.Text = e.Exception.Message
      
      ' Use the ExceptionHandled property to indicate that the 
      ' exception is already handled.
      e.ExceptionHandled = True
      
      ' When an exception occurs, keep the DetailsView
      ' control in insert mode.
      e.KeepInInsertMode = True
    
    End If
        
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewInsertedEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewInsertedEventArgs Example</h3>
                
        <asp:detailsview id="CustomerDetailsView"
          datasourceid="DetailsViewSource"
          datakeynames="CustomerID"
          autogenerateinsertbutton="true"  
          autogeneraterows="true"
          allowpaging="true"
          runat="server">
               
          <fieldheaderstyle backcolor="Navy"
            forecolor="White"/>
                    
        </asp:detailsview>
        
        <asp:label id="MessageLabel"
          forecolor="Red"
          runat="server"/>
            
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the web.config file.                            -->
        <asp:sqldatasource id="DetailsViewSource"
          selectcommand="Select [CustomerID], [CompanyName], [Address], 
            [City], [PostalCode], [Country] From [Customers]"
          insertcommand="INSERT INTO [Customers]([CustomerID], [CompanyName], 
            [Address], [City], [PostalCode], [Country]) 
            VALUES (@CustomerID, @CompanyName, @Address, @City, 
            @PostalCode, @Country)"
          connectionstring=
            "<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->