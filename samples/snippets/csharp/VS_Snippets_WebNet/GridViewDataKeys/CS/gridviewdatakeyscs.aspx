<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomersGridView_SelectedIndexChanged(Object sender, EventArgs e)
  {
    
    // Determine the index of the selected row.
    int index = CustomersGridView.SelectedIndex;
        
    // Display the primary key value of the selected row.
    Message.Text = "The primary key value of the selected row is " +
        CustomersGridView.DataKeys[index].Value.ToString() + ".";
    
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView DataKeys Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView DataKeys Example</h3>

      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
               
      <br/><br/>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="true"
        emptydatatext="No data available." 
        autogenerateselectbutton="true"    
        datakeynames="CustomerID"
        onselectedindexchanged="CustomersGridView_SelectedIndexChanged"
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