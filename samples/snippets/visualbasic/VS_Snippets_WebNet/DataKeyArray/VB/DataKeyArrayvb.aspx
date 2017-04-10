<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomerGridView_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles CustomerGridView.DataBound
    
    ' Display the the value of the primary key for each
    ' record in the GridView control.
    MessageLabel.Text = "The primary key of each record displayed are: <br/><br/>"

    Dim key As DataKey
    For Each key In CustomerGridView.DataKeys
    
      MessageLabel.Text += key.Value.ToString() + "<br/>"
      
    Next
    
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