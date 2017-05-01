<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language="C#" runat="server">
 
      DataTable Cart;
      DataView CartView;
 
      ICollection CreateDataSource() 
      {
         DataTable dt = new DataTable();
         DataRow dr;
 
         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
         dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
 
         for (int i = 0; i < 9; i++) 
         {
            dr = dt.NewRow();
 
            dr[0] = i;
            dr[1] = "Item " + i.ToString();
            dr[2] = 1.23 * (i + 1);
 
            dt.Rows.Add(dr);
         }
 
         DataView dv = new DataView(dt);
         return dv;
      }
 
      void Page_Load(Object sender, EventArgs e) 
      {
     
         if (Session["DG4_ShoppingCart"] == null) 
         {
            Cart = new DataTable();
            Cart.Columns.Add(new DataColumn("Item", typeof(string)));
            Cart.Columns.Add(new DataColumn("Price", typeof(string)));
            Session["DG4_ShoppingCart"] = Cart;
         }

         else 
         {
            Cart = (DataTable)Session["DG4_ShoppingCart"];
         }    

         CartView = new DataView(Cart);
         ShoppingCart.DataSource = CartView;
         ShoppingCart.DataBind();
 
         if (!IsPostBack) 
         {
            // Load this data only once.
            ItemsGrid.DataSource= CreateDataSource();
            ItemsGrid.DataBind();
         }
      }
 
      void Grid_CartCommand(Object sender, DataGridCommandEventArgs e) 
      {
     
         DataRow dr = Cart.NewRow();
         
         // e.Item is the table row where the command is raised.
         // For bound columns, the value is stored in the Text property of a TableCell.
         TableCell itemCell = e.Item.Cells[2];
         TableCell priceCell = e.Item.Cells[3];
         string item = itemCell.Text;
         string price = priceCell.Text;
          
         if (((Button)e.CommandSource).CommandName == "AddToCart") 
         {
            dr[0] = item;
            dr[1] = price;
            Cart.Rows.Add(dr);
         }

         else 
         {  // Remove from Cart.
         
            CartView.RowFilter = "Item='" + item + "'";
            if (CartView.Count > 0) 
            {     
               CartView.Delete(0);
            }
            CartView.RowFilter = "";
         }

         ShoppingCart.DataBind();
 
      }
 
 
   </script>
 
<head runat="server">
    <title>ButtonColumn Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
   <h3>ButtonColumn Example</h3>
 
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

<!--</Snippet1>-->
