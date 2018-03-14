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
 
   void Button_Click(Object sender, EventArgs e) 
   {
 
      foreach (DataGridItem item in ItemsGrid.Items)
      { 
         Label1.Text += "<br />" + item.Cells[0].Text + 
                        " " + item.Cells[1].Text + 
                        " " + item.Cells[2].Text;
      }
 
   }
 
</script>
 
<head runat="server">
    <title>DataGrid Items Collection Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataGrid Items Collection Example</h3>
 
      <asp:DataGrid id="ItemsGrid" runat="server"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowFooter="true"
           AutoGenerateColumns="true">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>
   
      </asp:DataGrid>
 
      <br />

      <asp:Button id="Button1"
           Text="Display Contents of Items Collection"
           OnClick="Button_Click"
           runat="server"/>

      <br />
 
      <asp:Label id="Label1" 
           runat="server"/>
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->
