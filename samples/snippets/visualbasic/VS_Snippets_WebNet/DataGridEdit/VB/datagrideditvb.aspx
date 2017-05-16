<!--<Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      ' The Cart and CartView objects temporarily store the data source
      ' for the DataGrid control while the page is being processed.
      Dim Cart As DataTable = New DataTable()
      Dim CartView As DataView    
 
      Sub Page_Load(sender As Object, e As EventArgs) 
 
         ' With a database, use an select query to retrieve the data. Because 
         ' the data source in this example is an in-memory DataTable, retrieve
         ' the data from session state if it exists; otherwise create the data
         ' source.
         GetSource()

         ' The DataGrid control maintains state between posts to the server;
         ' it only needs to be bound to a data source the first time the page
         ' is loaded or when the data source is updated.
         If Not IsPostBack Then

            BindGrid()

         End If
                   
      End Sub
 
      Sub ItemsGrid_Edit(sender As Object, e As DataGridCommandEventArgs) 

         ' Set the EditItemIndex property to the index of the item clicked 
         ' in the DataGrid control to enable editing for that item. Be sure
         ' to rebind the DateGrid to the data source to refresh the control.
         ItemsGrid.EditItemIndex = e.Item.ItemIndex
         BindGrid()

      End Sub
 
      Sub ItemsGrid_Cancel(sender As Object, e As DataGridCommandEventArgs) 

         ' Set the EditItemIndex property to -1 to exit editing mode.
         ' Be sure to rebind the DateGrid to the data source to refresh
         ' the control.
         ItemsGrid.EditItemIndex = -1
         BindGrid()

      End Sub
 
      Sub ItemsGrid_Update(sender As Object, e As DataGridCommandEventArgs) 

         ' Retrieve the text boxes that contain the values to update.
         ' For bound columns, the edited value is stored in a TextBox.
         ' The TextBox is the 0th control in a cell's Controls collection.
         ' Each cell in the Cells collection of a DataGrid item represents
         ' a column in the DataGrid control.
         Dim qtyText As TextBox = CType(e.Item.Cells(3).Controls(0), TextBox)
         Dim priceText As TextBox = CType(e.Item.Cells(4).Controls(0), TextBox)
 
         ' Retrieve the updated values.
         Dim item As String = e.Item.Cells(2).Text
         Dim qty As String = qtyText.Text
         Dim price As String = priceText.Text
        
         Dim dr As DataRow
 
         ' With a database, use an update command to update the data. 
         ' Because the data source in this example is an in-memory 
         ' DataTable, delete the old row and replace it with a new one.
 
         ' Remove the old entry and clear the row filter.
         CartView.RowFilter = "Item='" & item & "'"
         If CartView.Count > 0 Then
       
            CartView.Delete(0)
         
         End If 
         CartView.RowFilter = ""
 
         ' ***************************************************************
         ' Insert data validation code here. Be sure to validate the
         ' values entered by the user before converting to the appropriate
         ' data types and updating the data source.
         ' ***************************************************************

         ' Add the new entry.
         dr = Cart.NewRow()
         dr(0) = Convert.ToInt32(qty)
         dr(1) = item

         ' If necessary, remove the '$' character from the price before 
         ' converting it to a Double.
         If price.Chars(0) = "$" Then
         
            dr(2) = Convert.ToDouble(price.Substring(1))
         
         Else
         
            dr(2) = Convert.ToDouble(price)
         
         End If

         Cart.Rows.Add(dr)
 
         ' Set the EditItemIndex property to -1 to exit editing mode.
         ' Be sure to rebind the DateGrid to the data source to refresh
         ' the control.
         ItemsGrid.EditItemIndex = -1
         BindGrid()

      End Sub
 
      Sub BindGrid() 

         ' Set the data source and bind to the Data Grid control.
         ItemsGrid.DataSource = CartView
         ItemsGrid.DataBind()

      End Sub

      Sub GetSource()

         ' For this example, the data source is a DataTable that is stored
         ' in session state. If the data source does not exist, create it;
         ' otherwise, load the data.
         If Session("ShoppingCart") Is Nothing Then 

            ' Create the sample data.
            Dim dr As DataRow  
 
            ' Define the columns of the table.
            Cart.Columns.Add(new DataColumn("Qty", GetType(Int32)))
            Cart.Columns.Add(new DataColumn("Item", GetType(String)))
            Cart.Columns.Add(new DataColumn("Price", GetType(Double)))

            ' Store the table in session state to persist its values
            ' between posts to the server.
            Session("ShoppingCart") = Cart
             
            ' Populate the DataTable with sample data.
            Dim i As Integer

            For i = 1 To 9 
            
               dr = Cart.NewRow()
               If (i Mod 2) <> 0 Then

                  dr(0) = 2
               
               Else
               
                  dr(0) = 1
               
               End If

               dr(1) = "Item " & i.ToString()
               dr(2) = (1.23 * (i + 1))
               Cart.Rows.Add(dr)
            
            Next i

         Else

            ' Retrieve the sample data from session state.
            Cart = CType(Session("ShoppingCart"), DataTable)

         End If         
 
         ' Create a DataView and specify the field to sort by.
         CartView = New DataView(Cart)
         CartView.Sort="Item"

         Return

      End Sub

      Sub ItemsGrid_Command(sender As Object, e As DataGridCommandEventArgs)

         Select (CType(e.CommandSource, LinkButton)).CommandName

            Case "Delete"
               DeleteItem(e)

            ' Add other cases here, if there are multiple ButtonColumns in 
            ' the DataGrid control.

            Case Else
               ' Do nothing.

         End Select

      End Sub

      Sub DeleteItem(e As DataGridCommandEventArgs)

         ' e.Item is the table row where the command is raised. For bound 
         ' columns, the value is stored in the Text property of a TableCell.
         Dim itemCell As TableCell = e.Item.Cells(2)
         Dim item As String = itemCell.Text

         ' Remove the selected item from the data source.         
         CartView.RowFilter = "Item='" & item + "'"
         If CartView.Count > 0 Then 
              
            CartView.Delete(0)

         End If
         
         CartView.RowFilter = ""

         ' Rebind the data source to refresh the DataGrid control.
         BindGrid()

      End Sub
 
   </script>
 
<head runat="server">
    <title>DataGrid Editing Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataGrid Editing Example</h3>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           OnEditCommand="ItemsGrid_Edit"
           OnCancelCommand="ItemsGrid_Cancel"
           OnUpdateCommand="ItemsGrid_Update"
           OnItemCommand="ItemsGrid_Command"
           AutoGenerateColumns="false"
           runat="server">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>
 
         <Columns>

            <asp:EditCommandColumn
                 EditText="Edit"
                 CancelText="Cancel"
                 UpdateText="Update" 
                 HeaderText="Edit item">

               <ItemStyle Wrap="False">
               </ItemStyle>

               <HeaderStyle Wrap="False">
               </HeaderStyle>

            </asp:EditCommandColumn>

            <asp:ButtonColumn 
                 HeaderText="Delete item" 
                 ButtonType="LinkButton" 
                 Text="Delete" 
                 CommandName="Delete"/>  
 
            <asp:BoundColumn HeaderText="Item" 
                 ReadOnly="True" 
                 DataField="Item"/>
 
            <asp:BoundColumn HeaderText="Quantity" 
                 DataField="Qty"/>
 
            <asp:BoundColumn HeaderText="Price"
                 DataField="Price"
                 DataFormatString="{0:c}"/>
 
         </Columns>
 
      </asp:DataGrid>

   </form>
 
</body>
</html>

<!--</Snippet1> -->