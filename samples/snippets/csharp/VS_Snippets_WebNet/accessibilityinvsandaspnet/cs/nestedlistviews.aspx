<%--<Snippet6>--%>
<%@ Page Language="C#" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  private DataTable AddressesTable = new DataTable();

  protected void Page_Load(object sender, EventArgs e)
  {
    SqlDataAdapter AddressesAdapter = new SqlDataAdapter(
        "SELECT SalesLT.CustomerAddress.CustomerID, " +
        "SalesLT.CustomerAddress.AddressID, " +
        "SalesLT.Address.AddressLine1, " +
        "SalesLT.Address.City, SalesLT.Address.StateProvince, " +
        "SalesLT.Address.PostalCode FROM SalesLT.CustomerAddress " +
        "INNER JOIN SalesLT.Address ON " +
        "SalesLT.CustomerAddress.AddressID = SalesLT.Address.AddressID",
        @"Data Source=.\SQLEXPRESS;" +
        @"AttachDbFilename=|DataDirectory|\AdventureWorksLT_Data.mdf;" +
        @"Integrated Security=True;User Instance=True");
    AddressesAdapter.Fill(AddressesTable);
  }

  protected DataView GetAddresses(object customerID)
  {
    DataView view = AddressesTable.DefaultView;
    view.RowFilter = "CustomerID=" + customerID.ToString();
    return view;
  }

  private string GetCustomerHeaderID(ListViewItem item)
  {
    return "hdrCustomer" + item.DataItemIndex.ToString();
  }

  private string GetAddressHeaderID(ListViewItem item)
  {
    return "hdrAddress" +
        ((DataRowView)item.DataItem)["AddressID"].ToString();
  }

  protected string GetColumnHeaderIDs
      (ListViewDataItem item, string columnHeader)
  {
    string customerHeaderID =
        GetCustomerHeaderID
            ((ListViewItem)item.NamingContainer.NamingContainer);

    string addressHeaderID = GetAddressHeaderID(item);

    return string.Format("{0} {1} {2}",
        customerHeaderID, addressHeaderID, columnHeader);
  }

  protected void CustomersListView_ItemDataBound
      (object sender, ListViewItemEventArgs e)
  {
    ListView addressesListView = new ListView();
    addressesListView = e.Item.FindControl("AddressesListView")
        as ListView;
    DataRowView drv = e.Item.DataItem as DataRowView;
    addressesListView.DataSource = GetAddresses(drv["CustomerID"]);
    addressesListView.DataBind();
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
  <title>Customers and Addresses</title>
  <style type="text/css">
    .customerRow { background-color: yellow; }
    th { text-align: left; }
  </style>
</head>

<body>
  <form id="form1" runat="server">
  <div>
    <asp:SqlDataSource ID="CustomersSqlDataSource" runat="server" 
    ConnectionString="<%$ ConnectionStrings:AdventureWorksLTConnectionString %>"
    SelectCommand="SELECT CustomerID, 
      FirstName, MiddleName, LastName FROM SalesLT.Customer" />
    <asp:ListView ID="CustomersListView" runat="server" 
      DataKeyNames="CustomerID" DataSourceID="CustomersSqlDataSource"
      OnItemDataBound="CustomersListView_ItemDataBound">
      <LayoutTemplate>
        <table summary="A list of customers with one or more addresses for each customer.">
          <caption>Customers and Addresses</caption>
          <thead>
            <tr>
              <th id="hdrID">ID</th>
              <th id="hdrStreet">Street</th>
              <th id="hdrCity">City</th>
              <th id="hdrState">State</th>
            </tr>
          </thead>
          <tbody>
            <tr id="itemPlaceholder" runat="server"></tr>
          </tbody>
        </table>
      </LayoutTemplate>
      <ItemTemplate>
        <tr class="customerRow">
          <th colspan="4" id='<%# GetCustomerHeaderID(Container) %>'>
            <%# Eval("FirstName") %>
            <%# Eval("MiddleName") %>
            <%# Eval("LastName") %>
          </th>
        </tr>
        <asp:ListView ID="AddressesListView" runat="server">
          <LayoutTemplate>
            <tr id="itemPlaceHolder" runat="server"></tr>
          </LayoutTemplate>
          <ItemTemplate>
            <tr>
              <th id='<%# GetAddressHeaderID(Container) %>'>
                <%# Eval("AddressID") %>
              </th>
              <td headers='<%# GetColumnHeaderIDs(Container, "hdrStreet") %>'>
                <%# Eval("AddressLine1") %>
              </td>
              <td headers='<%# GetColumnHeaderIDs(Container, "hdrCity") %>'>
                <%# Eval("City") %>
              </td>
              <td headers='<%# GetColumnHeaderIDs(Container, "hdrState") %>'>
                <%# Eval("StateProvince") %>
              </td>
            </tr>
          </ItemTemplate>
        </asp:ListView>
      </ItemTemplate>
    </asp:ListView>
  </div>
  </form>
</body>
</html>
<%--</Snippet6>--%>
