<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomersGridView_RowEditing(Object sender, GridViewEditEventArgs e)
  {
    
    // Get the country for the row being edited. For this example, the
    // country is contained in the seventh column (index 6). 
    String country = CustomersGridView.Rows[e.NewEditIndex].Cells[6].Text;

    // For this example, cancel the edit operation if the user attempts
    // to edit the record of a customer from the Unites States. 
    if (country == "USA")
    {
      // Cancel the edit operation.
      e.Cancel = true;
      Message.Text = "You cannot edit this record.";
    }
    else
    {
      Message.Text = "";
    }
    
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView RowEditing Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView RowEditing Example</h3>
          
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
                
      <br/>
            
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
        onrowediting="CustomersGridView_RowEditing"   
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