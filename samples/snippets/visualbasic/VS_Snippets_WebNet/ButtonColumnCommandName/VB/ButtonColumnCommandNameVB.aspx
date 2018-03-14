<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        ' Create dynamic column to add to Columns collection.
        Dim AddColumn As New ButtonColumn
        AddColumn.HeaderText = "Add Item"
        AddColumn.Text = "Add"
        AddColumn.CommandName = "Add"
        AddColumn.ButtonType = ButtonColumnType.PushButton

        ' Add column to Columns collection.
        ItemsGrid.Columns.AddAt(0, AddColumn)
    End Sub


    Protected Sub ItemsGrid_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs)
        If e.CommandName = "Add" Then
            ' Add logic for addition operation here.
            TextBox1.Text = "Added"          
        End If
    End Sub
    
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="head1" runat="server">
    <title>Untitled Page</title>
  </head>
  <body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" /><br />
        <asp:DataGrid 
          ID="ItemsGrid" 
          runat="server" 
          DataSourceID="CustomersSqlDataSource" 
          AutoGenerateColumns="true" 
          OnItemCommand="ItemsGrid_ItemCommand" />
        
        <!-- This example uses Microsoft SQL Server and connects -->
        <!-- to the Northwind sample database.                   -->
        <asp:sqldatasource id="CustomersSqlDataSource"  
          selectcommand="Select [CustomerID], [CompanyName], [ContactName], [ContactTitle] From [Customers]"
          connectionstring="<%$ ConnectionStrings:NorthWindConnection%>"
          runat="server">
        </asp:sqldatasource>

    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->

