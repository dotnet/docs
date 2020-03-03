<!-- <Snippet2> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">


  Sub ProductsGridView_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

    ' If multiple buttons are used in a GridView control, use the
    ' CommandName property to determine which button was clicked.
    If e.CommandName = "Increase" Then
    
      ' Convert the row index stored in the CommandArgument
      ' property to an Integer.
      Dim index = Convert.ToInt32(e.CommandArgument)
            
      ' Retrieve the row that contains the button clicked 
      ' by the user from the Rows collection.
      Dim row = ProductsGridView.Rows(index)
      
      ' Calculate the new price.
      Dim listPriceTextBox = CType(row.FindControl("PriceLabel"), Label)
      listPriceTextBox.Text = (Convert.ToDouble(listPriceTextBox.Text) * 1.05).ToString()

      ' Update the row.
      ProductsGridView.UpdateRow(index, False)
      
    End If
    
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView RowCommand Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>GridView RowCommand Example</h3>

      <asp:GridView id="ProductsGridView" 
        DataSourceID="ProductsDataSource"
        DataKeyNames="ProductID"
        AllowPaging="True" 
        OnRowCommand="ProductsGridView_RowCommand"
        AutoGenerateColumns="False"
        runat="server">
        <Columns>
          <asp:BoundField DataField="Name" HeaderText="Product Name" />
          <asp:BoundField DataField="ProductNumber" HeaderText="Product Number" />          
          <asp:TemplateField HeaderText="Price">
            <ItemTemplate>
              <asp:Label ID="PriceLabel" runat="server" 
                Text='<%# Bind("ListPrice") %>'>
              </asp:Label>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField>
            <ItemTemplate>                
              <asp:Button runat="server" ID="IncreaseButton"
                Text="Increase Price 5%"
                CommandName="Increase"
                CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>

      <!-- This example uses Microsoft SQL Server and connects    -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET  -->
      <!-- expression to retrieve the connection string value     -->
      <!-- from the Web.config file.                              -->
      <asp:SqlDataSource id="ProductsDataSource"
        SelectCommand="SELECT [ProductID], [Name], [ProductNumber], [ListPrice] 
          FROM Production.Product 
          WHERE ListPrice &lt;&gt; 0"
        UpdateCommand="UPDATE Production.Product SET [ListPrice] = @ListPrice 
          WHERE [ProductID] = @ProductID"
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        runat="server" />

    </form>
  </body>
</html>
<!-- </Snippet2> -->