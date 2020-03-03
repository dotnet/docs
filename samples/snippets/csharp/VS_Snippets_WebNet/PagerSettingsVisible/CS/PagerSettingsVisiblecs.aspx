<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomerGridView_RowEditing(Object sender, GridViewEditEventArgs e)
  {
    // Hide the pager row.
    CustomerGridView.PagerSettings.Visible = false;
  }

  void CustomerGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
  {
    if (e.CommandName == "Cancel" || e.CommandName == "Update")
    {
      // Show the pager row.
      CustomerGridView.PagerSettings.Visible = true;
    }
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>PagerSetting Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>PagerSetting Example</h3>
                       
        <asp:gridview id="CustomerGridView"
          datasourceid="CustomerDataSource"
          autogeneratecolumns="true"
          datakeynames="CustomerID"  
          allowpaging="true"
          autogenerateeditbutton="true"
          onrowediting="CustomerGridView_RowEditing"
          onrowcommand="CustomerGridView_RowCommand"   
          runat="server">
          
          <pagersettings mode="NextPreviousFirstLast"
            firstpagetext="First"
            lastpagetext="Last"
            nextpagetext="Next"
            previouspagetext="Prev"   
            position="Bottom"/> 
            
        </asp:gridview>
        
        <br/>
        
        <asp:label id="MessageLabel"
          forecolor="Red"
          runat="server"/>
            
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the Web.config file.                            -->
        <asp:sqldatasource id="CustomerDataSource"
          selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
          updatecommand="Update [Customers] Set [CompanyName]=@CompanyName, [Address]=@Address, [City]=@City, [PostalCode]=@PostalCode, [Country]=@Country Where [CustomerID]=@CustomerID" 
          connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->