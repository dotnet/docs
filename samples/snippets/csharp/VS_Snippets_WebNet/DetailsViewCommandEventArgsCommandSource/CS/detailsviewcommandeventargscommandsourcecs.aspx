<!-- <Snippet1> -->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void ItemDetailsView_ItemCommand(Object sender, 
    DetailsViewCommandEventArgs e)
  {

    // Use the CommandName property to determine which button
    // was clicked. 
    if (e.CommandName == "Add")
    {
      
      // Because this event handler is used for two different
      // DetailsView controls, use the CommandSource property 
      // to get the DetailsView control that raised the event.
      DetailsView view = (DetailsView)e.CommandSource;
      
      // Determine which ListBox control to update based on the
      // ID of the DetailsView control that raised the event.
      ListBox list;
      if (view.ID == "CustomerDetailsView")
      {
        list = CustomerListBox;
      }
      else
      {
        list = EmployeesListBox;
      }

      // Add the selected item to the appropriate ListBox control. 

      // Get the row that contains the value to add. For this
      // example, get the second row (index 1) of the DetailsView 
      // control.
      DetailsViewRow row = view.Rows[1];

      // Get the value from the appropriate cell. For this
      // example, get the value of the second cell (index 1) 
      // of the row.
      String value = row.Cells[1].Text;

      // Create a ListItem object using the value.
      ListItem item = new ListItem(value);

      // Add the ListItem object to the ListBox control, if the 
      // item does not already exist.
      if (!list.Items.Contains(item))
      {
        list.Items.Add(item);
      }

    }

  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewCommandEventArgs CommandSource Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>DetailsViewCommandEventArgs CommandSource Example</h3>
  
      <table border="0">
        <tr valign="top">
          <td>
            <asp:detailsview id="CustomerDetailsView"
              datasourceid="CustomerSource"
              allowpaging="true"
              autogeneraterows="true" 
              onitemcommand="ItemDetailsView_ItemCommand"  
              runat="server">
              <fields>
                <asp:buttonfield buttontype="Link"
                  causesvalidation="false"
                  text="Add to List"
                  commandname="Add"/>
              </fields>
            </asp:detailsview>
          </td>
          <td>
            <asp:detailsview id="EmployeesDetailsView"
              datasourceid="EmployeesSource"
              allowpaging="true"
              autogeneraterows="true" 
              onitemcommand="ItemDetailsView_ItemCommand"  
              runat="server">
              <fields>
                <asp:buttonfield buttontype="Link"
                  causesvalidation="false"
                  text="Add to List"
                  commandname="Add"/>
              </fields>
            </asp:detailsview>
          </td>
        </tr>
        <tr>
          <td>
            Selected Customers:<br/>
            <asp:listbox id="CustomerListBox"
              runat="server"/>
          </td>
          <td>
            Selected Employees:<br/>
            <asp:listbox id="EmployeesListBox"
              runat="server"/>
          </td>
        </tr>
      </table>
      
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomerSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], 
          [City], [PostalCode], [Country] From [Customers]"
        connectionstring=
            "<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>  
        
      <asp:sqldatasource id="EmployeesSource"
        selectcommand="Select [EmployeeID], [FirstName], [LastName], 
          [Title] From [Employees]"
        connectionstring=
            "<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
  
    </form>
  </body>
</html>
<!-- </Snippet1> -->