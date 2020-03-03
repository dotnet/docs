<!-- <Snippet1> -->

<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void Page_Load(Object sender, EventArgs e)
  {

    // Create a new DetailsView object.
    DetailsView customerDetailsView = new DetailsView();

    // Set the DetailsView object's properties.
    customerDetailsView.ID = "CustomerDetailsView";
    customerDetailsView.DataSourceID = "DetailsViewSource";
    customerDetailsView.AutoGenerateRows = true;
    customerDetailsView.AllowPaging = true;
    customerDetailsView.DataKeyNames = new String[1] { "CustomerID" };

    // Add a button field to the DetailsView control.
    ButtonField field = new ButtonField();
    field.ButtonType = ButtonType.Link;
    field.CausesValidation = false;
    field.Text = "Add to List";
    field.CommandName="Add";

    customerDetailsView.Fields.Add(field);

    // Programmatically register the event-handling method
    // for the ItemDeleting event of a DetailsView control.
    customerDetailsView.ItemCommand 
      += new DetailsViewCommandEventHandler( 
      this.CustomerDetailsView_ItemCommand);

    // Add the DetailsView object to the Controls collection
    // of the PlaceHolder control.
    DetailsViewPlaceHolder.Controls.Add(customerDetailsView);

  }
  
  void CustomerDetailsView_ItemCommand(Object sender, 
    DetailsViewCommandEventArgs e)
  {

    // Use the CommandName property to determine which button
    // was clicked. 
    if (e.CommandName == "Add")
    {
      // Get the DetailsView control that raised the event.
      DetailsView customerDetailsView = (DetailsView)e.CommandSource;

      // Add the current customer to the customer list. 

      // Get the row that contains the company name. In this
      // example, the company name is in the second row (index 1)  
      // of the DetailsView control.
      DetailsViewRow row = customerDetailsView.Rows[1];

      // Get the company's name from the appropriate cell.
      // In this example, the company name is in the second cell  
      // (index 1) of the row.
      String name = row.Cells[1].Text;

      // Create a ListItem object with the company name.
      ListItem item = new ListItem(name);

      // Add the ListItem object to the ListBox, if the 
      // item doesn't already exist.
      if (!CustomerListBox.Items.Contains(item))
      {
        CustomerListBox.Items.Add(item);
      }

    }

  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewCommandEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>DetailsViewCommandEventHandler Example</h3>
      
      <!-- Use a PlaceHolder control as the container for the -->
      <!-- dynamically generated DetailsView control.         -->       
      <asp:placeholder id="DetailsViewPlaceHolder"
        runat="server"/>
      
      <br/><br/>
      
      Selected Customers:<br/>
      <asp:listbox id="CustomerListBox"
        runat="server"/>
      
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the web.config file.                            -->
      <asp:sqldatasource id="DetailsViewSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], 
          [City], [PostalCode], [Country] From [Customers]"
        connectionstring=
            "<%$ ConnectionStrings:NorthWindConnectionString%>" 

        runat="server"/>  
  
    </form>
  </body>
</html>
<!-- </Snippet1> -->