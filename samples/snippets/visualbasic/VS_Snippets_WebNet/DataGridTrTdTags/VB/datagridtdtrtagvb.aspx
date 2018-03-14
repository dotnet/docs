<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<script runat="server">
 
   Function CreateDataSource() As ICollection 
   
      Dim dt As DataTable = New DataTable()
      Dim dr As DataRow
      Dim i As Integer
      Dim dv As DataView
 
      dt.Columns.Add(New DataColumn("IntegerValue", GetType(Integer)))
      dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
      dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
 
      For i = 0 to 4 

         dr = dt.NewRow()
 
         dr(0) = i
         dr(1) = "Item " + i.ToString()
         dr(2) = 1.23 * (i+1)
 
         dt.Rows.Add(dr)
      
      Next i
 
      dv = New DataView(dt)
      CreateDataSource = dv
   
   End Function
 
   Sub Page_Load(sender As Object, e As EventArgs) 
 
      If Not IsPostBack 
  
         ' Load this data only once.
         ItemsGrid.DataSource = CreateDataSource()
         ItemsGrid.DataBind()
      
      End If 
 
   End Sub
 
   Sub Item_Bound(sender As Object, e As DataGridItemEventArgs) 

      Dim itemType As ListItemType 
      Dim intCell As TableCell

      itemType = CType(e.Item.ItemType, ListItemType)

      If (itemType <> ListItemType.Header) And _
         (itemType <> ListItemType.Footer) And _
         (itemType <> ListItemType.Separator) Then

         ' Get the IntegerValue cell from the grid's column collection.
         intCell = CType(e.Item.Controls(0), TableCell)

         ' Add attributes to the cell.
         intCell.Attributes.Add("id", "intCell" + e.Item.ItemIndex.ToString())
         intCell.Attributes.Add("OnClick", _
                                "Update_intCell" + _
                                e.Item.ItemIndex.ToString() + _
                                "()")
          
         ' Add attributes to the row.
         e.Item.Attributes.Add("id", "row" + e.Item.ItemIndex.ToString())
         e.Item.Attributes.Add("OnDblClick", _
                                "Update_row" + _
                                e.Item.ItemIndex.ToString() + _
                                "()")

      End If
 
   End Sub
 
</script>

<script type="text/vbscript">

   sub Update_intCell0 
      Alert "You Selected Cell 0."
   end sub

   sub Update_intCell1 
      Alert "You Selected Cell 1."
   end sub

   sub Update_intCell2 
      Alert "You Selected Cell 2."
   end sub

   sub Update_intCell3 
      Alert "You Selected Cell 3."
   end sub

   sub Update_intCell4 
      Alert "You Selected Cell 4."
   end sub

   sub UpDate_row0 
      Alert "You selected the row 0."
   end sub

   sub UpDate_row1 
      Alert "You selected the row 1."
   end sub

   sub UpDate_row2 
      Alert "You selected the row 2."
   end sub

   sub UpDate_row3 
      Alert "You selected the row 3."
   end sub

   sub UpDate_row4 
      Alert "You selected the row 4."
   end sub   

</script>
 
<head runat="server">
    <title>

            Adding Attributes to the &lt;td&gt; and &lt;tr&gt; </title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>

            Adding Attributes to the &lt;td&gt; and &lt;tr&gt; <br />
            Tags of a DataGrid Control

      </h3>
 
      <asp:DataGrid id="ItemsGrid" runat="server"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowFooter="true"
           OnItemDataBound="Item_Bound"
           AutoGenerateColumns="false">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>

         <Columns>

            <asp:BoundColumn HeaderText="Number" 
                 DataField="IntegerValue">

               <ItemStyle BackColor="yellow">
               </ItemStyle>
 
            </asp:BoundColumn>

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

      <br /><br />

      Click on one of the cells in the <b>Number</b> column to select the cell.

      <br /><br />

      Double click on a row to select a row.   
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->