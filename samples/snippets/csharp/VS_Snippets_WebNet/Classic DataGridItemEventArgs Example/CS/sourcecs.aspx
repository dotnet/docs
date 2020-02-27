<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<script language="C#" runat="server">
 
   DataTable Cart;
   DataView CartView;
 
   ICollection CreateDataSource() 
   {
      DataTable dt = new DataTable();
      DataRow dr;
 
      dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
      dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
      dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
 
      for (int i = 0; i < 10; i++) 
      {
         dr = dt.NewRow();
 
         dr[0] = i;
         dr[1] = "Item " + i.ToString();
         dr[2] = 1.23 * (i+1);
 
         dt.Rows.Add(dr);
      }
 
      DataView dv = new DataView(dt);
      return dv;
   }
 
   void Page_Load(Object sender, EventArgs e) 
   {
 
      if (!IsPostBack) 
      {
         // Need to load this data only once.
         ItemsGrid.DataSource = CreateDataSource();
         ItemsGrid.DataBind();
      }
 
   }
 
   void Item_Created(Object sender, DataGridItemEventArgs e) 
   {
 
      Label1.Text = Label1.Text + " " + e.Item.ItemIndex;
 
   }
 
</script>
 
<head runat="server">
    <title>DataGridItemEventArgs Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataGridItemEventArgs Example</h3>
 
      <asp:DataGrid id="ItemsGrid" runat="server"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowFooter="true"
           OnItemCreated="Item_Created"
           AutoGenerateColumns="true">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>
   
      </asp:DataGrid>
 
      <br />
 
      <asp:Label id="Label1" 
           Text="Order of items created: " 
           runat="server"/>

      <br />

      <asp:Label id="Label2" 
           Text="Note: The -1's refer to the header and footer." 
           runat="server"/>
 
   </form>
 
</body>
</html>
   
<!--</Snippet1>-->
