<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
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
    <title>DetailsViewUpdatedEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewUpdatedEventArgs Example</h3>
                       
        <asp:detailsview id="CustomerDetailsView"
          datasourceid="DetailsViewSource"
          autogeneraterows="true"
          autogenerateeditbutton="true"  
          allowpaging="true"
          datakeynames="CustomerID" 
          onitemupdated="CustomerDetailsView_ItemUpdated"
          runat="server">
            
          <pagersettings position="Bottom"/> 
                    
        </asp:detailsview>
        
        <br/>
        
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