<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {
        
    // Create a new GridView control.
    GridView customersGridView = new GridView();
         
    // Set the GridView control's properties.
    customersGridView.ID = "CustomersGridView";
    customersGridView.DataSourceID = "CustomersSqlDataSource";
    customersGridView.AutoGenerateColumns = true;
    customersGridView.AllowPaging = true;

    // Programmatically register the event-handling method.
    customersGridView.RowDataBound += new GridViewRowEventHandler(this.CustomersGridView_RowDataBound);
       
    // Add the GridView control to the Controls collection
    // of the PlaceHolder control.
    GridViewPlaceHolder.Controls.Add(customersGridView);

  }

  void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
  {
        
    if(e.Row.RowType == DataControlRowType.DataRow)
    {
      // Display the company name in italics.
      e.Row.Cells[1].Text = "<i>" + e.Row.Cells[1].Text + "</i>";
        
    }
    
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewRowEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewRowEventHandler Example</h3>

      <asp:placeholder id="GridViewPlaceHolder"
        runat="server"/>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->