<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language="C#" runat="server">
 
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

       void Button_Click(Object sender, EventArgs e) 
      {
       
         DataGridColumn[] myArray = new DataGridColumn[3];

         ItemsGrid.Columns.CopyTo(myArray, 0);

         Label1.Text = "The heading text for the items in the array are: <br /><br />";

         foreach (DataGridColumn column in myArray) 
         {
          
            Label1.Text += column.HeaderText + "<br />";
 
         }

      } 
   
   </script>
 
<head runat="server">
    <title>DataGridColumnCollection CopyTo Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>DataGridColumnCollection CopyTo Example</h3>
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="false"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>
 
         <Columns>
                  
            <asp:BoundColumn 
                 HeaderText="Item Number" 
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

      <asp:Button id="Button1"
           Text="Copy DataGridColumnsCollection to Array"
           OnClick="Button_Click"
           runat="server"/>

      <br />

      <asp:Label id="Label1"
           runat="server"/>    
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->
