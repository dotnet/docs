<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomersGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
  {
    // If multiple ButtonField columns are used, use the
    // CommandName property to determine which button was clicked.
    if(e.CommandName=="Add")
    {
      // Convert the row index stored in the CommandArgument
      // property to an Integer.
      int index = Convert.ToInt32(e.CommandArgument);

      // Retrieve the row that contains the button clicked
      // by the user from the Rows collection. Use the
      // CommandSource property to access the GridView control.
      GridView customersGridView = (GridView)e.CommandSource;
      GridViewRow row = customersGridView.Rows[index];

      // Create a new ListItem object for the customer in the row.
      ListItem item = new ListItem();
      item.Text = Server.HtmlDecode(row.Cells[1].Text) + " " + Server.HtmlDecode(row.Cells[2].Text);

      // If the author is not already in the ListBox, add the ListItem
      // object to the Items collection of a ListBox control.
      if(!CustomersListBox.Items.Contains(item))
      {
        CustomersListBox.Items.Add(item);
      }
    }
  }

  void CustomersGridView_RowCreated(Object sender, GridViewRowEventArgs e)
  {

    // The GridViewCommandEventArgs class does not contain a
    // property that indicates which row's command button was
    // clicked. To identify which row was clicked, use the button's
    // CommandArgument property by setting it to the row's index.
    if(e.Row.RowType == DataControlRowType.DataRow)
    {
      // Retrieve the LinkButton control from the first column.
      LinkButton addButton = (LinkButton)e.Row.Cells[0].Controls[0];

      // Set the LinkButton's CommandArgument property with the
      // row's index.
      addButton.CommandArgument = e.Row.RowIndex.ToString();
    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewCommandEventArgs Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>GridViewCommandEventArgs Example</h3>

      <table width="100%">
        <tr>
          <td style="width:50%">
            <asp:gridview id="CustomersGridView" 
              datasourceid="CustomersSource" 
              autogeneratecolumns="false"
              onrowcommand="CustomersGridView_RowCommand"
              onrowcreated="CustomersGridView_RowCreated"  
              runat="server">
                
              <columns>
                
                <asp:buttonfield buttontype="Link" commandname="Add" text="Add"/>
                <asp:boundfield datafield="CompanyName" 
                  headertext="Company Name"/>
                <asp:boundfield datafield="City" 
                  headertext="City"/>
                
              </columns>
                
            </asp:gridview>
          </td>

          <td style="vertical-align:top; width:50%">
             Customers: <br/>
             <asp:listbox id="CustomersListBox"
               runat="server"/>
          </td>
        </tr>
      </table>

      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSource"
        selectcommand="Select [CustomerID], [CompanyName], [City] From [Customers]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->