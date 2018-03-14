<!-- <snippet1> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
private void Page_Load(object sender, EventArgs e)
{
    DataGrid1.DataSource = GetProcessInfoAsDataSet();
    DataGrid1.DataBind();
}

private DataSet GetProcessInfoAsDataSet()
{
    DataSet ds = new DataSet();
    ds.Tables.Add(new DataTable());
    ds.Tables[0].Columns.Add("ID",         typeof(string));
    ds.Tables[0].Columns.Add("Start Time", typeof(string));
    ds.Tables[0].Columns.Add("Age",        typeof (string));
    ds.Tables[0].Columns.Add("Request Count", typeof(string));
    ds.Tables[0].Columns.Add("Peak Memory",typeof(string));

    ProcessInfo info = ProcessModelInfo.GetCurrentProcessInfo();

    DataRow row = ds.Tables[0].NewRow();
    row["ID"]         = info.ProcessID;
    row["Start Time"] = info.StartTime;
    row["Age"]        = info.Age;
    row["Request Count"] = info.RequestCount;
    row["Peak Memory"]= info.PeakMemoryUsed;

    ds.Tables[0].Rows.Add(row);

    return ds;
}     
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataGrid 
            ID="DataGrid1" 
            runat="server" />    
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->