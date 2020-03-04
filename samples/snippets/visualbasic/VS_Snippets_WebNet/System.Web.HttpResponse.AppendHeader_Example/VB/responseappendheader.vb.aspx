<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Private Sub Page_Load(sender As Object, e As EventArgs)

' <snippet1>
        Response.AppendHeader("CustomAspNetHeader", "Value1")
' </snippet1>
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
   <form id="form1" runat="server">
   </form>
 </body>
</html>