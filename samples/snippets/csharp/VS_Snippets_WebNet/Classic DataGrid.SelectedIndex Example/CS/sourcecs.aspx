<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

   <script language="C#" runat="server">
 
      DataTable Cart = new DataTable();
      DataView CartView;   
 
      void Page_Load(Object sender, EventArgs e) 
      {
         DataRow dr;
 
         if (Session["ShoppingCart"] == null) 
         {       
            Cart.Columns.Add(new DataColumn("Qty", typeof(String)));
            Cart.Columns.Add(new DataColumn("Item", typeof(String)));
            Cart.Columns.Add(new DataColumn("Price", typeof(String)));
            Session["ShoppingCart"] = Cart;
             
            // Create rows and add sample data.
            for (int i = 1; i <= 9; i++) 
            {
               dr = Cart.NewRow();
               if (i % 2 != 0)
                  dr[0] = "2";
               else
                  dr[0] = "1";
               dr[1] = "Item " + i.ToString();
               dr[2] = (1.23 * (i + 1)).ToString();
               Cart.Rows.Add(dr);
            }
         }
         else
            Cart = (DataTable)Session["ShoppingCart"];          
 
         CartView = new DataView(Cart);
         CartView.Sort="Item";
 
         if (!IsPostBack)
            BindGrid();                    
      }
 
      void MyDataGrid_Select(Object sender, EventArgs e) 
      {
 
         Label1.Text = "You selected " +
                       MyDataGrid.SelectedItem.Cells[1].Text +
                       ".<br />" + 
                       MyDataGrid.SelectedItem.Cells[1].Text +
                       " has an index number of " +
                       MyDataGrid.SelectedIndex.ToString() + ".";
                                
      }

      void Select_Button_Click(Object sender, EventArgs e) 
      {
 
         MyDataGrid.SelectedIndex = 4;
                                
      }

      void UnSelect_Button_Click(Object sender, EventArgs e) 
      {
 
         MyDataGrid.SelectedIndex = -1;
         Label1.Text = "";
                                
      }
 
      void BindGrid() 
      {
         MyDataGrid.DataSource = CartView;
         MyDataGrid.DataBind();
      } 
 
   </script>
 
<head runat="server">
    <title>DataGrid Selection Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataGrid Selection Example</h3>
 
      <asp:DataGrid id="MyDataGrid" runat="server"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           Font-Names="Verdana"
           Font-Size="8pt"
           OnSelectedIndexChanged="MyDataGrid_Select"
           AutoGenerateColumns="false">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <SelectedItemStyle BackColor="Yellow">
         </SelectedItemStyle>
 
         <Columns>

            <asp:ButtonColumn
                 HeaderText="Select Item"
                 ButtonType="LinkButton"
                 Text="Select"
                 CommandName="Select">

            </asp:ButtonColumn>
 
            <asp:BoundColumn 
                 HeaderText="Item" 
                 ReadOnly="true" 
                 DataField="Item"/>

            <asp:BoundColumn 
                 HeaderText="Quantity" 
                 DataField="Qty"/>

            <asp:BoundColumn 
                 HeaderText="Price" 
                 DataField="Price"/>

         </Columns>

      </asp:DataGrid>

      <br /><br />

      <asp:Button id="Button1"
           Text="Select Item 5"
           OnClick="Select_Button_Click"
           runat="server"/>

      <asp:Button id="Button2"
           Text="Unselect Item"
           OnClick="UnSelect_Button_Click"
           runat="server"/>

      <br /><br />

      <asp:Label id="Label1" runat="server"/> 
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->
