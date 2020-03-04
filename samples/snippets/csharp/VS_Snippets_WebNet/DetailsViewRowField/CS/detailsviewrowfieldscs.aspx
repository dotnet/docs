<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="Form1" runat="server">
    <table cellspacing="10">
      <tr>
        <td>
          <!-- Use a GridView control in combination with      -->
          <!-- a DetailsView control to display master-detail  -->
          <!-- information. When the user selects a store from -->
          <!-- GridView control, the store's detailed          -->
          <!-- information is displayed in the DetailsView     -->
          <!-- control.                                        -->
          <asp:GridView ID="GridView1" runat="server" 
            DataSourceID="Customers" AutoGenerateColumns="False" 
            DataKeyNames="CustomerID">
            <Columns>
              <asp:CommandField ShowSelectButton="True" />
              <asp:BoundField DataField="ContactName" HeaderText="ContactName" />
              <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" />
            </Columns>
          </asp:GridView>
        </td>
        <td valign="top">
          <asp:DetailsView ID="DetailsView" runat="server"
            DataSourceID="Details" AutoGenerateRows="false"
            DataKeyNames="CustomerID" >
            <HeaderStyle BackColor="Navy" ForeColor="White" />
            <Fields>
              <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" 
                ReadOnly="True" />
              <asp:BoundField DataField="ContactName" HeaderText="ContactName" />
              <asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" />
              <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" />
              <asp:BoundField DataField="City" HeaderText="City" />
              <asp:BoundField DataField="Region" HeaderText="Region" />
              <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" />
              <asp:BoundField DataField="Country" HeaderText="Country" />
            </Fields>
          </asp:DetailsView>
        </td>
      </tr>
    </table>
    <!-- This example uses Microsoft SQL Server and connects -->
    <!-- to the Northwind sample database.                        -->
    <!-- It is strongly recommended that each data-bound     -->
    <!-- control uses a separate data source control.        -->
    <asp:SqlDataSource ID="Customers" runat="server" 
      ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
      SelectCommand="SELECT [CompanyName], [ContactName], [CustomerID] FROM [Customers]">
    </asp:SqlDataSource>
    <!-- Add a filter to the data source control for the     -->
    <!-- DetailsView control to display the details of the   -->
    <!-- store selected in the GridView control.             -->
    <asp:SqlDataSource ID="Details" runat="server" 
      ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
      SelectCommand="SELECT * FROM [Customers] WHERE ([CustomerID] = @CustomerID)">
      <SelectParameters>
        <asp:ControlParameter ControlID="GridView1" Name="CustomerID" 
          PropertyName="SelectedValue"
          Type="String" />
      </SelectParameters>
    </asp:SqlDataSource>
  </form>
</body>
</html>
<!-- </Snippet1> -->
