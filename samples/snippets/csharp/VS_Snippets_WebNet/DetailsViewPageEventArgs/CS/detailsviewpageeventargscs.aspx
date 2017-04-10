<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void CustomerDetailsView_PageIndexChanging(Object sender, DetailsViewPageEventArgs e)
  {
    // Cancel the paging operation if the DetailsView control 
    // in edit mode.
    if (CustomerDetailsView.CurrentMode == DetailsViewMode.Edit)
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
    // Clear the message label when the user cancels edit mode.
    if (e.CancelingEdit)
    {
      MessageLabel.Text = "";
    }
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

  <head runat="server">
    <title>DetailsViewPageEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DetailsViewPageEventArgs Example</h3>
                       
        <asp:detailsview id="CustomerDetailsView"
          datasourceid="DetailsViewSource"
          autogeneraterows="true"
          autogenerateeditbutton="true"
          datakeynames="CustomerID"  
          allowpaging="true"
          onpageindexchanging="CustomerDetailsView_PageIndexChanging" 
          onmodechanging="CustomerDetailsView_ModeChanging"
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