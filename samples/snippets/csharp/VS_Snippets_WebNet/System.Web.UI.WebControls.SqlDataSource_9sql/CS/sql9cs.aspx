<!-- <Snippet1> -->
<%@Page  Language="C#" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Data.SqlClient" %>
<%@Import Namespace="System.Diagnostics" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

 private void On_Click(Object source, EventArgs e) {    
    SqlDataSource1.Update();
 }

 private void OnSqlUpdating(Object source, SqlDataSourceCommandEventArgs e) {
    DbCommand command = e.Command;
    DbConnection cx  = command.Connection;    
    cx.Open();    
    DbTransaction tx = cx.BeginTransaction();
    command.Transaction = tx;
 }

 private void OnSqlUpdated(Object source, SqlDataSourceStatusEventArgs e) {
    DbCommand command = e.Command;
    DbTransaction tx = command.Transaction;
    
    // In this code example the OtherProcessSucceeded variable represents
    // the outcome of some other process that occurs whenever the data is 
    // updated, and must succeed for the data change to be committed. For 
    // simplicity, we set this value to true. 
    bool OtherProcessSucceeded = true;
    
    if (OtherProcessSucceeded) {
        tx.Commit();
        Label2.Text="The record was updated successfully!";
    }
    else {
        tx.Rollback();
        Label2.Text="The record was not updated.";
    }
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
          UpdateCommand="UPDATE Employees SET Address=@Address WHERE EmployeeID=@EmployeeID"
          OnUpdating="OnSqlUpdating"
          OnUpdated ="OnSqlUpdated">
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