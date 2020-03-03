<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {
        
    // Create a new GridView control.
    GridView customersGridView = new GridView();

    // Set the GridView control's properties.
    customersGridView.ID = "CustomersGridView";
    customersGridView.DataSourceID = "CustomersSqlDataSource";
    customersGridView.AutoGenerateColumns = true;
    customersGridView.AutoGenerateEditButton = true;
    customersGridView.AllowPaging = true;
    customersGridView.DataKeyNames = new String[] { "CustomerID" };
      
    // Programmatically register the event-handling method.
    customersGridView.RowEditing += new GridViewEditEventHandler(this.CustomersGridView_RowEditing);
        
    // Add the GridView control to the Controls collection
    // of the PlaceHolder control.
    GridViewPlaceHolder.Controls.Add(customersGridView);
        
  }

  void CustomersGridView_RowEditing(Object sender, GridViewEditEventArgs e)
  {

    // User the sender parameter to retrieve the GridView control
    // that raised the event.
    GridView customersGridView = (GridView)sender;
    
    // Get the country for the row being edited. For this example, the
    // country is contained in the seventh column (index 6). 
    String country = customersGridView.Rows[e.NewEditIndex].Cells[6].Text;

    // For this example, cancel the edit operation if the user attempts
    // to edit the record of a customer from the USA. 
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
    <title>GridViewEditEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewEditEventHandler Example</h3>
          
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
                
      <br/>
            
      <asp:placeholder id="GridViewPlaceHolder"
        runat="server"/>
            
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