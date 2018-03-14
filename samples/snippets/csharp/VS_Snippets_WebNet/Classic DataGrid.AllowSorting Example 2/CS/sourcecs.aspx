<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <script language="C#" runat="server">
    
    string SortExpression;
 
    ICollection CreateDataSource() 
    {
       DataTable dt = new DataTable();
       DataRow dr;
       Random Rand_Num = new Random();
 
       dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
       dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
       dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
 
       for (int i = 0; i < 15; i++) 
       {
          dr = dt.NewRow();
 
          dr[0] = i;
          dr[1] = "Item " + i.ToString();
          dr[2] = 1.23 * Rand_Num.Next(1, 15);
 
          dt.Rows.Add(dr);
       }
 
       DataView dv = new DataView(dt);
       dv.Sort=SortExpression;
       return dv;
    }
 
    void Page_Load(Object sender, EventArgs e) 
    {
 
       if (!IsPostBack) 
       {
 
          if (SortExpression == "")
             SortExpression = "IntegerValue";      
          ItemsGrid.DataSource = CreateDataSource();
          ItemsGrid.DataBind();
       }
 
    }
 
    void Sort_Grid(Object sender, DataGridSortCommandEventArgs e) 
    {
       SortExpression = e.SortExpression.ToString();
       ItemsGrid.DataSource = CreateDataSource();
       ItemsGrid.DataBind();
    }
 
 </script>
 
 <head runat="server">
    <title>DataGrid Sorting Example</title>
</head>
<body>
 
    <form id="form1" runat="server">
 
       <h3>DataGrid Sorting Example</h3>
 
       <asp:DataGrid id="ItemsGrid" runat="server"
            BorderColor="black"
            BorderWidth="1"
            CellPadding="3"
            AllowSorting="true"
            OnSortCommand="Sort_Grid"
            HeaderStyle-BackColor="#00aaaa"
            AutoGenerateColumns="true"/>
 
    </form>
 
 </body>
 </html>

<!--</Snippet1>-->
