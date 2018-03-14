<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomersGridView_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
    
    ' Cancel the paging operation if the user attempts to navigate
    ' to another page while the GridView control is in edit mode. 
    If CustomersGridView.EditIndex <> -1 Then
    
      ' Use the Cancel property to cancel the paging operation.
      e.Cancel = True
      
      ' Display an error message.
      Dim newPageNumber As Integer = e.NewPageIndex + 1
      Message.Text = "Please update the record before moving to page " & _
        newPageNumber.ToString() & "."
    
    Else
    
      ' Clear the error message.
      Message.Text = ""
    
    End If
    
  End Sub

  Sub CustomersGridView_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
  
    ' Clear the error message.
    Message.Text = ""
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView PageIndexChanging Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView PageIndexChanging Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
                
      <br/>  

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="true"
        emptydatatext="No data available." 
        allowpaging="true"
        autogenerateeditbutton="true"
        datakeynames="CustomerID"  
        onpageindexchanging="CustomersGridView_PageIndexChanging"
        onrowcancelingedit="CustomersGridView_RowCancelingEdit" 
        runat="server">
                
        <pagersettings mode="Numeric"
          position="Bottom"           
          pagebuttoncount="10"/>
                      
        <pagerstyle backcolor="LightBlue"/>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        updatecommand="Update Customers SET CompanyName=@CompanyName, Address=@Address, City=@City, PostalCode=@PostalCode, Country=@Country WHERE (CustomerID = @CustomerID)"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->