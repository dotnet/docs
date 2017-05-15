<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <script language="c#" runat="server">
 
    ICollection CreateDataSource() {
       DataTable dt = new DataTable();
       DataRow dr;
 
       dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
       dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
       dt.Columns.Add(new DataColumn("DateTimeValue", typeof(DateTime)));
       dt.Columns.Add(new DataColumn("BoolValue", typeof(bool)));
       dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
 
       for (int i = 0; i < 9; i++) {
          dr = dt.NewRow();
 
          dr[0] = i;
          dr[1] = "Item " + i.ToString();
          dr[2] = DateTime.Now;
          dr[3] = (i % 2 != 0) ? true : false;
          dr[4] = 1.23 * (i+1);
 
          dt.Rows.Add(dr);
       }
 
       DataView dv = new DataView(dt);
       return dv;
    }
 
    void Page_Load(Object sender, EventArgs e) {
       if (!IsPostBack) {
          RadioButtonList1.DataSource = CreateDataSource();
          RadioButtonList1.DataTextField="StringValue";
          RadioButtonList1.DataValueField="CurrencyValue";
          RadioButtonList1.DataBind();
       }
    }
 
    void Index_Changed(Object sender, EventArgs e) {
 
       Label1.Text = "You selected " + RadioButtonList1.SelectedItem.Text +
                     " with a value of $" + RadioButtonList1.SelectedItem.Value +
                     ".";
 
    }
 
 </script>
 
 <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
 
    <form id="form1" runat="server">
 
       <asp:RadioButtonList id="RadioButtonList1" 
            OnSelectedIndexChanged="Index_Changed"
            AutoPostBack="true"
            runat="server"/>
 
       <br />
 
       <asp:Label id="Label1" runat="server"/>
 
    </form>
 
 </body>
 </html>
    
<!--</Snippet1>-->
