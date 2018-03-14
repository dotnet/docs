<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void DeleteRowButton_Click(Object sender, EventArgs e)
  {
    // Programmatically delete the selected record.
    CustomersGridView.DeleteRow(CustomersGridView.SelectedIndex);
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView DeleteRow Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView DeleteRow Example</h3>

      <asp:button id="DeleteRowButton"
        text="Delete Record"
        onclick="DeleteRowButton_Click" 
        runat="server"/>

      <hr/>

      <asp:gridview id="CustomersGridView" 
        allowpaging="true"
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="true"
        autogenerateselectbutton="true"
        datakeynames="CustomerID"
        selectedindex="0"   
        runat="server">
        
        <selectedrowstyle BackColor="lightblue"/>
        
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        deletecommand="Delete from Customers where CustomerID = @CustomerID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->