<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
private void Page_Load(Object sender, EventArgs e) {

  // Create the AccessDataSource.
  AccessDataSource accessDS = new AccessDataSource();
  accessDS.SelectCommand = "SELECT SupplierID, CompanyName " +
                           " FROM Suppliers WHERE Country ='Germany'";
  accessDS.DataFile = "~/App_Data/Northwind.mdb";

  // Add the AccessDataSource to the Page.Controls collection.
  Page.Controls.Add(accessDS);

  // In programmatic scenarios, use the DataSource
  // property, not the DataSourceID property. The Select method
  // returns an IEnumerable list of data items.
  CheckBoxList1.DataSource = accessDS;

  // Explicitly call DataBind.
  CheckBoxList1.DataBind();
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <asp:CheckBoxList
        id="CheckBoxList1"
        runat="server"
        DataTextField="CompanyName"
        DataValueField="SupplierID">
      </asp:CheckBoxList>

    </form>
  </body>
</html>
<!-- </Snippet1> -->