<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void CustomersGridView_DataBound(Object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      // Call a helper method to display the current page number 
      // when the page is first loaded.
      DisplayCurrentPage();
    }
  }

  void CustomersGridView_PageIndexChanged(Object sender, EventArgs e)
  {
    // Call a helper method to display the current page number 
    // when the user navigates to a different page.
    DisplayCurrentPage();
  }

  void DisplayCurrentPage()
  {
    // Calculate the current page number.
    int currentPage = CustomersGridView.PageIndex + 1;

    // Display the current page number. 
    Message.Text = "Page " + currentPage.ToString() + " of " + 
      CustomersGridView.PageCount.ToString() + ".";
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView PageIndexChanged Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView PageIndexChanged Example</h3>
            
      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>
                
      <br/>  

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="true"
        emptydatatext="No data available." 
        allowpaging="true"
        ondatabound="CustomersGridView_DataBound"
        onpageindexchanged="CustomersGridView_PageIndexChanged"
        runat="server">
                
        <pagersettings mode="Numeric"
          position="Bottom"           
          pagebuttoncount="10"/>
                      
        <pagerstyle backcolor="LightBlue"/>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->