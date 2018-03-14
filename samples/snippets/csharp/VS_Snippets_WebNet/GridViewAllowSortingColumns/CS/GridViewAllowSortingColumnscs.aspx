<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomersGridView_RowCreated(Object sender, GridViewRowEventArgs e)
  {
    
    // Use the RowType property to determine whether the 
    // row being created is the header row. 
    if (e.Row.RowType == DataControlRowType.Header)
    {
      // Call the GetSortColumnIndex helper method to determine
      // the index of the column being sorted.
      int sortColumnIndex = GetSortColumnIndex();
      
      if (sortColumnIndex != -1)
      {
        // Call the AddSortImage helper method to add
        // a sort direction image to the appropriate
        // column header. 
        AddSortImage(sortColumnIndex, e.Row);
      }
    }
  }

  // This is a helper method used to determine the index of the
  // column being sorted. If no column is being sorted, -1 is returned.
  int GetSortColumnIndex()
  {

    // Iterate through the Columns collection to determine the index
    // of the column being sorted.
    foreach (DataControlField field in CustomersGridView.Columns)
    {
      if (field.SortExpression == CustomersGridView.SortExpression)
      {
        return CustomersGridView.Columns.IndexOf(field);
      }
    }

    return -1;
  }

  // This is a helper method used to add a sort direction
  // image to the header of the column being sorted.
  void AddSortImage(int columnIndex, GridViewRow headerRow)
  {
    
    // Create the sorting image based on the sort direction.
    Image sortImage = new Image();
    if (CustomersGridView.SortDirection == SortDirection.Ascending)
    {
      sortImage.ImageUrl = "~/Images/Ascending.jpg";
      sortImage.AlternateText = "Ascending Order";
    }
    else
    {
      sortImage.ImageUrl = "~/Images/Descending.jpg";
      sortImage.AlternateText = "Descending Order";
    }

    // Add the image to the appropriate header cell.
    headerRow.Cells[columnIndex].Controls.Add(sortImage);
    
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView AllowSorting Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView AllowSorting Example</h3>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="false"
        emptydatatext="No data available." 
        allowsorting="true"
        onrowcreated="CustomersGridView_RowCreated"
        runat="server">
        
        <columns>
          <asp:boundfield datafield="CustomerID"
            headertext="Customer ID"
            headerstyle-wrap="false" 
            sortexpression="CustomerID"/>
          <asp:boundfield datafield="CompanyName"
            headertext="CompanyName"
            headerstyle-wrap="false"
            sortexpression="CompanyName"/>
          <asp:boundfield datafield="Address"
            headertext="Address"
            headerstyle-wrap="false"
            sortexpression="Address"/>
          <asp:boundfield datafield="City"
            headertext="City"
            headerstyle-wrap="false"
            sortexpression="City"/>
          <asp:boundfield datafield="PostalCode"
            headertext="Postal Code"
            headerstyle-wrap="false"
            sortexpression="PostalCode" />
          <asp:boundfield datafield="Country"
            headertext="Country"
            headerstyle-wrap="false"
            sortexpression="Country"/>         
        </columns>
                
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