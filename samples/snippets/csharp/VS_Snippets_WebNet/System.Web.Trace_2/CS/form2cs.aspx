<!-- <snippet1> -->
<%@ Page language="C#" trace="true" %>

<script runat="server">
private void page_load(object sender, EventArgs e) {
    
    Trace.Write("Trace Test","This message is written with the TraceContext object.");

    System.Diagnostics.Trace.WriteLine("This message is forwarded to the TraceContext from System.Diagnostics using the WebPageTraceListener.");
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>ASP.NET Example</title>
</head>
<body>
<form id="Form1" runat="server">

<asp:GridView 
  id="GridView1"
  runat="server"
  datasourceid="AccessDataSource1"/>

<asp:AccessDataSource 
  id="AccessDataSource1"
  runat="server"
  datafile="Northwind.mdb"
  selectcommand="SELECT * FROM employees"/>

</form>
</body>
</html>
<!-- </snippet1> -->