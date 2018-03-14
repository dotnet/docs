<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>DataList Select Example</title>
<script runat="server">

      Function CreateDataSource() As ICollection 
      
         ' Create sample data for the DataList control.
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow
 
         ' Define the columns of the table.
         dt.Columns.Add(New DataColumn("Item", GetType(Int32)))
         dt.Columns.Add(New DataColumn("Qty", GetType(Int32)))
         dt.Columns.Add(New DataColumn("Price", GetType(Double)))
 
         ' Populate the table with sample values.
         Dim i As Integer

         For i = 0 To 8 

            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = i * 2
            dr(2) = 1.23 * (i + 1)
 
            dt.Rows.Add(dr)
         
         Next i
 
         Dim dv As DataView = New DataView(dt)
         Return dv
      
      End Function
 
      Sub Page_Load(sender As Object, e As EventArgs) 

         ' Load sample data only once, when the page is first loaded.
         If Not IsPostBack Then 
         
            ItemsList.DataSource = CreateDataSource()
            ItemsList.DataBind()
         
         End If

      End Sub

      Sub Item_Command(sender As Object, e As DataListCommandEventArgs) 
        
         ' Set the SelectedIndex property to select an item in the DataList.
         ItemsList.SelectedIndex = e.Item.ItemIndex

         ' Rebind the data source to the DataList to refresh the control.
         ItemsList.DataSource = CreateDataSource()
         ItemsList.DataBind()

      End Sub

   </script>

</head>
<body>

   <form id="form1" runat="server">

      <h3>DataList Select Example</h3>

      Click <b>Select</b> to select an item.

      <br /><br />
       
      <asp:DataList id="ItemsList"
           GridLines="Both"
           CellPadding="3"
           CellSpacing="0"           
           OnItemCommand="Item_Command"
           runat="server">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>

         <SelectedItemStyle BackColor="Yellow">
         </SelectedItemStyle>

         <HeaderTemplate>

            Items

         </HeaderTemplate>
         
         <ItemTemplate>

            <asp:LinkButton id="SelectButton" 
                 Text="Select" 
                 CommandName="Select"
                 runat="server"/>

            Item <%# DataBinder.Eval(Container.DataItem, "Item") %>

         </ItemTemplate>
              
         <SelectedItemTemplate>

            Item:
            <asp:Label id="ItemLabel" 
                 Text='<%# DataBinder.Eval(Container.DataItem, "Item") %>' 
                 runat="server"/>

            <br />

            Quantity:
            <asp:Label id="QtyLabel" 
                 Text='<%# DataBinder.Eval(Container.DataItem, "Qty") %>' 
                 runat="server"/>

            <br />

            Price:
            <asp:Label id="PriceLabel" 
                 Text='<%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>' 
                 runat="server"/>

         </SelectedItemTemplate>

      </asp:DataList>

   </form>

</body>
</html>

<!-- </Snippet1> -->