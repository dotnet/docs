<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomersGridView_RowCancelingEdit(Object sender, GridViewCancelEditEventArgs e)
  {
    
    // Retrieve the row that raised the event from the Rows
    // collection of the GridView control.
    GridViewRow row = CustomersGridView.Rows[e.RowIndex];
    
    // The update operation was canceled. Display the 
    // primary key of the row. In this example, the primary
    // key is displayed in the second column of the GridView
    // control. To access the text of the column, use the Cells
    // collection of the row.
    Message.Text = "Update for item " + row.Cells[1].Text + " Canceled."; 
    
  }

  void CustomersGridView_RowEditing(Object sender, GridViewEditEventArgs e)
  {

    // The GridView control is entering edit mode. Clear the message label.
    Message.Text = "";

  }
  
  void CustomersGridView_RowUpdated(Object sender, GridViewUpdatedEventArgs e)
  {

    // The update operation was successful. Clear the message label.
    Message.Text = "";

  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView RowCancelingEdit Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView RowCancelingEdit Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
                
      <br/>
      
      <!-- The GridView control automatically sets the columns     -->
      <!-- specified in the datakeynames attribute as read-only.   -->
      <!-- No input controls are rendered for these columns in     -->
      <!-- edit mode.                                              -->
      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="true"
        autogenerateeditbutton="true"
        allowpaging="true" 
        datakeynames="CustomerID"
        onrowcancelingedit="CustomersGridView_RowCancelingEdit"
        onrowediting="CustomersGridView_RowEditing" 
        onrowupdated="CustomersGridView_RowUpdated"    
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