<!-- <Snippet2> -->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language="VB" runat="server">
 
      Dim Cart As DataTable
      Dim CartView As DataView
      
        Function CreateDataSource() As ICollection
            Dim dt As New DataTable()
            Dim dr As DataRow
            
            dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
            dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
            dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
            
            Dim i As Integer
            For i = 0 To 8
                dr = dt.NewRow()
                
                dr(0) = i
                dr(1) = "Item " + i.ToString()
                dr(2) = 1.23 *(i + 1)
                
                dt.Rows.Add(dr)
            Next i
            
            Dim dv As New DataView(dt)
            Return dv
        End Function 'CreateDataSource


        Sub Page_Load(sender As Object, e As EventArgs)
            
            If Session("DG4_ShoppingCart") Is Nothing Then
                Cart = New DataTable()
                Cart.Columns.Add(New DataColumn("Item", GetType(String)))
                Cart.Columns.Add(New DataColumn("Price", GetType(String)))
                Session("DG4_ShoppingCart") = Cart
            
            Else
                Cart = CType(Session("DG4_ShoppingCart"), DataTable)
            End If
            
            CartView = New DataView(Cart)
            ShoppingCart.DataSource = CartView
            ShoppingCart.DataBind()
            
            If Not IsPostBack Then
                ' Load this data only once.
                ItemsGrid.DataSource = CreateDataSource()
                ItemsGrid.DataBind()
            End If
        End Sub 'Page_Load


        Sub Grid_CartCommand(sender As Object, e As DataGridCommandEventArgs)
            
            Dim dr As DataRow = Cart.NewRow()
            
            ' e.Item is the table row where the command is raised.
            ' For bound columns, the value is stored in the Text property of the TableCell.
            Dim itemCell As TableCell = e.Item.Cells(2)
            Dim priceCell As TableCell = e.Item.Cells(3)
            Dim item As String = itemCell.Text
            Dim price As String = priceCell.Text
            
            If CType(e.CommandSource, Button).CommandName = "AddToCart" Then
                dr(0) = item
                dr(1) = price
                Cart.Rows.Add(dr)
            
            Else 

                'Remove from Cart.
                CartView.RowFilter = "Item" + ChrW(61) + "'" + item + "'"
                If CartView.Count > 0 Then
                    CartView.Delete(0)
                End If
                CartView.RowFilter = ""
            End If
            
            ShoppingCart.DataBind()
        End Sub 'Grid_CartCommand 
   </script>
 
<head runat="server">
    <title>DataGrid Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
   <h3>DataGrid Example</h3>
 
   <table cellpadding="5">
      <tr valign="top">
         <td>
 
            <b>Product List</b>
 
            <asp:DataGrid id="ItemsGrid"
                 BorderColor="black"
                 BorderWidth="1"
                 CellPadding="3"
                 AutoGenerateColumns="false"
                 OnItemCommand="Grid_CartCommand"
                 runat="server">

               <HeaderStyle BackColor="#00aaaa">
               </HeaderStyle>
 
               <Columns>
 
                  <asp:ButtonColumn 
                       HeaderText="Add to cart" 
                       ButtonType="PushButton" 
                       Text="Add" 
                       CommandName="AddToCart" />
 
                  <asp:ButtonColumn 
                       HeaderText="Remove from cart" 
                       ButtonType="PushButton" 
                       Text="Remove" 
                       CommandName="RemoveFromCart" />
 
                  <asp:BoundColumn 
                       HeaderText="Item" 
                       DataField="StringValue"/>

                  <asp:BoundColumn 
                       HeaderText="Price" 
                       DataField="CurrencyValue" 
                       DataFormatString="{0:c}">

                     <ItemStyle HorizontalAlign="right">
                     </ItemStyle>

                  </asp:BoundColumn>   
 
               </Columns>
 
            </asp:DataGrid>
 
         </td>
         <td>
 
            <b>Shopping Cart</b>
 
            <asp:DataGrid id="ShoppingCart" 
                 runat="server"
                 BorderColor="black"
                 BorderWidth="1"
                 GridLines="Both"
                 ShowFooter="false"
                 CellPadding="3"
                 CellSpacing="0">

               <HeaderStyle BackColor="#00aaaa">
               </HeaderStyle>

            </asp:DataGrid> 
 
         </td>
      </tr>
 
   </table>
 
   </form>
 
</body>
</html>
<!-- </Snippet2> -->

