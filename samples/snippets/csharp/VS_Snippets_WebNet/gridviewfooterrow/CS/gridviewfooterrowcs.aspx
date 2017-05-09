<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void CustomersGridView_DataBound(Object sender, EventArgs e)
  {
    
    // Get the header row.
    GridViewRow headerRow = CustomersGridView.HeaderRow;   
    
    // Get the footer row.
    GridViewRow footerRow = CustomersGridView.FooterRow; 

    // Set the font color of the header and footer rows
    // based on the sort direction. 
    switch (CustomersGridView.SortDirection)
    {
      case SortDirection.Ascending:
        headerRow.ForeColor = System.Drawing.Color.Green;
        footerRow.ForeColor = System.Drawing.Color.Green;
        break;
      case SortDirection.Descending:
        headerRow.ForeColor = System.Drawing.Color.Red;
        footerRow.ForeColor = System.Drawing.Color.Red;
        break;
      default:
        headerRow.ForeColor = System.Drawing.Color.Black;
        footerRow.ForeColor = System.Drawing.Color.Black;
        break;
    }

    // Display the sort order in the footer row.
    footerRow.Cells[0].Text = "Sort Order = " + CustomersGridView.SortDirection.ToString();
      
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView HeaderRow and FooterRow Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView HeaderRow and FooterRow Example</h3>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="true"
        emptydatatext="No data available." 
        allowsorting="true"
        allowpaging="true" 
        showheader="true"
        showfooter="true"
        ondatabound="CustomersGridView_DataBound"    
        runat="server">
        
        <headerstyle backcolor="LightCyan"
          forecolor="MediumBlue"/>
                    
        <footerstyle backcolor="LightCyan"
          forecolor="MediumBlue"/>
                        
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