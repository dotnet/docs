<!-- <Snippet1> -->
<%@Page  Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

 // Set helper text and cancel the update if the values submitted to update the row
 // do not meet requirements.
 private void OnRowUpdatingHandler(Object source, GridViewUpdateEventArgs e) {
    // You can examine the values submitted by the user and perform additional
    // processing as required.
    if (e.OldValues[0].Equals("Nancy")) {
        e.Cancel = true;
        Label1.Text="This Row is Not Updatable!";
    }
 }

 // Ensure any helper text is cleared.
 private void OnRowCancellingHandler(Object source, GridViewCancelEditEventArgs e) {
    Label1.Text="";
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
          DataSourceMode="DataSet"
          ConnectionString="<%$ ConnectionStrings:MyNorthwind%>"
          SelectCommand="SELECT EmployeeID,FirstName,LastName,Title FROM Employees"
          UpdateCommand="Update Employees SET FirstName=@FirstName,LastName=@LastName,Title=@Title WHERE EmployeeID=@EmployeeID">
      </asp:SqlDataSource>

      <asp:GridView
          id="GridView1"
          runat="server"
          AutoGenerateColumns="False"
          DataKeyNames="EmployeeID"
          AutoGenerateEditButton="True"
          DataSourceID="SqlDataSource1"
          OnRowUpdating="OnRowUpdatingHandler"
          OnRowCancelingEdit="OnRowCancellingHandler">
          <columns>
              <asp:BoundField HeaderText="First Name" DataField="FirstName" />
              <asp:BoundField HeaderText="Last Name" DataField="LastName" />
              <asp:BoundField HeaderText="Title" DataField="Title" />
          </columns>
      </asp:GridView>

      <asp:Label
          id="Label1"
          runat="server">
      </asp:Label>

    </form>
  </body>
</html>
<!-- </Snippet1> -->