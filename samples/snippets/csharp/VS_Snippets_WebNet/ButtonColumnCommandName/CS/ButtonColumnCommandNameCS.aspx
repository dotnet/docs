<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    protected void Page_Init(object sender, EventArgs e)
    {
       // Create dynamic column to add to Columns collection.
       ButtonColumn AddColumn = new ButtonColumn();
       AddColumn.HeaderText="Add Item"; 
       AddColumn.Text="Add";
       AddColumn.CommandName="Add";
       AddColumn.ButtonType = ButtonColumnType.PushButton;

       // Add column to Columns collection.
       ItemsGrid.Columns.AddAt(0, AddColumn);
    }


    protected void ItemsGrid_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Add")
        {
            // Add logic for addition operation here.
            this.TextBox1.Text = "Added";
        }

    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
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

