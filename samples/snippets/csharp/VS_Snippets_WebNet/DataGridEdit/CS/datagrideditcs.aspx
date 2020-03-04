<!--<Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      // The Cart and CartView objects temporarily store the data source
      // for the DataGrid control while the page is being processed.
      DataTable Cart = new DataTable();
      DataView CartView;   
 
      void Page_Load(Object sender, EventArgs e) 
      {
 
         // With a database, use an select query to retrieve the data. Because 
         // the data source in this example is an in-memory DataTable, retrieve
         // the data from session state if it exists; otherwise, create the data
         // source.
         GetSource();

         // The DataGrid control maintains state between posts to the server;
         // it only needs to be bound to a data source the first time the page
         // is loaded or when the data source is updated.
         if (!IsPostBack)
         {

            BindGrid();

         }
                   
      }
 
      void ItemsGrid_Edit(Object sender, DataGridCommandEventArgs e) 
      {

         // Set the EditItemIndex property to the index of the item clicked 
         // in the DataGrid control to enable editing for that item. Be sure
         // to rebind the DateGrid to the data source to refresh the control.
         ItemsGrid.EditItemIndex = e.Item.ItemIndex;
         BindGrid();

      }
 
      void ItemsGrid_Cancel(Object sender, DataGridCommandEventArgs e) 
      {

         // Set the EditItemIndex property to -1 to exit editing mode. 
         // Be sure to rebind the DateGrid to the data source to refresh
         // the control.
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
         TextBox qtyText = (TextBox)e.Item.Cells[3].Controls[0];
         TextBox priceText = (TextBox)e.Item.Cells[4].Controls[0];
 
         // Retrieve the updated values.
         String item = e.Item.Cells[2].Text;
         String qty = qtyText.Text;
         String price = priceText.Text;
        
         DataRow dr;
 
         // With a database, use an update command to update the data. 
         // Because the data source in this example is an in-memory 
         // DataTable, delete the old row and replace it with a new one.
 
         // Remove the old entry and clear the row filter.
         CartView.RowFilter = "Item='" + item + "'";
         if (CartView.Count > 0)
         {
            CartView.Delete(0);
         }
         CartView.RowFilter = "";
 
         // ***************************************************************
         // Insert data validation code here. Be sure to validate the
         // values entered by the user before converting to the appropriate
         // data types and updating the data source.
         // ***************************************************************

         // Add the new entry.
         dr = Cart.NewRow();
         dr[0] = Convert.ToInt32(qty);
         dr[1] = item;

         // If necessary, remove the '$' character from the price before 
         // converting it to a Double.
         if(price[0] == '$')
         {
            dr[2] = Convert.ToDouble(price.Substring(1));
         }
         else
         {
            dr[2] = Convert.ToDouble(price);
         }

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

         // For this example, the data source is a DataTable that is stored
         // in session state. If the data source does not exist, create it;
         //  otherwise, load the data.
         if (Session["ShoppingCart"] == null) 
         {     

            // Create the sample data.
            DataRow dr;  
 
            // Define the columns of the table.
            Cart.Columns.Add(new DataColumn("Qty", typeof(Int32)));
            Cart.Columns.Add(new DataColumn("Item", typeof(String)));
            Cart.Columns.Add(new DataColumn("Price", typeof(Double)));

            // Store the table in session state to persist its values 
            // between posts to the server.
            Session["ShoppingCart"] = Cart;
             
            // Populate the DataTable with sample data.
            for (int i = 1; i <= 9; i++) 
            {
               dr = Cart.NewRow();
               if (i % 2 != 0)
               {
                  dr[0] = 2;
               }
               else
               {
                  dr[0] = 1;
               }
               dr[1] = "Item " + i.ToString();
               dr[2] = (1.23 * (i + 1));
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

      void ItemsGrid_Command(Object sender, DataGridCommandEventArgs e)
      {

         switch(((LinkButton)e.CommandSource).CommandName)
         {

            case "Delete":
               DeleteItem(e);
               break;

            // Add other cases here, if there are multiple ButtonColumns in 
            // the DataGrid control.

            default:
               // Do nothing.
               break;

         }

      }

      void DeleteItem(DataGridCommandEventArgs e)
      {

         // e.Item is the table row where the command is raised. For bound
         // columns, the value is stored in the Text property of a TableCell.
         TableCell itemCell = e.Item.Cells[2];
         string item = itemCell.Text;

         // Remove the selected item from the data source.         
         CartView.RowFilter = "Item='" + item + "'";
         if (CartView.Count > 0) 
         {     
            CartView.Delete(0);
         }
         CartView.RowFilter = "";

         // Rebind the data source to refresh the DataGrid control.
         BindGrid();

      }
 
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