<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {
        
    // Create a new GridView object.
    GridView customerGridView = new GridView();
         
    // Set the GridView object's properties.
    customerGridView.ID = "CustomersGridView";
    customerGridView.DataSourceID = "CustomersSqlDataSource";
    customerGridView.AutoGenerateColumns = true;
    customerGridView.AutoGenerateEditButton = true;
    customerGridView.DataKeyNames = new String[] { "CustomerID" };
        
    // Programmatically register the event-handling methods.
    customerGridView.RowCancelingEdit += new GridViewCancelEditEventHandler(this.CustomersGridView_RowCancelingEdit);
    customerGridView.RowUpdated += new GridViewUpdatedEventHandler(this.CustomersGridView_RowUpdated);
        
    // Add the GridView object to the Controls collection
    // of the PlaceHolder control.
    GridViewPlaceHolder.Controls.Add(customerGridView);
        
  }

  void CustomersGridView_RowCancelingEdit(Object sender, GridViewCancelEditEventArgs e)
  {
    
    // Display a message indicating that the update operation was canceled.
    Message.Text = "Update for row " + e.RowIndex.ToString() + " canceled."; 
    
  }

  void CustomersGridView_RowUpdated(Object sender, GridViewUpdatedEventArgs e)
  {

    // The update operation was successful. Clear the message label.
    Message.Text = "";

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewCancelEditEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewCancelEditEventHandler Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
                
      <br/>
            
      <asp:placeholder id="GridViewPlaceHolder"
        runat="Server"/>
            
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