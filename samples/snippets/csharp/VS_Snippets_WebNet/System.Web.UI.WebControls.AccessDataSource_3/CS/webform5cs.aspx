<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
// <Snippet2>
private void Button1_Click(object sender, EventArgs e) {

    // The user has pressed the Submit button, prepare a parameterized
    // SQL query to insert the values from the controls.
    AccessDataSource1.InsertCommand =
    "INSERT INTO Employees (FirstName,LastName,Address,City,PostalCode,Country,ReportsTo) " +
    "  VALUES (?,?,?,?,?,?,? ); ";

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("FirstName", "TextBox1", "Text"));

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("LastName", "TextBox2", "Text"));

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("Address", "TextBox3", "Text"));

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("City", "TextBox4", "Text"));

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("PostalCode", "TextBox5", "Text"));

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("Country", "TextBox6", "Text"));

    AccessDataSource1.InsertParameters.Add(
      new ControlParameter("ReportsTo", "DropDownList1", "SelectedValue"));

    try {
        AccessDataSource1.Insert();
    }
    finally {
        Button1.Visible = false;
        Label9.Visible = true;
    }
}
// </Snippet2>
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="form1" runat="server">

      <!-- The AccessDataSource control -->
      <asp:AccessDataSource
        id="AccessDataSource1"
        runat="server"
        SelectCommand="SELECT EmployeeID, LastName FROM Employees WHERE EmployeeID IN (SELECT DISTINCT ReportsTo FROM Employees)"
        DataFile="Northwind.mdb" />


      <asp:Label id="Label4" runat="server">
          New Employee Registration Form
      </asp:Label>

      <asp:Label id="Label1" runat="server" AssociatedControlID="TextBox1">First Name</asp:Label>
      <asp:TextBox id="TextBox1" runat="server" />

      <asp:Label id="Label2" runat="server" AssociatedControlID="TextBox2">Last Name</asp:Label>
      <asp:TextBox id="TextBox2" runat="server" />

      <asp:Label id="Label3" runat="server" AssociatedControlID="TextBox3">Address</asp:Label>
      <asp:TextBox id="TextBox3" runat="server" />

      <asp:Label id="Label5" runat="server" AssociatedControlID="TextBox4">City</asp:Label>
      <asp:TextBox id="TextBox4" runat="server" />

      <asp:Label id="Label6" runat="server" AssociatedControlID="TextBox5">Postal Code</asp:Label>
      <asp:TextBox id="TextBox5" runat="server" />

      <asp:Label id="Label7" runat="server" AssociatedControlID="TextBox6">Country</asp:Label>
      <asp:TextBox id="TextBox6" runat="server" />

      <asp:Label id="Label8" runat="server" AssociatedControlID="DropDownList1">
        Name of Your Supervisor</asp:Label>
      <asp:DropDownList
        id="DropDownList1"
        runat="server"
        DataSourceID="AccessDataSource1"
         DataTextField="LastName"
         DataValueField="EmployeeID" />

      <asp:Button id="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />

      <asp:Label id="Label9" runat="server" Visible="false" >
      Your information was successfully inserted.
      </asp:Label>

  </form>
  </body>
</html>
<!-- </Snippet1> -->