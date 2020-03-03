<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>DataList Edit Example</title>
<script runat="server">

      ' The Cart and CartView objects temporarily store the data source
      ' for the DataList control while the page is being processed.
      Dim Cart As DataTable = New DataTable()
      Dim CartView As DataView
 
      Sub Page_Load(sende As Object, e As EventArgs) 
 
         ' With a database, use an select query to retrieve the data.
         ' Because the data source in this example is an in-memory
         ' DataTable, retrieve the data from session state if it exists;
         ' otherwise, create the data source.
         GetSource()

         ' The DataGrid control maintains state between posts to the server;
         ' it only needs to be bound to a data source the first time the
         ' page is loaded or when the data source is updated.
         If Not IsPostBack Then

            BindList()

         End If
                   
      End Sub

      Sub BindList() 

         ' Set the data source and bind to the DataList control.
         ItemsList.DataSource = CartView
         ItemsList.DataBind()

      End Sub

      Sub GetSource()

         ' For this example, the data source is a DataTable that
         ' is stored in session state. If the data source does not exist,
         ' create it; otherwise, load the data.
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

      Sub Edit_Command(sender As Object, e As DataListCommandEventArgs) 

         ' Set the EditItemIndex property to the index of the item clicked
         ' in the DataList control to enable editing for that item. Be sure
         ' to rebind the DataList to the data source to refresh the control.
         ItemsList.EditItemIndex = e.Item.ItemIndex
         BindList()

      End Sub

      Sub Cancel_Command(sender As Object, e As DataListCommandEventArgs) 

         ' Set the EditItemIndex property to -1 to exit editing mode. Be sure
         ' to rebind the DataList to the data source to refresh the control.
         ItemsList.EditItemIndex = -1
         BindList()

      End Sub

      Sub Delete_Command(sender As Object, e As DataListCommandEventArgs) 

         ' Retrieve the name of the item to remove.
         Dim item As String = (CType(e.Item.FindControl("ItemLabel"), Label)).Text

         ' Filter the CartView for the selected item and remove it from
         ' the data source.
         CartView.RowFilter = "Item='" & item & "'"
         If CartView.Count > 0 Then 
       
            CartView.Delete(0)
         
         End If
         CartView.RowFilter = ""

         ' Set the EditItemIndex property to -1 to exit editing mode. Be sure 
         ' to rebind the DataList to the data source to refresh the control.
         ItemsList.EditItemIndex = -1
         BindList()

      End Sub

      Sub Update_Command(sender As Object, e As DataListCommandEventArgs) 

         ' Retrieve the updated values from the selected item.
         Dim item As String = _
             (CType(e.Item.FindControl("ItemLabel"), Label)).Text
         Dim qty As String = _
             (CType(e.Item.FindControl("QtyTextBox"), TextBox)).Text
         Dim price As String = _
             (CType(e.Item.FindControl("PriceTextBox"), TextBox)).Text

         ' With a database, use an update command to update the data.
         ' Because the data source in this example is an in-memory 
         ' DataTable, delete the old row and replace it with a new one.

         ' Filter the CartView for the selected item and remove it from 
         ' the data source.
         CartView.RowFilter = "Item='" & item & "'"
         If CartView.Count > 0 Then 
       
            CartView.Delete(0)
         
         End If
         CartView.RowFilter = ""

         ' ***************************************************************
         ' Insert data validation code here. Make sure to validate the
         ' values entered by the user before converting to the appropriate
         ' data types and updating the data source.
         ' ***************************************************************

         ' Add a new entry to replace the previous item.
         Dim dr As DataRow = Cart.NewRow()
         dr(0) = qty
         dr(1) = item
         ' If necessary, remove the '$' character from the price before 
         ' converting the price to a Double.
         If price.Chars(0) = "$" Then

            dr(2) = Convert.ToDouble(price.Substring(1))

         Else

            dr(2) = Convert.ToDouble(price)
         
         End If

         Cart.Rows.Add(dr)

         ' Set the EditItemIndex property to -1 to exit editing mode. 
         ' Be sure to rebind the DataList to the data source to refresh 
         ' the control.
         ItemsList.EditItemIndex = -1
         BindList()

      End Sub

   </script>

</head>
<body>

   <form id="form1" runat="server">

      <h3>DataList Edit Example</h3>

      Click <b>Edit</b> to edit the values of the item.

      <br /><br />
       
      <asp:DataList id="ItemsList"
           GridLines="Both"
           RepeatColumns="3"
           RepeatDirection="Horizontal"
           CellPadding="3"
           CellSpacing="0"
           OnEditCommand="Edit_Command"
           OnUpdateCommand="Update_Command"
           OnDeleteCommand="Delete_Command"
           OnCancelCommand="Cancel_Command"
           runat="server">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>

         <EditItemStyle BackColor="yellow">
         </EditItemStyle>

         <HeaderTemplate>

            Items

         </HeaderTemplate>
         
         <ItemTemplate>

            Item:
            <%# DataBinder.Eval(Container.DataItem, "Item") %> 

            <br />

            Quantity:
            <%# DataBinder.Eval(Container.DataItem, "Qty") %>

            <br />

            Price:
            <%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>

            <br />

            <asp:LinkButton id="EditButton" 
                 Text="Edit" 
                 CommandName="Edit"
                 runat="server"/>

         </ItemTemplate>
              
         <EditItemTemplate>

            Item:
            <asp:Label id="ItemLabel" 
                 Text='<%# DataBinder.Eval(Container.DataItem, "Item") %>' 
                 runat="server"/>

            <br />

            Quantity:
            <asp:TextBox id="QtyTextBox" 
                 Text='<%# DataBinder.Eval(Container.DataItem, "Qty") %>' 
                 runat="server"/>

            <br />

            Price:
            <asp:TextBox id="PriceTextBox" 
                 Text='<%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>' 
                 runat="server"/>

            <br />

            <asp:LinkButton id="UpdateButton" 
                 Text="Update" 
                 CommandName="Update" 
                 runat="server"/>

            <asp:LinkButton id="DeleteButton" 
                 Text="Delete" 
                 CommandName="Delete" 
                 runat="server"/>

            <asp:LinkButton id="CancelButton" 
                 Text="Cancel" 
                 CommandName="Cancel" 
                 runat="server"/>

         </EditItemTemplate>

      </asp:DataList>

   </form>

</body>
</html>

<!-- </Snippet1> -->