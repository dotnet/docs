<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language="c#" runat="server">
 
      ICollection CreateDataSource() 
      {
         DataTable dt = new DataTable();
         DataRow dr;
 
         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
         dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
 
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
         if (!IsPostBack) 
         {
            // Load this data only once.
            ItemsGrid.DataSource= CreateDataSource();
            ItemsGrid.DataBind();
         }
      }
 
      void Grid_CartCommand(Object sender, DataGridCommandEventArgs e) 
      {
         
         // e.Item is the table row where the command is raised.
         // For bound columns, the value is stored in the Text property of the TableCell.
         Label1.Text = "You selected: " + e.Item.Cells[0].Text + ".";        
 
      }
 
   </script>
 
<head runat="server">
    <title>ButtonColumn Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>ButtonColumn Example</h3>
 
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="false"
           OnItemCommand="Grid_CartCommand"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>
 
         <Columns>
 
            <asp:BoundColumn 
                 HeaderText="Item" 
                 DataField="StringValue"/>

            <asp:ButtonColumn 
                 HeaderText="Price" 
                 ButtonType="PushButton" 
                 DataTextField="CurrencyValue"
                 DataTextFormatString="{0:C}"
                 CommandName="AddToCart" /> 

         </Columns>

      </asp:DataGrid>

      <br /><br />

      <asp:Label id="Label1" runat="server"/>
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->
