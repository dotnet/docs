<!-- <Snippet6> -->
<%@ Page Language="C#" Trace="true"%>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.Controls.CS" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<script runat="server">
 
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
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            simpleDataBoundColumn1.DataSource = CreateDataSource();
            simpleDataBoundColumn1.DataBind();
        }
    }
</script>

<head runat="server">
    <title>SimpleDataBoundColumn test page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <aspSample:SimpleDataBoundColumn runat="server" id="simpleDataBoundColumn1" DataTextField="CurrencyValue" BorderStyle="Solid"></aspSample:SimpleDataBoundColumn>
    </div>
    </form>
</body>
</html>
<!-- </Snippet6> -->