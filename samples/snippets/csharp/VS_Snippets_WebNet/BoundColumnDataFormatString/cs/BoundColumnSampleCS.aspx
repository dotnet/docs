<!-- <Snippet1> -->

<%@ Page language="c#" AutoEventWireup="true" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Globalization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>BoundColumn Example</title>
    </head>
       <script runat="server">
        // The Cart and CartView objects temporarily store the data source
        // for the DataGrid control while the page is being processed.
        DataTable Cart;
        DataView CartView;   
 
        void Page_Load(Object sender, EventArgs e) 
        {
            // With a database, use a select query to retrieve the data. 
            // Because the data source in this example is an in-memory 
            // DataTable, retrieve the data from session state if it exists; 
            // otherwise, create the data source.
            GetSource();

            // The DataGrid control maintains state between posts to the 
            // server; therefore it only needs to be bound to a data source 
            // the first time the page is loaded or when the data source 
            // is updated.
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
 
        void ItemsGrid_Edit(Object sender, DataGridCommandEventArgs e) 
        {
            // Set the EditItemIndex property to the index of the item 
            // clicked in the DataGrid control to enable editing for that
            // item. Be sure to rebind the DateGrid to the data source 
            // to refresh the control.
            ItemsGrid.EditItemIndex = e.Item.ItemIndex;
            BindGrid();
        }
 
        void ItemsGrid_Cancel(Object sender, DataGridCommandEventArgs e) 
        {
            // Set the EditItemIndex property to -1 to exit editing mode.  
            // Be sure to rebind the DateGrid to the data source to 
            // refresh the control.
            ItemsGrid.EditItemIndex = -1;
            BindGrid();
        }
 
        void ItemsGrid_Update(Object sender, DataGridCommandEventArgs e) 
        {
            // Retrieve the updated values.
            // For bound columns, the edited value is stored in a TextBox.
            // The TextBox is the 0th control in a cell's Controls collection.
            // Each cell in the Cells collection of a DataGrid item represents
            // a column in the DataGrid control.
            DataGridItem updateItem = e.Item;

            TextBox qtyText = (TextBox)updateItem.Cells[2].Controls[0];
            TextBox priceText = (TextBox)updateItem.Cells[3].Controls[0];
            
            try {
                // Try to parse the updated values from the input text.
                Int32 newQty;
                Decimal newPrice;
            
                newQty = Int32.Parse(qtyText.Text, NumberStyles.Number);
                newPrice = Decimal.Parse(priceText.Text, NumberStyles.Currency);

                // Get the item cell value - "Item 1", "Item 2", etc.
                // For read-only columns, the value is stored in the cell text.
                String item = updateItem.Cells[1].Text;
       
                // With a database, use an update command to update the data. 
                // Because the data source in this example is an in-memory
                // DataTable, delete the old row and replace it with a new one.
    
                // Filter on the updated item, remove it,
                // then clear the row filter.
                CartView.RowFilter = "Item='" + item + "'";
                if (CartView.Count > 0)
                {
                    CartView.Delete(0);
                }
                CartView.RowFilter = "";
 
                // Add the updated entry for the item.
                DataRow dr = Cart.NewRow();
                dr["Item"] = item;
                dr["Qty"] = newQty;
                dr["Price"] = newPrice;
                dr["Weight"] = updateItem.Cells[4].Text;
                dr["Expires"] = updateItem.Cells[5].Text;
            
                Cart.Rows.Add(dr);
            }
            catch (System.FormatException)
            {
                // If parsing the price or quantity caused an 
                // exception, then leave edit mode without
                // changing any cell values.
            }

            // Set the EditItemIndex property to -1 to exit editing mode.  
            // Be sure to rebind the DataGrid to the data source to refresh
            // the control.
            ItemsGrid.EditItemIndex = -1;
            BindGrid();
        }
 
        void BindGrid() 
        {
            // Set the data source and bind to the Data Grid control.
            ItemsGrid.DataSource = CartView;
            ItemsGrid.DataBind();
        }

        void GetSource()
        {
            // For this example, the data source is a DataTable that is 
            // stored in session state.
            // If the data source does not exist, create it; otherwise, 
            // load the data.
            
            if (Session["ShoppingCart"] == null) 
            {     
                Cart = new DataTable();
                InitSource();
            } 
            else
            {
                // Retrieve the sample data from session state.
                Cart = (DataTable)Session["ShoppingCart"];
            }         
 
            // Create a DataView and specify the field to sort by.
            CartView = new DataView(Cart);
            CartView.Sort="Item";

            return;
        }
        
        void InitSource()
        {
            // Create the sample data.
 
            // Define the columns of the table.
            Cart.Columns.Add(new DataColumn("Qty", typeof(Int32)));
            Cart.Columns.Add(new DataColumn("Item", typeof(String)));
            Cart.Columns.Add(new DataColumn("Price", typeof(Decimal)));
            Cart.Columns.Add(new DataColumn("Weight", typeof(Decimal)));
            Cart.Columns.Add(new DataColumn("Expires", typeof(DateTime)));

            // Store the table in session state to persist its values 
            // between posts to the server.
            Session["ShoppingCart"] = Cart;
            
            // Populate the DataTable with sample data.
            DataRow dr;  

            for (int i = 1; i <= 4; i++) 
            {
                dr = Cart.NewRow();
                dr["Qty"] = i % 2 + 1;
                dr["Item"] = "Item " + i.ToString();
                dr["Price"] = (0.50 * (i + 1));
                dr["Weight"] = 5.0;
                dr["Expires"] = DateTime.Now + TimeSpan.FromDays(7);
                Cart.Rows.Add(dr);
            }
        }
        </script>
    <body>
        <form runat="server" id="form1">
            <h3>BoundColumn DataFormatString Example</h3>
            <asp:DataGrid id="ItemsGrid" 
                BorderColor="black" BorderWidth="1" CellPadding="3"
                OnEditCommand="ItemsGrid_Edit" OnCancelCommand="ItemsGrid_Cancel" 
                OnUpdateCommand="ItemsGrid_Update" AutoGenerateColumns="false"
                runat="server" >

                <HeaderStyle backcolor="#aaaadd"></HeaderStyle>

                <Columns>
                    <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" 
                         UpdateText="Update" HeaderText="Edit Command Column">
                        <ItemStyle Wrap="False"></ItemStyle>
                        <HeaderStyle wrap="false"></HeaderStyle>
                    </asp:EditCommandColumn>

                    <asp:BoundColumn HeaderText="Item" DataField="Item" 
                                     ReadOnly="True" />

                    <asp:BoundColumn HeaderText="Quantity" DataField="Qty" 
                                     DataFormatString="{0:N0}"/>

                    <asp:BoundColumn HeaderText="Price" DataField="Price"
                                     DataFormatString="{0:c}" />

                    <asp:BoundColumn HeaderText="Weight" DataField="Weight" 
                                     ReadOnly="True" DataFormatString="{0:F3}" />

                    <asp:BoundColumn HeaderText="Expires" DataField="Expires" 
                                     ReadOnly="True" DataFormatString="{0:g}" />

                </Columns>
            </asp:DataGrid>
        </form>
    </body>
</html>
<!-- </Snippet1> -->