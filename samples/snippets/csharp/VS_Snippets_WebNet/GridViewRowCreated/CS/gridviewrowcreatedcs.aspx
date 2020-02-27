<!-- <Snippet1> -->
<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void ProductsGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
  {
    // If multiple buttons are used in a GridView control, use the
    // CommandName property to determine which button was clicked.
    if(e.CommandName=="Add")
    {
      // Convert the row index stored in the CommandArgument
      // property to an Integer.
      int index = Convert.ToInt32(e.CommandArgument);

      // Retrieve the row that contains the button clicked 
      // by the user from the Rows collection.
      GridViewRow row = ProductsGridView.Rows[index];

      // Create a new ListItem object for the product in the row.     
      ListItem item = new ListItem();
      item.Text = Server.HtmlDecode(row.Cells[1].Text);

      // If the product is not already in the ListBox, add the ListItem 
      // object to the Items collection of the ListBox control. 
      if (!ProductsListBox.Items.Contains(item))
      {
        ProductsListBox.Items.Add(item);
      }
    }
  }

  void ProductsGridView_RowCreated(Object sender, GridViewRowEventArgs e)
  {

    // The GridViewCommandEventArgs class does not contain a 
    // property that indicates which row's command button was
    // clicked. To identify which row's button was clicked, use 
    // the button's CommandArgument property by setting it to the 
    // row's index.
    if(e.Row.RowType == DataControlRowType.DataRow)
    {
      // Retrieve the LinkButton control from the first column.
      LinkButton addButton = (LinkButton)e.Row.FindControl("AddButton");

      // Set the LinkButton's CommandArgument property with the
      // row's index.
      addButton.CommandArgument = e.Row.RowIndex.ToString();
    }

  }

</script>

<html>
  <head id="Head1" runat="server">
    <title>GridView RowCreated Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>GridView RowCreated Example</h3>

      <table width="100%">         
        <tr>                
          <td style="width:50%">

            <asp:GridView ID="ProductsGridView" 
              DataSourceID="ProductsDataSource"
              AllowPaging="true" 
              AutoGenerateColumns="false"
              OnRowCommand="ProductsGridView_RowCommand"
              OnRowCreated="ProductsGridView_RowCreated"  
              runat="server">
              <Columns>
                <asp:TemplateField>
                  <ItemTemplate>
                    <asp:LinkButton runat="server"
                      ID="AddButton"
                      CommandName="Add"
                      Text="Add" />
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" 
                  HeaderText="Product Name"/> 
                <asp:BoundField DataField="ProductNumber" 
                  HeaderText="Product Number"/>
              </Columns>

            </asp:GridView>

          </td>

          <td style="vertical-align:top; width:50%">

            Products: <br/>
            <asp:listbox id="ProductsListBox"
              runat="server" Height="200px" Width="200px"/> 

          </td>
        </tr>
      </table>

      <!-- This example uses Microsoft SQL Server and connects    -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET  -->
      <!-- expression to retrieve the connection string value     -->
      <!-- from the Web.config file.                              -->
      <asp:sqldatasource id="ProductsDataSource"
        selectcommand="Select [Name], [ProductNumber] From Production.Product"
        connectionstring="<%$ ConnectionStrings:AdventureWorks_DataConnectionString%>" 
        runat="server"/>

    </form>
  </body>
</html>
<!-- </Snippet1> -->