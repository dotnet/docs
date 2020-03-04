<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void SortButton_Click(Object sender, EventArgs e)
  {

    String expression = "";
    SortDirection direction;

    // Create the sort expression from the values selected 
    // by the user from the DropDownList controls. Multiple
    // columns can be sorted by creating a sort expression
    // that contains a comma-separated list of field names.
    expression = SortList1.SelectedValue + "," + SortList2.SelectedValue;
    
    //  Determine the sort direction. The sort direction
    // applies only to the second column sorted.
    switch (DirectionList.SelectedValue)
    {
      case "Ascending":
        direction = SortDirection.Ascending;
        break;
      case "Descending":
        direction = SortDirection.Descending;
        break;
      default:
        direction = SortDirection.Ascending;
        break;
    }
    
    // Use the Sort method to programmatically sort the GridView
    // control using the sort expression and direction.
    CustomersGridView.Sort(expression, direction);
    
  }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView Sort Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView Sort Example</h3>

      <table>
        <tr>
          <td>
             Sort by:
            <asp:dropdownlist ID="SortList1"
              runat="server">
              <asp:listitem Selected="true">CustomerID</asp:listitem>
              <asp:listitem>CompanyName</asp:listitem>
              <asp:listitem>Address</asp:listitem>
              <asp:listitem>City</asp:listitem>
              <asp:listitem>PostalCode</asp:listitem>
              <asp:listitem>Country</asp:listitem>
            </asp:dropdownlist>
          </td>
          <td colspan="2">
            &nbsp;
          </td>
        </tr>
        <tr>
          <td>
            Then by:
              <asp:dropdownlist ID="SortList2"
                runat="server">
                <asp:listitem Selected="true">CustomerID</asp:listitem>
                <asp:listitem>CompanyName</asp:listitem>
                <asp:listitem>Address</asp:listitem>
                <asp:listitem>City</asp:listitem>
                <asp:listitem>PostalCode</asp:listitem>
                <asp:listitem>Country</asp:listitem>
              </asp:dropdownlist>
          </td>
          <td>
             Sort order:      
          </td>
          <td>
            <asp:radiobuttonlist id="DirectionList"
              runat="server">
              <asp:listitem selected="true">Ascending</asp:listitem>
              <asp:listitem>Descending</asp:listitem>
            </asp:radiobuttonlist>
          </td>
        </tr>
      </table>

      <asp:button id="SortButton"
        text="Sort"
        onclick="SortButton_Click" 
        runat="Server"/>  

      <br/>
      <hr/>
      <br/>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="true"
        emptydatatext="No data available." 
        allowpaging="true" 
        runat="server">
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