<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html  >
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

   </script>

<head id="Head1" runat="server">
    <title>DataGrid Example</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>DataGrid Example</h3>

      <b>Product List</b>

      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="true"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle> 

      </asp:DataGrid>

   </form>

</body>
</html>