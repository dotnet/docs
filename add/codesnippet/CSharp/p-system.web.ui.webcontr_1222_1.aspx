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