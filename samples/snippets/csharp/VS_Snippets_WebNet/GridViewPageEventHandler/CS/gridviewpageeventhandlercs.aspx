<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {

    // Create a new GridView control.
    GridView customersGridView = new GridView();

    // Set the GridView object's properties.
    customersGridView.ID = "CustomersGridView";
    customersGridView.DataSourceID = "CustomersSource";
    customersGridView.AutoGenerateColumns = true;
    customersGridView.EmptyDataText = "No data available.";
    customersGridView.AllowPaging = true;
    customersGridView.AutoGenerateEditButton = true;
    customersGridView.PagerSettings.Mode = PagerButtons.Numeric;
    customersGridView.PagerSettings.Position = PagerPosition.Bottom;
    customersGridView.PagerSettings.PageButtonCount = 10;
    customersGridView.PagerStyle.BackColor = System.Drawing.Color.LightBlue;
    customersGridView.DataKeyNames = new String[] { "CustomerID" };

    // Programmatically register the event-handling methods.
    customersGridView.PageIndexChanging += new GridViewPageEventHandler(this.CustomersGridView_PageIndexChanging);
    customersGridView.RowCancelingEdit += new GridViewCancelEditEventHandler(this.CustomersGridView_RowCancelingEdit);

    // Add the GridView control to the Controls collection
    // of the PlaceHolder control.
    GridViewPlaceHolder.Controls.Add(customersGridView);
    
  }          

  void CustomersGridView_PageIndexChanging(Object sender, GridViewPageEventArgs e)
  {

    // User the sender parameter to retrieve the GridView control
    // that raised the event.
    GridView customersGridView = (GridView)sender;
    
    // Cancel the paging operation if the user attempts to navigate
    // to another page while the GridView control is in edit mode. 
    if (customersGridView.EditIndex != -1)
    {
      // Use the cancel property to cancel the paging operation.
      e.Cancel = true;
      
      // Display an error message.
      int newPageNumber = e.NewPageIndex + 1;
      Message.Text = "Please update the record before moving to page " +
        newPageNumber.ToString() + ".";
    }
    else
    {
      // Clear the error message.
      Message.Text = "";
    }
    
  }

  void CustomersGridView_RowCancelingEdit(Object sender, GridViewCancelEditEventArgs e)
  {
    // Clear the error message.
    Message.Text = "";
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewPageEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewPageEventHandler Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
                
      <br/>  

      <asp:placeholder id="GridViewPlaceHolder"
        runat="server" />
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        updatecommand="Update Customers SET CompanyName=@CompanyName, Address=@Address, City=@City, PostalCode=@PostalCode, Country=@Country WHERE (CustomerID = @CustomerID)"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->