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
    customerDetailsView.ItemUpdated += new DetailsViewUpdatedEventHandler(this.CustomerDetailsView_ItemUpdated);
        
    // Add the DetailsView object to the Controls collection
    // of the PlaceHolder control.
    DetailsViewPlaceHolder.Controls.Add(customerDetailsView);

  }  
  
  void CustomerDetailsView_ItemUpdated(Object sender, 
    DetailsViewUpdatedEventArgs e)
  {
    // Use the Exception property to determine whether an exception
    // occurred during the insert operation.
    if (e.Exception == null)
    {
      // Use the Values property to get the value entered by 
      // the user for the CompanyName field.
      String keyFieldValue = e.Keys["CustomerID"].ToString();

      // Display a confirmation message.
      MessageLabel.Text = "Record " + keyFieldValue + 
        " updated successfully. ";

      // Display the old and new values.
      DisplayValues(e);

      if (e.AffectedRows == 1)
      {
        MessageLabel.Text += e.AffectedRows.ToString() + 
          " record updated.";
      }
      else
      {
        MessageLabel.Text += e.AffectedRows.ToString() + 
          " records updated.";
      }
    }
    else
    {
      // Insert the code to handle the exception.
      MessageLabel.Text = e.Exception.Message;

      // Use the ExceptionHandled property to indicate that the 
      // exception is already handled.
      e.ExceptionHandled = true;

      // When an exception occurs, keep the DetailsView
      // control in edit mode.
      e.KeepInEditMode = true;
    }
  }

  void DisplayValues(DetailsViewUpdatedEventArgs e)
  {
    
    MessageLabel.Text += "<br/></br>";
    
    // Iterate through the OldValue and NewValues
    // properties and display the values.
    for (int i = 0; i < e.OldValues.Count; i++)
    {
      MessageLabel.Text += "Old Value=" + e.OldValues[i].ToString() +
        ", New Value=" + e.NewValues[i].ToString() + "<br/>";
    }

    MessageLabel.Text += "</br>";
    
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewUpdatedEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewUpdatedEventHandler Example</h3>
        
      <!-- Use a PlaceHolder control as the container for the -->
      <!-- dynamically generated DetailsView control.         -->       
      <asp:PlaceHolder id="DetailsViewPlaceHolder"
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