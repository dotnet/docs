<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub ProductsGridView_OnSelectedIndexChanged(sender As Object, e As EventArgs)
    ProductDetailsSqlDataSource.SelectParameters("ProdID").DefaultValue = _
      ProductsGridView.SelectedValue.ToString()
    ProductFormView.DataBind()
  End Sub

  Sub ProductFormView_ItemUpdated(sender As Object, e As FormViewUpdatedEventArgs)
    ProductsGridView.DataBind()
  End Sub
  
  Sub ProductFormView_ItemDeleted(sender As Object, e As FormViewDeletedEventArgs)
    ProductsGridView.DataBind()
  End Sub

  Sub ProductDetailsSqlDataSource_OnInserted(sender As Object, e As SqlDataSourceStatusEventArgs)
    Dim command As System.Data.Common.DbCommand = e.Command    
    
    ProductDetailsSqlDataSource.SelectParameters("ProdID").DefaultValue = _
      command.Parameters("@ProdID").Value.ToString()

    ProductsGridView.DataBind()
    ProductFormView.DataBind()
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormView Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView Example</h3>

        <table cellspacing="10">
            
          <tr>
            <td>
              <asp:GridView ID="ProductsGridView" 
                DataSourceID="ProductsSqlDataSource" 
                AutoGenerateColumns="False"
                DataKeyNames="ProductID" 
                OnSelectedIndexChanged="ProductsGridView_OnSelectedIndexChanged"
                RunAt="Server" AllowPaging="True">
                
                <HeaderStyle backcolor="Navy"
                  forecolor="White" />
                
                <Columns>
                  <asp:CommandField ShowSelectButton="True" />
                  <asp:BoundField DataField="ProductID"   HeaderText="Product ID"/>
                  <asp:BoundField DataField="ProductName" HeaderText="Product Name"/>                        
                  <asp:BoundField DataField="CategoryName"    HeaderText="Category"/>
                    
                </Columns>
                
              </asp:GridView>
            
            </td>
                
            <td valign="top">
                
              <asp:FormView ID="ProductFormView"
                DataSourceID="ProductDetailsSqlDataSource"
                DataKeyNames="ProductID"     
                Gridlines="Both" 
                OnItemUpdated="ProductFormView_ItemUpdated"
                OnItemDeleted="ProductFormView_ItemDeleted"      
                RunAt="server">
                
                <HeaderStyle backcolor="Navy"
                  forecolor="White"/>
                  
                <RowStyle backcolor="White"/>         
                
                <EditRowStyle backcolor="LightCyan"/>
                                    
                <ItemTemplate>
                  <table>
                    <tr><td align="right"><b>Product ID:</b></td>  <td><%# Eval("ProductID") %></td></tr>
                    <tr><td align="right"><b>Product Name:</b></td><td><%# Eval("ProductName") %></td></tr>
                    <tr><td align="right"><b>Category:</b></td>    <td><%# Eval("CategoryName") %></td></tr>
                    <tr>
                      <td colspan="2">
                        <asp:LinkButton ID="EditButton"
                                        Text="Edit"
                                        CommandName="Edit"
                                        RunAt="server"/>
                        &nbsp;
                        <asp:LinkButton ID="NewButton"
                                        Text="New"
                                        CommandName="New"
                                        RunAt="server"/>
                        &nbsp;
                        <asp:LinkButton ID="DeleteButton"
                                        Text="Delete"
                                        CommandName="Delete"
                                        RunAt="server"/>
                      </td>
                    </tr>
                  </table>                 
                </ItemTemplate>

                <EditItemTemplate>
                  <table>
                    <tr><td align="right"><b>Product ID:</b></td><td><%# Eval("ProductID") %></td></tr>

                    <tr><td align="right"><b>Product Name:</b></td>
                        <td><asp:TextBox ID="EditProductNameTextBox" 
                                         Text='<%# Bind("ProductName") %>' 
                                         RunAt="Server" /></td></tr>

                    <tr><td align="right"><b>Category:</b></td>
                        <td><asp:DropDownList ID="EditCategoryDropDownList" 
                                         SelectedValue='<%# Bind("CategoryID") %>' 
                                         DataSourceID="CategoriesDataSource"
                                         DataTextField="CategoryName"
                                         DataValueField="CategoryID"
                                         RunAt="Server" /></td></tr>
                    <tr>
                      <td colspan="2">
                        <asp:LinkButton ID="UpdateButton"
                                        Text="Update"
                                        CommandName="Update"
                                        RunAt="server"/>
                        &nbsp;
                        <asp:LinkButton ID="CancelUpdateButton"
                                        Text="Cancel"
                                        CommandName="Cancel"
                                        RunAt="server"/>
                      </td>
                    </tr>
                  </table>                 
                </EditItemTemplate>

                <InsertItemTemplate>
                  <table>
                    <tr><td align="right"><b>Product Name:</b></td>
                        <td><asp:TextBox ID="InsertProductNameTextBox" 
                                         Text='<%# Bind("ProductName") %>' 
                                         RunAt="Server" /></td></tr>
