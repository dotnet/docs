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
         dt.Columns.Add(new DataColumn("DateTimeValue", typeof(string)));
         dt.Columns.Add(new DataColumn("BoolValue", typeof(bool)));
 
         for (int i = 0; i < 100; i++) 
         {
            dr = dt.NewRow();
  
            dr[0] = i;
            dr[1] = "Item " + i.ToString();
            dr[2] = DateTime.Now.ToShortDateString();
            dr[3] = (i % 2 != 0) ? true : false;
 
            dt.Rows.Add(dr);
         }
 
         DataView dv = new DataView(dt);
         return dv;
      }
 
      void Page_Load(Object sender, EventArgs e) 
      {
         if (chk1.Checked)
            MyDataGrid.PagerStyle.Mode = PagerMode.NumericPages;
         else 
            MyDataGrid.PagerStyle.Mode = PagerMode.NextPrev;
 
         BindGrid();
      }
 
      void MyDataGrid_Page(Object sender, DataGridPageChangedEventArgs e) 
      {
         MyDataGrid.CurrentPageIndex = e.NewPageIndex;
         BindGrid();
      }
 
      void BindGrid() 
      {
         MyDataGrid.DataSource = CreateDataSource();
         MyDataGrid.DataBind();
         ShowStats();
      }
 
      void ShowStats() 
      {
         lblEnabled.Text = "AllowPaging is " + MyDataGrid.AllowPaging;
         lblCurrentIndex.Text = "CurrentPageIndex is " + MyDataGrid.CurrentPageIndex;
         lblPageCount.Text = "PageCount is " + MyDataGrid.PageCount;
         lblPageSize.Text = "PageSize is " + MyDataGrid.PageSize;
      }
 
 
   </script>
 
<head runat="server">
    <title>Paging with DataGrid</title>
</head>
<body>
 
   <h3>Paging with DataGrid</h3>
 
   <form id="form1" runat="server">
 
      <asp:DataGrid id="MyDataGrid" runat="server"
           AllowPaging="True"
           PageSize="10"
           PagerStyle-Mode="NumericPages"
           PagerStyle-HorizontalAlign="Right"
           PagerStyle-Position="Top"
           OnPageIndexChanged="MyDataGrid_Page"
           BorderColor="black"
           BorderWidth="1"
           GridLines="Both"
           CellPadding="3"
           CellSpacing="0"
           Font-Names="Verdana"
           Font-Size="8pt"
           HeaderStyle-BackColor="#aaaadd"
           AlternatingItemStyle-BackColor="#eeeeee"/>
 
      <br />
 
      <asp:Checkbox id="chk1" runat="server"
           Text="Show numeric page navigation buttons"
           Font-Names="Verdana"
           Font-Size="8pt"
           AutoPostBack="true"/>
 
      <br />
 
      <table style="background-color:#eeeeee; padding:6">
         <tr>
            <td style="display:inline">
               
 
                  <asp:Label id="lblEnabled" 
                       runat="server"/><br />
                  <asp:Label id="lblCurrentIndex" 
                       runat="server"/><br />
                  <asp:Label id="lblPageCount" 
                       runat="server"/><br />
                  <asp:Label id="lblPageSize" 
                       runat="server"/><br />
               
            </td>
         </tr>
      </table>

   </form>

</body>
</html>

<!--</Snippet1>-->
