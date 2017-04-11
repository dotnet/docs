<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void CustomersGridView_Sorting(Object sender, GridViewSortEventArgs e)
  {
    // By default, the sort order toggles when the user clicks 
    // the same sort button repeatedly. For this example, cancel
    // the sort operation if the user attempts to sort in descending
    // order.
    if (e.SortDirection == SortDirection.Descending)
    {
      e.Cancel = true;
      Message.Text = "Sorting in descending order is not supported.";
    }
    else
    {
      Message.Text = "";
    }
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewSortEventArgs SortDirection Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewSortEventArgs SortDirection Example</h3>

      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
                
      <br/>  

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="true"
        allowpaging="true"
        emptydatatext="No data available." 
        allowsorting="true"
        onsorting="CustomersGridView_Sorting"
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