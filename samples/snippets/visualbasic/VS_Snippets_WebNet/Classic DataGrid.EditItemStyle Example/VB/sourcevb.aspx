<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <script language="VB" runat="server">
 
    Dim Cart As New DataTable
    Dim CartView As DataView
    
    Sub Page_Load(sender As Object, e As EventArgs)
        Dim dr As DataRow
        
        If Session("ShoppingCart") Is Nothing Then
            
            Cart.Columns.Add(New DataColumn("Qty", GetType(String)))
            Cart.Columns.Add(New DataColumn("Item", GetType(String)))
            Cart.Columns.Add(New DataColumn("Price", GetType(String)))
            Session("ShoppingCart") = Cart
            
            ' Create sample data.
            Dim i As Integer
            For i = 1 To 4
                dr = Cart.NewRow()
                If i Mod 2 <> 0 Then
                    dr(0) = "2"
                Else
                    dr(0) = "1"
                End If
                dr(1) = "Item " & i.ToString()
                dr(2) =(1.23 *(i + 1)).ToString()
                Cart.Rows.Add(dr)
            Next i
        Else
            Cart = CType(Session("ShoppingCart"), DataTable)
        End If 
        CartView = New DataView(Cart)
        CartView.Sort = "Item"
        
        If Not IsPostBack Then
            BindGrid()
        End If 
    End Sub 'Page_Load


    Sub MyDataGrid_Edit(sender As Object, e As DataGridCommandEventArgs)
        MyDataGrid.EditItemIndex = e.Item.ItemIndex
        BindGrid()
    End Sub 'MyDataGrid_Edit


    Sub MyDataGrid_Cancel(sender As Object, e As DataGridCommandEventArgs)
        MyDataGrid.EditItemIndex = - 1
        BindGrid()
    End Sub 'MyDataGrid_Cancel


    Sub MyDataGrid_Update(sender As Object, e As DataGridCommandEventArgs)
        ' For bound columns, the edited value is stored in a TextBox.
        ' The TextBox is the 0th element in the column's cell.
        Dim qtyText As TextBox = CType(e.Item.Cells(2).Controls(0), TextBox)
        Dim priceText As TextBox = CType(e.Item.Cells(3).Controls(0), TextBox)
        
        Dim item As String = e.Item.Cells(1).Text
        Dim qty As String = qtyText.Text
        Dim price As String = priceText.Text
        
        Dim dr As DataRow
        
        ' With a database, use an update command to update the data. Because 
        ' the data source in this example is an in-memory DataTable, delete the 
        ' old row and replace it with a new one.

        ' Remove old entry.
        CartView.RowFilter = "Item='" & item & "'"
        If CartView.Count > 0 Then
            CartView.Delete(0)
        End If
        CartView.RowFilter = ""
        
        ' Add new entry.
        dr = Cart.NewRow()
        dr(0) = qty
        dr(1) = item
        dr(2) = price
        Cart.Rows.Add(dr)
        
        MyDataGrid.EditItemIndex = - 1
        BindGrid()
    End Sub 'MyDataGrid_Update


    Sub BindGrid()
        MyDataGrid.DataSource = CartView
        MyDataGrid.DataBind()
    End Sub 'BindGrid
 
 </script>
 
 <head runat="server">
    <title>DataGrid Editing Example</title>
</head>
<body style="font: 10pt verdana">
 
    <form id="form1" runat="server">
        
       <h3>DataGrid Editing Example</h3>
 
       <asp:DataGrid id="MyDataGrid" runat="server"
            BorderColor="black"
            BorderWidth="1"
            CellPadding="3"
            Font-Names="Verdana"
            Font-Size="8pt"
            OnEditCommand="MyDataGrid_Edit"
            OnCancelCommand="MyDataGrid_Cancel"
            OnUpdateCommand="MyDataGrid_Update"
            AutoGenerateColumns="false">

            <HeaderStyle BackColor="#aaaadd">
            </HeaderStyle>

            <EditItemStyle BackColor="yellow">
            </EditItemStyle>
 
          <Columns>
 
             <asp:EditCommandColumn
                  EditText="Edit"
                  CancelText="Cancel"
                  UpdateText="Update"
                  HeaderText="Edit Command Column">

                <ItemStyle Wrap="false">
                </ItemStyle>

               <HeaderStyle Wrap="false">
               </HeaderStyle>

             </asp:EditCommandColumn>
 
             <asp:BoundColumn HeaderText="Item" 
                  ReadOnly="true" 
                  DataField="Item"/>
 
             <asp:BoundColumn HeaderText="Quantity" 
                  DataField="Qty"/>
 
             <asp:BoundColumn HeaderText="Price" 
                  DataField="Price"/>
 
          </Columns>
 
       </asp:DataGrid>
 
    </form>
 
 </body>
 </html>
   
<!--</Snippet1>-->
