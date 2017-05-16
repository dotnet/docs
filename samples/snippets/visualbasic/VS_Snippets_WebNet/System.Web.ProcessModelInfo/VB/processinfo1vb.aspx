<!-- <snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
Sub Page_Load(sender As Object, e As EventArgs)
    DataGrid1.DataSource = GetProcessInfoAsDataSet()
    DataGrid1.DataBind()
End Sub

Function GetProcessInfoAsDataSet() As DataSet
    Dim ds As New DataSet
    Dim dt As New DataTable
    ds.Tables.Add(dt)
    ds.Tables(0).Columns.Add("ID", GetType(String))
    ds.Tables(0).Columns.Add("Start Time", GetType(String))
    ds.Tables(0).Columns.Add("Age", GetType(String))
    ds.Tables(0).Columns.Add("Request Count", GetType(String))
    ds.Tables(0).Columns.Add("Peak Memory", GetType(String))

    Dim info As ProcessInfo 
    info = ProcessModelInfo.GetCurrentProcessInfo()

    Dim row As DataRow 
    row = ds.Tables(0).NewRow()
    
    row("ID")         = info.ProcessID
    row("Start Time") = info.StartTime
    row("Age")        = info.Age
    row("Request Count") = info.RequestCount
    row("Peak Memory")= info.PeakMemoryUsed

    ds.Tables(0).Rows.Add(row)
    Return ds
End Function
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