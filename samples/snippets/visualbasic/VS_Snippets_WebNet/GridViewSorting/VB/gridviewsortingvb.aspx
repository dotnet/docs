<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub CustomersGridView_Sorting(sender As Object, e As GridViewSortEventArgs)
  
    ' Cancel the sorting operation if the user attempts
    ' to sort by address.
    If e.SortExpression = "Address" Then
    
      e.Cancel = True
      Message.Text = "You cannot sort by address."
      SortInformationLabel.Text = ""
    
    Else
    
      Message.Text = ""
      
    End If
    
  End Sub

  Sub CustomersGridView_Sorted(ByVal sender As Object, ByVal e As EventArgs)
 
    ' Display the sort expression and sort direction.
    SortInformationLabel.Text = "Sorting by " & _
      CustomersGridView.SortExpression.ToString() & _
      " in " & CustomersGridView.SortDirection.ToString() & _
      " order."
    
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView Sorted and Sorting Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView Sorted and Sorting Example</h3>

      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
        
      <br/>
        
      <asp:label id="SortInformationLabel"
        forecolor="Navy"
        runat="server"/>
                
      <br/>  

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="true"
        allowpaging="true"
        emptydatatext="No data available." 
        allowsorting="true"
        onsorting="CustomersGridView_Sorting"
        onsorted="CustomersGridView_Sorted"  
        runat="server">
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
        
    </form>
  </body>
</html>

<!-- </Snippet1> -->