<!-- <Snippet1> -->
<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Protected Sub CategoriesListView_OnItemDeleting(sender As Object, e As ListViewDeleteEventArgs)
        If SubCategoriesGridView.Rows.Count > 0 Then
            MessageLabel.Text = "You cannot delete a category that has sub-categories."
            e.Cancel = True
        End If
    End Sub

    Protected Sub Page_Load()
        MessageLabel.Text = String.Empty
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>Subcategories List</title>
  </head>
  <body>
    <form id="form1" runat="server">
      <b>Categories</b>
      <br />
      
      <asp:Label ForeColor="Red" runat="server" ID="MessageLabel" /><br />
      
      <asp:ListView runat="server" 
        ID="CategoriesListView"
        OnItemDeleting="CategoriesListView_OnItemDeleting"
        DataSourceID="CategoriesDataSource" 
        DataKeyNames="ProductCategoryID">
        <LayoutTemplate>
          <table runat="server" id="tblCategories" 
                 cellspacing="0" cellpadding="1" width="440px" border="1">
            <tr id="itemPlaceholder" runat="server"></tr>
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:Label runat="server" ID="NameLabel" Text='<%#Eval("Name") %>' />
            </td>
            <td style="width:40px">
              <asp:LinkButton runat="server" ID="SelectCategoryButton" 
                Text="Select" CommandName="Select" />
            </td>
          </tr>
        </ItemTemplate>
        <SelectedItemTemplate>
          <tr runat="server" style="background-color:#90EE90">
            <td>
              <asp:Label runat="server" ID="NameLabel" Text='<%#Eval("Name") %>' />
            </td>
            <td style="width:40px">
              <asp:LinkButton runat="server" ID="SelectCategoryButton" 
                Text="Delete" CommandName="Delete" />
            </td>
          </tr>
        </SelectedItemTemplate>
      </asp:ListView>
      
      <br />
      
      <b>Subcategories</b>
      <asp:GridView runat="server" ID="SubCategoriesGridView" Width="300px"
           DataSourceID="SubCategoriesDataSource" DataKeyNames="ProductSubcategoryID" 
           AutoGenerateColumns="True" />
       
      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="CategoriesDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ProductCategoryID], [Name]
                       FROM Production.ProductCategory">
      </asp:SqlDataSource>
      <asp:SqlDataSource ID="SubCategoriesDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ProductSubcategoryID], [Name]
                       FROM Production.ProductSubcategory
                       WHERE ProductCategoryID = @ProductCategoryID
                       ORDER BY [Name]">
          <SelectParameters>
            <asp:ControlParameter Name="ProductCategoryID" DefaultValue="0"
                 ControlID="CategoriesListView" PropertyName="SelectedValue"  />
          </SelectParameters>
      </asp:SqlDataSource>
    </form>
  </body>
</html>
<!-- </Snippet1> -->