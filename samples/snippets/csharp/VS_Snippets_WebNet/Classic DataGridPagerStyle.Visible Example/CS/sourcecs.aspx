<!--<Snippet1>-->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    ICollection CreateDataSource() 
    {
        DataTable dt = new DataTable();
        DataRow dr;
 
        dt.Columns.Add(new 
            DataColumn("IntegerValue", typeof(Int32)));
        dt.Columns.Add(new 
            DataColumn("StringValue", typeof(string)));
        dt.Columns.Add(new 
            DataColumn("DateTimeValue", typeof(string)));
        dt.Columns.Add(new 
            DataColumn("BoolValue", typeof(bool)));

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
            MyDataGrid.PagerStyle.Visible = true;
        else 
            MyDataGrid.PagerStyle.Visible = false;
 
        BindGrid();
    }

    void MyDataGrid_Page(Object sender, 
        DataGridPageChangedEventArgs e) 
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
        lblEnabled.Text = "AllowPaging is " + 
            MyDataGrid.AllowPaging;
        lblCurrentIndex.Text = "CurrentPageIndex is " + 
            MyDataGrid.CurrentPageIndex;
        lblPageCount.Text = "PageCount is " + 
            MyDataGrid.PageCount;
        lblPageSize.Text = "PageSize is " + 
            MyDataGrid.PageSize;
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Paging with DataGrid</title>
</head>
<body>
   <form id="form1" runat="server">
   <div>

   <h3>Paging with DataGrid</h3>

   <asp:DataGrid id="MyDataGrid" runat="server"
       AllowPaging="True"
       PageSize="10"
       PagerStyle-Mode="NumericPages"
       PagerStyle-HorizontalAlign="Right"
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
 
   <p>
       <asp:Checkbox id="chk1" runat="server"
           Text="Show pager"
           Font-Names="Verdana"
           Font-Size="8pt"
           AutoPostBack="true"/>
   </p>

   <table style="background-color: #eeeeee" cellpadding="6">
       <tr>
           <td style="white-space: nowrap">
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

   </div>
   </form>
</body>
</html>
<!--</Snippet1>-->
