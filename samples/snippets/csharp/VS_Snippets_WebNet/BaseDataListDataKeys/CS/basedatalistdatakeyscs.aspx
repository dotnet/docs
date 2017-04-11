<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>BaseDataList DataKeys Example</title>
<script runat="server">

      ICollection CreateDataSource() 
      {
      
         // Create sample data for the DataGrid control.
         DataTable dt = new DataTable();
         DataRow dr;
 
         // Define the columns of the table.
         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
         dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));

         // Define the primary key for the table as the IntegerValue 
         // column (column 0). To do this, first create an array of 
         // DataColumns to represent the primary key. The primary key can
         // consist of multiple columns, but in this example, only
         // one column is used.
         DataColumn[] keys = new DataColumn[1];
         keys[0] = dt.Columns[0];

         // Then assign the array to the PrimaryKey property of the DataTable. 
         dt.PrimaryKey = keys;
 
         // Populate the table with sample values.
         for (int i = 0; i < 9; i++) 
         {
            dr = dt.NewRow();
 
            dr[0] = i;
            dr[1] = "Item " + i.ToString();
            dr[2] = 1.23 * (i + 1);
 
            dt.Rows.Add(dr);
         }

         // To persist the data source between posts to the server, 
         // store it in session state.  
         Session["Source"] = dt;
 
         DataView dv = new DataView(dt);
         return dv;

      }
 
      void Page_Load(Object sender, EventArgs e) 
      {
 
         // Load sample data only once, when the page is first loaded.
         if (!IsPostBack) 
         {
            ItemsGrid.DataSource = CreateDataSource();
            ItemsGrid.DataBind();
         }

      }

      void Delete_Command(Object sender, DataGridCommandEventArgs e)
      {

         // Retrieve the data table from session state.
         DataTable dt = (DataTable)Session["Source"];

         // Retrieve the data row to delete from the data table. 
         // Use the DataKeys property of the DataGrid control to get 
         // the primary key value of the selected row. 
         // Search the Rows collection of the data table for this value. 
         DataRow row;
         row = dt.Rows.Find(ItemsGrid.DataKeys[e.Item.ItemIndex]);

         // Delete the item selected in the DataGrid from the data source.
         if(row != null)
         {
            dt.Rows.Remove(row);
         }

         // Save the data source.
         Session["Source"] = dt;

         // Create a DataView and bind it to the DataGrid control.
         DataView dv = new DataView(dt);
         ItemsGrid.DataSource = dv;
         ItemsGrid.DataBind();

      }

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>BaseDataList DataKeys Example</h3>

      <asp:DataGrid id="ItemsGrid" 
           BorderColor="Black"
           ShowFooter="False" 
           CellPadding="3" 
           CellSpacing="0"
           HeaderStyle-BackColor="#aaaadd"
           DataKeyField="IntegerValue"
           OnDeleteCommand="Delete_Command"
           runat="server">

         <Columns>

            <asp:ButtonColumn Text="Delete"
                 CommandName="Delete"/>

         </Columns>

      </asp:DataGrid>

   </form>

</body>
</html>

<!-- </Snippet1> -->
