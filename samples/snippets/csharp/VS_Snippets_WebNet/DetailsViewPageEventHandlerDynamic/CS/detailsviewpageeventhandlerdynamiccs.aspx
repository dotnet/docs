<!-- <Snippet1> -->

<%@ Page language="C#" %>

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
    customerDetailsView.AutoGenerateEditButton = true;
    customerDetailsView.AllowPaging = true;
    customerDetailsView.DataKeyNames = new String[1] { "CustomerID" };
    customerDetailsView.PagerSettings.Position = PagerPosition.Bottom;

    // Programmatically register the event-handling methods
    // for the DetailsView control.
    customerDetailsView.PageIndexChanging += new DetailsViewPageEventHandler(this.CustomerDetailsView_PageIndexChanging);
    customerDetailsView.ModeChanging += new DetailsViewModeEventHandler(this.CustomerDetailsView_ModeChanging);
    
    // Add the DetailsView object to the Controls collection
    // of the PlaceHolder control.
    DetailsViewPlaceHolder.Controls.Add(customerDetailsView);

  }
  
  void CustomerDetailsView_PageIndexChanging(Object sender, DetailsViewPageEventArgs e)
  {
    // Use the sender parameter to access the DetailsView control
    // that raised the event.
    DetailsView customerDetailsView = (DetailsView)sender;

    // Cancel the paging operation if the DetailsView control 
    // in edit mode.
    if (customerDetailsView.CurrentMode == DetailsViewMode.Edit)
    {
      e.Cancel = true;
      
      // Display an error message.
      int newPage = e.NewPageIndex + 1;
      MessageLabel.Text = "Please update the current record before to moving to page " + 
        newPage.ToString() + ".";
    }
  }

  void CustomerDetailsView_ModeChanging(Object sender, DetailsViewModeEventArgs e)
  {
    // Clear the message label when the user changes mode.
    MessageLabel.Text = "";
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewPageEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewPageEventHandler Example</h3>
                               
        <!-- Use a PlaceHolder control as the container for the -->
        <!-- dynamically generated DetailsView control.         -->       
        <asp:placeholder id="DetailsViewPlaceHolder"
          runat="server"/>
          
        <br/><br/>
        
        <asp:label id="MessageLabel"
          forecolor="Red"
          runat="server"/>
            
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the web.config file.                            -->
        <asp:sqldatasource id="DetailsViewSource"
          selectcommand="Select [CustomerID], [CompanyName], [Address], 
            [City], [PostalCode], [Country] From [Customers]"
          updatecommand="Update [Customers] Set 
          [CompanyName]=@CompanyName, [Address]=@Address, 
          [City]=@City, [PostalCode]=@PostalCode, 
          [Country]=@Country 
          Where [CustomerID]=@CustomerID"
          connectionstring=
          "<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->