<%--<Snippet6> --%>
<tr>
  <td align="right"><b>Category:</b></td>
  <td><asp:DropDownList ID="InsertCategoryDropDownList" 
                        SelectedValue='<%# Bind("CategoryID") %>' 
                        DataSourceID="CategoriesDataSource"
                        DataTextField="CategoryName"
                        DataValueField="CategoryID"
                        RunAt="Server" />
  </td>
</tr>
<%--</Snippet6> --%>
                    <tr>
                      <td colspan="2">
                        <asp:LinkButton ID="InsertButton"
                                        Text="Insert"
                                        CommandName="Insert"
                                        RunAt="server"/>
                        &nbsp;
                        <asp:LinkButton ID="CancelInsertButton"
                                        Text="Cancel"
                                        CommandName="Cancel"
                                        RunAt="server"/>
                      </td>
                    </tr>
                  </table>                 
                </InsertItemTemplate>

              </asp:FormView>

            </td>
                
          </tr>
            
        </table>
            
        <asp:sqlDataSource ID="ProductsSqlDataSource"  
          selectCommand="SELECT ProductID, ProductName, CategoryName FROM Products LEFT JOIN Categories ON Products.CategoryID = Categories.CategoryID" 
          connectionstring="<%$ ConnectionStrings:NorthwindConnection %>" 
          RunAt="server">
        </asp:sqlDataSource>
         
        <asp:sqlDataSource ID="ProductDetailsSqlDataSource" 
          selectCommand="SELECT ProductID, ProductName, Products.CategoryID, CategoryName FROM Products LEFT JOIN Categories ON Products.CategoryID = Categories.CategoryID WHERE ProductID=@ProdID" 

          InsertCommand="INSERT INTO Products (ProductName, CategoryID) VALUES (@ProductName, @CategoryID); 
                         SELECT @ProdID = SCOPE_IDENTITY()"
          UpdateCommand="UPDATE Products SET ProductName=@ProductName, CategoryID=@CategoryID 
                           WHERE ProductID=@ProductID"
          DeleteCommand="DELETE Products WHERE ProductID=@ProductID"

          ConnectionString="<%$ ConnectionStrings:NorthwindConnection %>"
          OnInserted="ProductDetailsSqlDataSource_OnInserted"
          RunAt="server">
          
          <SelectParameters>
            <asp:Parameter Name="ProdID" Type="Int32" DefaultValue="0" />
          </SelectParameters>
          
          <InsertParameters>
            <asp:Parameter Name="ProdID" Direction="Output" Type="Int32" DefaultValue="0" />
          </InsertParameters>

        </asp:sqlDataSource>
        
        <asp:sqlDataSource ID="CategoriesDataSource"  
          selectCommand="SELECT CategoryID, CategoryName FROM Categories" 
          connectionstring="<%$ ConnectionStrings:NorthwindConnection %>" 
          RunAt="server">
        </asp:sqlDataSource>
  
      </form>
  </body>
</html>
