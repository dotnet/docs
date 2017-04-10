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
             
          // Create sample data.
          for (int i = 1; i <= 4; i++) 
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
 
    void MyDataGrid_Edit(Object sender, DataGridCommandEventArgs e) 
    {
       MyDataGrid.EditItemIndex = e.Item.ItemIndex;
       BindGrid();
    }
 
    void MyDataGrid_Cancel(Object sender, DataGridCommandEventArgs e) 
    {
       MyDataGrid.EditItemIndex = -1;
       BindGrid();
    }
 
    void MyDataGrid_Update(Object sender, DataGridCommandEventArgs e) 
    {
       // For bound columns, the edited value is stored in a TextBox.
       // The TextBox is the 0th element in the column's cell.
       TextBox qtyText = (TextBox)e.Item.Cells[2].Controls[0];
       TextBox priceText = (TextBox)e.Item.Cells[3].Controls[0];
 
       String item = e.Item.Cells[1].Text;
       String qty = qtyText.Text;
       String price = priceText.Text;
        
       DataRow dr;
 
       // With a database, use an update command to update the data. Because 
       // the data source in this example is an in-memory DataTable, delete the 
       // old row and replace it with a new one.

       // Remove old entry.
       CartView.RowFilter = "Item='" + item + "'";
       if (CartView.Count > 0)
          CartView.Delete(0);
       CartView.RowFilter = "";
 
       // Add new entry.
       dr = Cart.NewRow();
       dr[0] = qty;
       dr[1] = item;
       dr[2] = price;
       Cart.Rows.Add(dr);
 
       MyDataGrid.EditItemIndex = -1;
       BindGrid();
    }
 
    void BindGrid() 
    {
       MyDataGrid.DataSource = CartView;
       MyDataGrid.DataBind();
    }
 
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
