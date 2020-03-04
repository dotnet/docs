<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomersGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
  {
  
    // If multiple ButtonField column fields are used, use the
    // CommandName property to determine which button was clicked.
    if(e.CommandName=="Select")
    {
    
      // Convert the row index stored in the CommandArgument
      // property to an Integer.
      int index = Convert.ToInt32(e.CommandArgument);    
    
      // Get the last name of the selected author from the appropriate
      // cell in the GridView control.
      GridViewRow selectedRow = CustomersGridView.Rows[index];
      TableCell contactName = selectedRow.Cells[1];
      string contact = contactName.Text;  
    
      // Display the selected author.
      Message.Text = "You selected " + contact + ".";
      
    }
    
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ButtonField Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>ButtonField Example</h3>
      
      <asp:label id="Message"
        forecolor="Red"
        runat="server"
        AssociatedControlID="CustomersGridView"/>
                    
      <!-- Populate the Columns collection declaratively. -->
      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="false"
        onrowcommand="CustomersGridView_RowCommand"
        runat="server">
                
        <columns>
                
          <asp:buttonfield buttontype="Button" 
            commandname="Select"
            headertext="Select Customer" 
            text="Select"/>
          <asp:boundfield datafield="CompanyName" 
            headertext="Company Name"/>
          <asp:boundfield datafield="ContactName" 
            headertext="Contact Name"/>
                
        </columns>
                
      </asp:gridview>
            
        <!-- This example uses Microsoft SQL Server and connects -->
        <!-- to the Northwind sample database.                   -->
        <asp:sqldatasource id="CustomersSqlDataSource"  
          selectcommand="Select [CustomerID], [CompanyName], [ContactName], [ContactTitle] From [Customers]"
          connectionstring="<%$ ConnectionStrings:NorthWindConnection%>"
          runat="server">
        </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->