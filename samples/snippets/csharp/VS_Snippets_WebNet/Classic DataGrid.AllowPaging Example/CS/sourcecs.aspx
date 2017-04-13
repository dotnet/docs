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
 
      for (int i = 0; i < 100; i++) 
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
 
      if (CheckBox1.Checked)
         ItemsGrid.PagerStyle.Mode = PagerMode.NumericPages;
      else
         ItemsGrid.PagerStyle.Mode = PagerMode.NextPrev;

   }
 
   void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
   {
 
      // Set CurrentPageIndex to the page the user clicked.
      ItemsGrid.CurrentPageIndex = e.NewPageIndex;

      // Rebind the data. 
      ItemsGrid.DataSource = CreateDataSource();
      ItemsGrid.DataBind();
      
   }
 
 
</script>
 
<head runat="server">
    <title>DataGrid Paging Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

   <h3>DataGrid Paging Example</h3>
 
   <asp:DataGrid id="ItemsGrid" runat="server"
        BorderColor="black"
        BorderWidth="1"
        CellPadding="3"
        AllowPaging="true"
        AutoGenerateColumns="false"        
        OnPageIndexChanged="Grid_Change">
 
      <HeaderStyle BackColor="#00aaaa">
      </HeaderStyle>
 
      <PagerStyle Mode="NextPrev">
      </PagerStyle> 

      <Columns>

         <asp:BoundColumn 
              HeaderText="Number" 
              DataField="IntegerValue"/>
 
        <asp:BoundColumn 
              HeaderText="Item" 
              DataField="StringValue"/>

         <asp:BoundColumn 
              HeaderText="Price" 
              DataField="CurrencyValue" 
              DataFormatString="{0:c}">
 
            <ItemStyle HorizontalAlign="right">
            </ItemStyle>
     
         </asp:BoundColumn>

      </Columns>

   </asp:DataGrid>

   <br />

   <asp:CheckBox id="CheckBox1" 
                 Text="Show page navigation"
                 AutoPostBack="true"
                 runat="server"/>
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->
