<!-- <Snippet1> -->
<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  protected void EmployeesListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
  {
    if (String.Equals(e.CommandName, "AddToList"))
    {
      // Verify that the employee ID is not already in the list. If not, add the
      // employee to the list.
      ListViewDataItem dataItem = (ListViewDataItem)e.Item;
      string employeeID = 
        EmployeesListView.DataKeys[dataItem.DisplayIndex].Value.ToString();
      
      if (SelectedEmployeesListBox.Items.FindByValue(employeeID) == null)
      {
        ListItem item = new ListItem(e.CommandArgument.ToString(), employeeID);
        SelectedEmployeesListBox.Items.Add(item);
      }
    }
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Employee List</title>
  </head>
  <body>
    <form id="form1" runat="server">
      <%--<Snippet3>--%>
      <asp:ListView runat="server" 
        ID="EmployeesListView"
        OnItemCommand="EmployeesListView_OnItemCommand"
        DataSourceID="EmployeesDataSource" 
        DataKeyNames="EmployeeID">
        <LayoutTemplate>
          <table runat="server" id="tblEmployees" 
                 cellspacing="0" cellpadding="1" width="440px" border="1">
            <tr id="itemPlaceholder" runat="server"></tr>
          </table>
          <asp:DataPager ID="EmployeesDataPager" runat="server" PageSize="10">
            <Fields>
              <asp:NumericPagerField />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:Label runat="server" ID="NameLabel" 
                Text='<%#Eval("LastName") + ", " + Eval("FirstName") %>' />
            </td>
            <td style="width:80px">
              <asp:LinkButton runat="server" 
                ID="SelectEmployeeButton" 
                Text="Add To List" 
                CommandName="AddToList" 
                CommandArgument='<%#Eval("LastName") + ", " + Eval("FirstName") %>' />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>
      
      <br /><br />
      <b>Selected Employees:</b><br />
      <asp:ListBox runat="server" ID="SelectedEmployeesListBox" Rows="10" Width="300px" />
       
      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->       
      <asp:SqlDataSource ID="EmployeesDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [EmployeeID], [FirstName], [LastName]
                       FROM HumanResources.vEmployee
                       ORDER BY [LastName], [FirstName], [EmployeeID]">
      </asp:SqlDataSource>
      <%--</Snippet3>--%>
    </form>
  </body>
</html>
<!-- </Snippet1> -->