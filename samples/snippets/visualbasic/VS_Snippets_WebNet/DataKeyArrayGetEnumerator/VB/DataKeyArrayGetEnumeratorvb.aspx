<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomerGridView_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles CustomerGridView.DataBound

    ' Use the Count property to determine whether the
    ' DataKeys collection contains any items.
    If CustomerGridView.DataKeys.Count > 0 Then

      MessageLabel.Text = "The primary key of each record displayed are: <br/><br/>"

      ' Use the GetEnumerator method to create an enumerator that 
      ' contains the DataKey objects for the GridView control.
      Dim keyEnumerator As IEnumerator = CustomerGridView.DataKeys.GetEnumerator()

      ' Iterate though the enumerator and display the primary key
      ' value of each record displayed.
      While keyEnumerator.MoveNext()
      
        Dim key As DataKey = CType(keyEnumerator.Current, DataKey)
        MessageLabel.Text &= key.Value.ToString() & "<br/>"
      
      End While

    Else
    
      MessageLabel.Text = "No DataKey objects."
    
    End If

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

  <head runat="server">
    <title>DataKeyArray Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DataKeyArray Example</h3>
                       
        <asp:gridview id="CustomerGridView"
          datasourceid="CustomerDataSource"
          autogeneratecolumns="true"
          datakeynames="CustomerID"  
          allowpaging="true"
          runat="server">
            
        </asp:gridview>
        
        <br/>
        
        <asp:label id="MessageLabel"
          forecolor="Red"
          runat="server"/>
            
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the Web.config file.                            -->
        <asp:sqldatasource id="CustomerDataSource"
          selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
          connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->