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
    
      // Get the last name of the selected Customer from the appropriate
      // cell in the GridView control.
      GridViewRow selectedRow = CustomersGridView.Rows[index];
      TableCell contactCell = selectedRow.Cells[1];
      string contact = contactCell.Text;  
    
      // Display the selected Customer.
      Message.Text = "You selected " + contact + ".";
      
    }
    
  }

  void Page_Load(Object sender, EventArgs e)
  {
  
    // The field columns need to be created only the first time
    // the page is loaded.
    if (!IsPostBack)
    {
      
      // Dynamically create field columns to display the desired
      // fields from the data source.
      
      // Create a ButtonField object to allow the user to 
      // select an Customer.
      ButtonField selectButtonField = new ButtonField ();

      selectButtonField.ButtonType = ButtonType.Button;
      selectButtonField.CommandName = "Select";
      selectButtonField.HeaderText = "Select Customer";
      selectButtonField.Text = "Select";

      // Create a BoundField object to display an Customer's last name.
      BoundField contactNameBoundField = new BoundField();

      contactNameBoundField.DataField = "ContactName";
      contactNameBoundField.HeaderText = "Contact Name";

      // Create a BoundField object to display an Customer's first name.
      BoundField contactTitleBoundField = new BoundField();

      contactTitleBoundField.DataField = "ContactTitle";
      contactTitleBoundField.HeaderText = "Contact Title";

      // Add the field columns to the Columns collection of the
      // GridView control.
      CustomersGridView.Columns.Add (selectButtonField);
      CustomersGridView.Columns.Add(contactNameBoundField);
      CustomersGridView.Columns.Add(contactTitleBoundField);
      
    }
    
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ButtonField Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>ButtonField Constructor Example</h3>

      <asp:label id="Message"
        forecolor="Red"
        runat="server"
        AssociatedControlID="CustomersGridView"/>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="False"
        onrowcommand="CustomersGridView_RowCommand"
        runat="server">                
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