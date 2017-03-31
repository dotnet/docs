<!-- <snippet1> -->
<%@ Page language="VB" trace="true" %>

<script runat="server">
Private Sub Page_Load(sender As Object, e As EventArgs)
    
    Trace.Write("Trace Test","This message is written with the System.Web.TraceContext object.")

    System.Diagnostics.Trace.Write("Trace Test", "This message is forwarded to the TraceContext from System.Diagnostics using the WebPageTraceListener.")

End Sub ' Page_Load
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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