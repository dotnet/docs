<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomerDetailsView_ModeChanging(Object sender, DetailsViewModeEventArgs e)
  {

    // Use the NewMode property to determine the mode to which the 
    // DetailsView control is transitioning.
    switch (e.NewMode)
    {
      case DetailsViewMode.Edit:
        // Hide the pager row and clear the Label control
        // when transitioning to edit mode.
        CustomerDetailsView.AllowPaging = false;
        MessageLabel.Text = "";
        break;
      case DetailsViewMode.ReadOnly:
        // Display the pager row and confirmation message
        // when transitioning to edit mode.
        CustomerDetailsView.AllowPaging = true;
        if (e.CancelingEdit)
        {
          MessageLabel.Text = "Update canceled.";
        }
        else
        {
          MessageLabel.Text = "Update completed.";
        }
        break;
      case DetailsViewMode.Insert:
        // Cancel the mode change if the DetailsView
        // control attempts to transition to insert 
        // mode.
        e.Cancel = true;
        break;
      default:
        MessageLabel.Text = "Unsupported mode.";
        break;
    }
    
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewModeEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewModeEventHandler Example</h3>
                
      <asp:detailsview id="CustomerDetailsView"
        datasourceid="DetailsViewSource"
        datakeynames="CustomerID"
        autogeneraterows="true"
        autogenerateeditbutton="true" 
        allowpaging="true"
        onmodechanging="CustomerDetailsView_ModeChanging" 
        runat="server">

      </asp:detailsview>
      
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