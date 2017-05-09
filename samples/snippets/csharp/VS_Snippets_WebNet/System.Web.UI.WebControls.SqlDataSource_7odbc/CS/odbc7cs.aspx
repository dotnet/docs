<!-- <Snippet1> -->
<%@Page  Language="C#" %>
<%@Import Namespace="System.Web.Mail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

 private void OnDSUpdatedHandler(Object source, SqlDataSourceStatusEventArgs e) {
    if (e.AffectedRows > 0) {
        // Perform any additional processing, such as sending an e-mail notification.
        Label1.Text = Request.LogonUserIdentity.Name +
            " changed user information sucessfully!";
    }
    else {
        Label1.Text = "No data updated!";
    }
 }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <!-- This example uses a Northwind database that is hosted by an ODBC-compliant
         database. To run this sample, create an ODBC DSN to any database that hosts
         the Northwind database, including Microsoft SQL Server or Microsoft Access,
         change the name of the DSN in the ConnectionString, and view the page.
    -->
    <form id="form1" runat="server">

      <asp:SqlDataSource
          id="SqlDataSource1"
          runat="server"
          ProviderName="System.Data.Odbc"
          DataSourceMode="DataSet"
          ConnectionString="dsn=myodbc3dsn;"
          SelectCommand="SELECT EmployeeID,FirstName,LastName,Title FROM Employees"
          UpdateCommand="Update Employees SET FirstName=?,LastName=?,Title=? WHERE EmployeeID=?"
          OnUpdated="OnDSUpdatedHandler">
      </asp:SqlDataSource>

      <asp:GridView
          id="GridView1"
          runat="server"
          AutoGenerateColumns="False"
          DataKeyNames="EmployeeID"
          AutoGenerateEditButton="True"
          DataSourceID="SqlDataSource1">
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