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
    customerDetailsView.ItemUpdating 
      += new DetailsViewUpdateEventHandler(
      this.CustomerDetailsView_ItemUpdating);
    customerDetailsView.ModeChanging 
      += new DetailsViewModeEventHandler(
      this.CustomerDetailsView_ModeChanging);

    // Add the DetailsView object to the Controls collection
    // of the PlaceHolder control.
    DetailsViewPlaceHolder.Controls.Add(customerDetailsView);

  }
  
  void CustomerDetailsView_ItemUpdating(Object sender, 
    DetailsViewUpdateEventArgs e)
  {

    // Validate the field values entered by the user. This
    // example determines whether the user left any fields
    // empty. Use the NewValues property to access the new 
    // values entered by the user.
    ArrayList emptyFieldList = 
      ValidateFields((IOrderedDictionary)e.NewValues);

    if (emptyFieldList.Count > 0)
    {

      // The user left some fields empty. Display an error message.
      
      // Use the Keys property to retrieve the key field value.
      String keyValue = e.Keys["CustomerID"].ToString();

      MessageLabel.Text = 
        "You must enter a value for all fields of record " +
        keyValue + ".<br/>The following fields are missing:<br/><br/>";

      // Display the missing fields.
      foreach (String value in emptyFieldList)
      {
        // Use the OldValues property access the original value
        // of a field.
        MessageLabel.Text += value + " - Original Value = " + 
          e.OldValues[value].ToString() + "<br />";
      }

      // Cancel the update operation.
      e.Cancel = true;

    }
    else
    {
      // The field values passed validation. Clear the
      // error message label.
      MessageLabel.Text = "";
    }

  }

  ArrayList ValidateFields(IOrderedDictionary list)
  {
    
    // Create an ArrayList object to store the
    // names of any empty fields.
    ArrayList emptyFieldList = new ArrayList();

    // Iterate though the field values entered by
    // the user and check for an empty field. Empty
    // fields contain a null value.
    foreach (DictionaryEntry entry in list)
    {
      if (entry.Value == null)
      {
        // Add the field name to the ArrayList object.
        emptyFieldList.Add(entry.Key.ToString());
      }
    }

    return emptyFieldList;
  }

  void CustomerDetailsView_ModeChanging(Object sender, 
    DetailsViewModeEventArgs e)
  {
    if (e.CancelingEdit)
    {
      // The user canceled the update operation.
      // Clear the error message label.
      MessageLabel.Text = "";
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewUpdateEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewUpdateEventHandler Example</h3>
        
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