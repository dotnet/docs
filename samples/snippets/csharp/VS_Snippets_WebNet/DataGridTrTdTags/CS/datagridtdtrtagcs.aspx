<!--<Snippet1>-->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<script runat="server">
 
   ICollection CreateDataSource() 
   {
      DataTable dt = new DataTable();
      DataRow dr;
 
      dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
      dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
      dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
 
      for (int i = 0; i < 5; i++) 
      {
         dr = dt.NewRow();
 
         dr[0] = i;
         dr[1] = "Item " + i.ToString();
         dr[2] = 1.23 * (i+1);
 
         dt.Rows.Add(dr);
      }
 
      DataView dv = new DataView(dt);
      return dv;
   }
 
   void Page_Load(Object sender, EventArgs e) 
   {
 
      if (!IsPostBack) 
      {
         // Load this data only once.
         ItemsGrid.DataSource = CreateDataSource();
         ItemsGrid.DataBind();
      }
 
   }
 
   void Item_Bound(Object sender, DataGridItemEventArgs e) 
   {

      ListItemType itemType = (ListItemType)e.Item.ItemType;

      if ((itemType != ListItemType.Header) &&
          (itemType != ListItemType.Footer) &&
          (itemType != ListItemType.Separator))
      {

         // Get the IntegerValue cell from the grid's column collection.
         TableCell intCell = (TableCell)e.Item.Controls[0];

         // Add attributes to the cell.
         intCell.Attributes.Add("id", "intCell" + e.Item.ItemIndex.ToString());
         intCell.Attributes.Add("OnClick", 
                                "Update_intCell" + 
                                e.Item.ItemIndex.ToString() + 
                                "()");

         // Add attributes to the row.
         e.Item.Attributes.Add("id", "row" + e.Item.ItemIndex.ToString());
         e.Item.Attributes.Add("OnDblClick", 
                                "Update_row" + 
                                e.Item.ItemIndex.ToString() + 
                                "()");
         
      }
 
   }
 
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