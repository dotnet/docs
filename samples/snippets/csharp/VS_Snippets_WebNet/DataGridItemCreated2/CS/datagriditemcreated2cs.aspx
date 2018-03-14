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
 
         // Manually register the event-handling method for the ItemCreated  
         // event of the DataGrid control.
         ItemsGrid.ItemCreated += 
             new DataGridItemEventHandler(this.Item_Created);

         // Load sample data only once, when the page is first loaded.
         if (!IsPostBack)
         { 
         
            ItemsGrid.DataSource = CreateDataSource();
            ItemsGrid.DataBind();
         
         }

      }
 
      void Item_Created(Object sender, DataGridItemEventArgs e) 
      {
 
         // Customize the footer section with an image.
         if(e.Item.ItemType == ListItemType.Footer)
         {         
 
           // Create an Image control.
           System.Web.UI.WebControls.Image NewImageControl = new System.Web.UI.WebControls.Image();

           // Set the properties of the Image control.
           NewImageControl.ImageUrl = "Image1.jpg"; 
           NewImageControl.AlternateText = "Image 1";

           // Add the Image control to the Controls collection of the 
           // cell representing the third column in the DataGrid.
           e.Item.Cells[2].Controls.Add(NewImageControl);

         }         
 
      }
 
</script>
 
<head runat="server">
    <title>DataGrid ItemCreated Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataGrid ItemCreated Example</h3>
 
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