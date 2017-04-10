<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>DataList Edit Example</title>
<script runat="server">

      // The Cart and CartView objects temporarily store the data source
      // for the DataList control while the page is being processed.
      DataTable Cart = new DataTable();
      DataView CartView;   
 
      void Page_Load(Object sender, EventArgs e) 
      {
 
         // With a database, use an select query to retrieve the data. 
         // Because the data source in this example is an in-memory
         // DataTable, retrieve the data from session state if it exists;
         // otherwise, create the data source.
         GetSource();

         // The DataList control maintains state between posts to the server;
         // it only needs to be bound to a data source the first time the
         // page is loaded or when the data source is updated.
         if (!IsPostBack)
         {

            BindList();

         }

         // Manually register the event-handling methods.
         ItemsList.EditCommand += 
             new DataListCommandEventHandler(this.Edit_Command);
         ItemsList.UpdateCommand += 
             new DataListCommandEventHandler(this.Update_Command);
         ItemsList.DeleteCommand += 
             new DataListCommandEventHandler(this.Delete_Command);
         ItemsList.CancelCommand += 
             new DataListCommandEventHandler(this.Cancel_Command);
                   
      }

      void BindList() 
      {

         // Set the data source and bind to the DataList control.
         ItemsList.DataSource = CartView;
         ItemsList.DataBind();

      }

      void GetSource()
      {

         // For this example, the data source is a DataTable that 
         // is stored in session state. If the data source does not exist,
         // create it; otherwise, load the data.
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

      void Edit_Command(Object sender, DataListCommandEventArgs e) 
      {

         // Set the EditItemIndex property to the index of the item clicked
         // in the DataList control to enable editing for that item. Be sure
         // to rebind the DataList to the data source to refresh the control.
         ItemsList.EditItemIndex = e.Item.ItemIndex;
         BindList();

      }

      void Cancel_Command(Object sender, DataListCommandEventArgs e) 
      {

         // Set the EditItemIndex property to -1 to exit editing mode. Be sure
         // to rebind the DataList to the data source to refresh the control.
         ItemsList.EditItemIndex = -1;
         BindList();

      }

      void Delete_Command(Object sender, DataListCommandEventArgs e) 
      { 

         // Retrieve the name of the item to remove.
         String item = ((Label)e.Item.FindControl("ItemLabel")).Text;

         // Filter the CartView for the selected item and remove it from
         // the data source.
         CartView.RowFilter = "Item='" + item + "'";
         if (CartView.Count > 0) 
         {
            CartView.Delete(0);
         }
         CartView.RowFilter = "";

         // Set the EditItemIndex property to -1 to exit editing mode. Be sure
         // to rebind the DataList to the data source to refresh the control.
         ItemsList.EditItemIndex = -1;
         BindList();

      }

      void Update_Command(Object sender, DataListCommandEventArgs e) 
      {

         // Retrieve the updated values from the selected item.
         String item = ((Label)e.Item.FindControl("ItemLabel")).Text;
         String qty = ((TextBox)e.Item.FindControl("QtyTextBox")).Text;
         String price = ((TextBox)e.Item.FindControl("PriceTextBox")).Text;

         // With a database, use an update command to update the data.
         // Because the data source in this example is an in-memory 
         // DataTable, delete the old row and replace it with a new one.

         // Filter the CartView for the selected item and remove it from
         // the data source.
         CartView.RowFilter = "Item='" + item + "'";
         if (CartView.Count > 0)
         {
            CartView.Delete(0);
         }
         CartView.RowFilter = "";

         // ***************************************************************
         // Insert data validation code here. Make sure to validate the
         // values entered by the user before converting to the appropriate
         // data types and updating the data source.
         // ***************************************************************

         // Add a new entry to replace the previous item.
         DataRow dr = Cart.NewRow();
         dr[0] = qty;
         dr[1] = item;
         // If necessary, remove the '$' character from the price before
         // converting the price to a Double.
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
         // Be sure to rebind the DataList to the data source to refresh
         // the control.
         ItemsList.EditItemIndex = -1;
         BindList();

      }

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