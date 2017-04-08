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
         dt.Columns.Add(new DataColumn("StringValue", typeof(String)));
         dt.Columns.Add(new DataColumn("CurrencyValue", typeof(Double)));
 
         // Populate the table with sample values.
         for (int i=0; i<=10; i++) 
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
 
         // Manually register the event-handling method for the  
         // ItemDataBound event of the DataGrid control.
         ItemsGrid.ItemDataBound += 
             new DataGridItemEventHandler(this.Item_Bound);

         // Load sample data only once, when the page is first loaded.
         if (!IsPostBack)
         { 
         
            ItemsGrid.DataSource = CreateDataSource();
            ItemsGrid.DataBind();
         
         }

      }
 
      void Item_Bound(Object sender, DataGridItemEventArgs e) 
      {
 
         // Use the ItemDataBound event to customize the DataGrid control. 
         // The ItemDataBound event allows you to access the data before 
         // the item is displayed in the control. In this example, the 
         // ItemDataBound event is used to format the items in the 
         // CurrencyColumn in currency format.
         if((e.Item.ItemType == ListItemType.Item) ||
             (e.Item.ItemType == ListItemType.AlternatingItem))
         {
 
            // Retrieve the text of the CurrencyColumn from the DataGridItem
            // and convert the value to a Double.
            Double Price = Convert.ToDouble(e.Item.Cells[2].Text);

            // Format the value as currency and redisplay it in the DataGrid.
            e.Item.Cells[2].Text = Price.ToString("c");
        
         }         
 
      }
 
</script>
 
<head runat="server">
    <title>DataGrid ItemDataBound Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataGrid ItemDataBound Example</h3>
 
      <asp:DataGrid id="ItemsGrid" runat="server"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowFooter="true">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>
   
      </asp:DataGrid>

   </form>
 
</body>
</html>

<!-- </Snippet1> -->