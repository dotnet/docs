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
 
         // Load sample data only once when the page is first loaded.
         if (!IsPostBack) 
         {
            ItemsGrid.DataSource = CreateDataSource();
            ItemsGrid.DataBind();
         }

      }

      void Index_Change(Object sender, EventArgs e) 
      {

         ItemsGrid.GridLines = (GridLines)GridLinesList.SelectedIndex;

      }
 
   </script>
 
<head runat="server">
    <title>BaseDataList GridLines Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>BaseDataList GridLines Example</h3>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           GridLines="Both"
           AutoGenerateColumns="true"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle> 
 
      </asp:DataGrid>

      <br />

      <h4>Select the gridline style:</h4>

            <table cellpadding="5">

         <tr>

            <td>

               Gridline style:

            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="GridLinesList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Index_Change"
                    runat="server">

                  <asp:ListItem Value="0">None</asp:ListItem>
                  <asp:ListItem Value="1">Horizontal</asp:ListItem>
                  <asp:ListItem Value="2">Vertical</asp:ListItem>
                  <asp:ListItem Value="3" Selected="True">Both</asp:ListItem>

               </asp:DropDownList>

            </td>

         </tr>

      </table>
      
   </form>
 
</body>
</html>

<!-- </Snippet1> -->
