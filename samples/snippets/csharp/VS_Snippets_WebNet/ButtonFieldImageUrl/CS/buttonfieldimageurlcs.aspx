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
      TableCell lastNameCell = selectedRow.Cells[1];
      string lastName = lastNameCell.Text;  
    
      // Display the selected author.
      Message.Text = "You selected " + lastName + ".";
      
    }
    
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ButtonField ImageUrl Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>ButtonField ImageUrl Example</h3>
      
      <asp:label id="Message"
        forecolor="Red"
        runat="server"
        AssociatedControlID="CustomersGridView"/>
                    
      <!-- Set the ImageUrl property of the ButtonField declaratively. -->
      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="false"
        onrowcommand="CustomersGridView_RowCommand"
        runat="server">
                
        <columns>
                
          <asp:buttonfield buttontype="Image" 
            commandname="Select"
            headertext="Select Author"
            ImageUrl="~\images\ButtonImage.jpg"/>
          <asp:boundfield datafield="ContactName" 
            headertext="ContactName"/>
          <asp:boundfield datafield="ContactTitle" 
            headertext="ContactTitle"/>
                
        </columns>
                
      </asp:gridview>
            
        <!-- This example uses Microsoft SQL Server and connects -->
        <!-- to the Northwind sample database.                   -->
        <asp:sqldatasource id="CustomersSqlDataSource"  
          selectcommand="Select [CustomerID], [ContactName], [ContactTitle] From [Customers]"
          connectionstring="<%$ ConnectionStrings:NorthWindConnection%>"
          runat="server">
        </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->