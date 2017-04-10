<!-- <Snippet1> -->
<%@Page  Language="VB" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

 Sub On_Click(ByVal source As Object, ByVal e As EventArgs)
        SqlDataSource1.Update()
 End Sub 'On_Click

 Sub On_Sql_Updating(ByVal source As Object, ByVal e As SqlDataSourceCommandEventArgs)
     Dim command as DbCommand
     Dim connection as DbConnection
     Dim transaction as DbTransaction
     
     command    = e.Command
     connection = command.Connection     
     connection.Open()     
     transaction = connection.BeginTransaction()
     command.Transaction = transaction
 
 End Sub 'On_Sql_Updating
 
 Sub On_Sql_Updated(ByVal source As Object, ByVal e As SqlDataSourceStatusEventArgs)
 
    Dim command As DbCommand
    Dim transaction As DbTransaction
    
    command = e.Command
    transaction = command.Transaction
    
    ' In this code example the OtherProcessSucceeded variable represents
    ' the outcome of some other process that occurs whenever the data is 
    ' updated, and must succeed for the data change to be committed. For 
    ' simplicity, we set this value to true. 
    Dim OtherProcessSucceeded as Boolean = True
    
    If (OtherProcessSucceeded) Then
        transaction.Commit()
        Label2.Text="The record was updated successfully!"
    Else    
        transaction.Rollback()
        Label2.Text="The record was not updated."
    End If
 End Sub ' On_Sql_Updated
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
          OnUpdating="On_Sql_Updating"
          OnUpdated ="On_Sql_Updated">
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