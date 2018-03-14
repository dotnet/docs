<!-- <Snippet1> -->
<%@Page  Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 private void On_Click(Object source, EventArgs e) {
    try {
        SqlDataSource1.Update();
    }
    catch (Exception except) {
        // Handle the Exception.
    }

    Label2.Text="The record was updated successfully!";
 }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:SqlDataSource
          id="SqlDataSource1"
          runat="server"
          ConnectionString="<%$ ConnectionStrings:MyNorthwind%>"
          SelectCommand="SELECT EmployeeID, LastName, Address FROM Employees"
          UpdateCommand="UPDATE Employees SET Address=@Address WHERE EmployeeID=@EmployeeID">
          <UpdateParameters>
              <asp:ControlParameter Name="Address" ControlId="TextBox1" PropertyName="Text"/>
              <asp:ControlParameter Name="EmployeeID" ControlId="DropDownList1" PropertyName="SelectedValue"/>
          </UpdateParameters>
      </asp:SqlDataSource>

      <asp:DropDownList
          id="DropDownList1"
          runat="server"
          DataTextField="LastName"
          DataValueField="EmployeeID"
          DataSourceID="SqlDataSource1">
      </asp:DropDownList>

      <br />
      <asp:Label id="Label1" runat="server" Text="Enter a new address for the selected user."
        AssociatedControlID="TextBox1" />
      <asp:TextBox id="TextBox1" runat="server" />
      <asp:Button id="Submit" runat="server" Text="Submit" OnClick="On_Click" />

      <br /><asp:Label id="Label2" runat="server" Text="" />

    </form>
  </body>
</html>
<!-- </Snippet1> -->