<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <table>
        <tr>
          <td>
            <asp:GridView ID="GridView1" runat="server" 
              AutoGenerateColumns="False" DataSourceID="Customers"
              DataKeyNames="CustomerID">
              <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ContactName" HeaderText="ContactName" />
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" />
              </Columns>
            </asp:GridView>
          </td>
          <td valign="top">
            <asp:DetailsView ID="DetailsView1" runat="server" 
              AutoGenerateRows="True" DataKeyNames="CustomerID"
              DataSourceID="Details" Height="50px" Width="301px">
            </asp:DetailsView>
          </td>
        </tr>
      </table>
      &nbsp;&nbsp;
      <asp:SqlDataSource ID="Details" runat="server" 
        ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
        SelectCommand="SELECT * FROM [Customers] WHERE ([CustomerID] = @CustomerID)">
        <SelectParameters>
          <asp:ControlParameter ControlID="GridView1" Name="CustomerID" 
            PropertyName="SelectedValue"
            Type="String" />
        </SelectParameters>
      </asp:SqlDataSource>
      <asp:SqlDataSource ID="Customers" runat="server" 
        ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
        SelectCommand="SELECT [CompanyName], [ContactName], [CustomerID] FROM [Customers]">
      </asp:SqlDataSource>
    </div>
  </form>
</body>
</html>
<!-- </Snippet1> -->
