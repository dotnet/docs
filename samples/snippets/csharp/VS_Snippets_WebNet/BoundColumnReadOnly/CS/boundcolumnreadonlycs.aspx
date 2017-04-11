<!-- <Snippet1> -->

<%@ Page language="c#" AutoEventWireup="true" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>BoundColumn Example</title>
    </head>
    <script runat="server">
        // The Cart and CartView objects temporarily store the data source
        // for the DataGrid control while the page is being processed.
        DataTable Cart = new DataTable();
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

            // Retrieve the text boxes that contain the values to update.
            // For bound columns, the edited value is stored in a TextBox.
            // The TextBox is the 0th control in a cell's Controls collection.
            // Each cell in the Cells collection of a DataGrid item represents
            // a column in the DataGrid control.
            TextBox qtyText = (TextBox)e.Item.Cells[2].Controls[0];
            TextBox priceText = (TextBox)e.Item.Cells[3].Controls[0];
 
            // Retrieve the updated values.
            String item = e.Item.Cells[1].Text;
            String qty = qtyText.Text;
            String price = priceText.Text;
        
            DataRow dr;
 
            // With a database, use an update command to update the data. Because 
            // the data source in this example is an in-memory DataTable, delete  
            // the old row and replace it with a new one.
 
            // Remove the old entry and clear the row filter.
            CartView.RowFilter = "Item='" + item + "'";
            if (CartView.Count > 0)
            {
                CartView.Delete(0);
            }
            CartView.RowFilter = "";
 
            // Add the new entry.
            dr = Cart.NewRow();
            dr[0] = qty;
            dr[1] = item;
            dr[2] = price;
            Cart.Rows.Add(dr);
 
            // Set the EditItemIndex property to -1 to exit editing mode.  
            // Be sure to rebind the DateGrid to the data source to refresh
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

                // Create the sample data.
                DataRow dr;  
 
                // Define the columns of the table.
                Cart.Columns.Add(new DataColumn("Qty", typeof(String)));
                Cart.Columns.Add(new DataColumn("Item", typeof(String)));
                Cart.Columns.Add(new DataColumn("Price", typeof(String)));

                // Store the table in session state to persist its values 
                // between posts to the server.
                Session["ShoppingCart"] = Cart;
         
            
                // Populate the DataTable with sample data.
                // The generated table row data looks like this:
                //
                //   Qty   Item   Price
                //    1   Item 1   2.46
                //    2   Item 2   3.69
                //    1   Item 3   4.92
                //    2   Item 4   6.15

                for (int i = 1; i <= 4; i++) 
                {
                    dr = Cart.NewRow();
                    if (i % 2 != 0)
                    {
                        dr[0] = "2";
                    }
                    else
                    {
                        dr[0] = "1";
                    }
                    dr[1] = "Item " + i.ToString();
                    dr[2] = (1.23 * (i + 1)).ToString();
                    Cart.Rows.Add(dr);
                }
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
    </script>

    <body>
        <form runat="server" id="form1">
            <h3>BoundColumn ReadOnly Example</h3>

            <asp:DataGrid id="ItemsGrid"
                 BorderColor="black"
                 BorderWidth="1"
                 CellPadding="3"
                 OnEditCommand="ItemsGrid_Edit"
                 OnCancelCommand="ItemsGrid_Cancel"
                 OnUpdateCommand="ItemsGrid_Update"
                 AutoGenerateColumns="false"
                 runat="server">

                <HeaderStyle backcolor="#aaaadd"></HeaderStyle>

                <Columns>

                    <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" 
                         UpdateText="Update" HeaderText="Edit Command Column">
                        <ItemStyle Wrap="False"></ItemStyle>
                        <HeaderStyle wrap="false"></HeaderStyle>
                    </asp:EditCommandColumn>

                    <asp:BoundColumn HeaderText="Item" DataField="Item" 
                                     ReadOnly="True" />

                    <asp:BoundColumn HeaderText="Quantity" DataField="Qty" />

                    <asp:BoundColumn HeaderText="Price" DataField="Price" />
                </Columns>
            </asp:DataGrid>

        </form>
    </body>
</html>
<!-- </Snippet1> -->