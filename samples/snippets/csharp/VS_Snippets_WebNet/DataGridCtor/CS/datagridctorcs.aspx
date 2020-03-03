<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
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
 
         // Populate the table with sample values.
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

         // Create a DataGrid control.
         DataGrid ItemsGrid = new DataGrid();

         // Set the properties of the DataGrid.
         ItemsGrid.ID = "ItemsGrid";
         ItemsGrid.BorderColor = System.Drawing.Color.Black;
         ItemsGrid.CellPadding = 3;
         ItemsGrid.AutoGenerateColumns = false;

         // Set the styles for the DataGrid.
         ItemsGrid.HeaderStyle.BackColor = 
             System.Drawing.Color.FromArgb(0x0000aaaa);

         // Create the columns for the DataGrid control. The DataGrid
         // columns are dynamically generated. Therefore, the columns   
         // must be re-created each time the page is refreshed.
         
         // Create and add the columns to the collection.
         ItemsGrid.Columns.Add(CreateBoundColumn("IntegerValue", "Item"));
         ItemsGrid.Columns.Add(
             CreateBoundColumn("StringValue", "Description"));
         ItemsGrid.Columns.Add(
             CreateBoundColumn("CurrencyValue", "Price", "{0:c}", 
             HorizontalAlign.Right));
         ItemsGrid.Columns.Add(
             CreateLinkColumn("http://www.microsoft.com", "_self", 
             "Microsoft", "Related link"));
        
         // Specify the data source and bind it to the control.
         ItemsGrid.DataSource = CreateDataSource();
         ItemsGrid.DataBind();

         // Add the DataGrid control to the Controls collection of 
         // the PlaceHolder control.
         Place.Controls.Add(ItemsGrid);

      }

      BoundColumn CreateBoundColumn(String DataFieldValue, 
          String HeaderTextValue)
      {

         // This version of the CreateBoundColumn method sets only the
         // DataField and HeaderText properties.

         // Create a BoundColumn.
         BoundColumn column = new BoundColumn();

         // Set the properties of the BoundColumn.
         column.DataField = DataFieldValue;
         column.HeaderText = HeaderTextValue;

         return column;

      }

      BoundColumn CreateBoundColumn(String DataFieldValue, 
          String HeaderTextValue, String FormatValue, 
          HorizontalAlign AlignValue)
      {

         // This version of CreateBoundColumn method sets the DataField,
         // HeaderText, and DataFormatString properties. It also sets the 
         // HorizontalAlign property of the ItemStyle property of the column. 

         // Create a BoundColumn using the overloaded CreateBoundColumn method.
         BoundColumn column = CreateBoundColumn(DataFieldValue, HeaderTextValue);

         // Set the properties of the BoundColumn.
         column.DataFormatString = FormatValue;
         column.ItemStyle.HorizontalAlign = AlignValue;

         return column;

      }

      HyperLinkColumn CreateLinkColumn(String NavUrlValue, 
          String TargetValue, String TextValue, String HeaderTextValue)
      {

         // Create a BoundColumn.
         HyperLinkColumn column = new HyperLinkColumn();

         // Set the properties of the ButtonColumn.
         column.NavigateUrl = NavUrlValue;
         column.Target = TargetValue;
         column.Text = TextValue;
         column.HeaderText = HeaderTextValue;

         return column;

      }

   </script>
 
<head runat="server">
    <title>DataGrid Constructor Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>DataGrid Constructor Example</h3>
 
      <b>Product List</b>

      <asp:PlaceHolder id="Place"
           runat="server"/>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->