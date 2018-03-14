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
 
         // Define columns for the data source.
         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
         dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
 
         // Populate data source with sample values.
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
 
         // Bind data to the DataGrid control only when the page first loads.
         if (!IsPostBack) 
         {
            ItemsGrid.DataSource= CreateDataSource();
            ItemsGrid.DataBind();
         }

         // Create a Label control to display the total number of items 
         // displayed in the DataGrid.
         Label myLabel = new Label();
         myLabel.Text = "<br /><br /><b>Total Number of Items: " + ItemsGrid.Items.Count.ToString() + "</b>";
         myLabel.ID = "SummaryLabel";

         // Add the Label control to the Controls collection of the DataGrid.
         ItemsGrid.Controls.Add(myLabel);

      }

   </script>
 
<head runat="server">
    <title>BaseDataList Controls Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>BaseDataList Controls Example</h3>
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="True"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>
 
      </asp:DataGrid>

   </form>
 
</body>
</html>

<!-- </Snippet1> -->