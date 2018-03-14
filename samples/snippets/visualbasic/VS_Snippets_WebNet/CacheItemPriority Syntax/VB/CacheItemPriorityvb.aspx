<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Public Sub Page_Load(sender As Object, e As EventArgs)
        Dim connectionString As String
        connectionString = "Data Source=localhost;Integrated Security=SSPI"
        Cache.Insert("DSN", connectionString, Nothing, DateTime.Now.AddMinutes(2), TimeSpan.Zero, CacheItemPriority.High, Nothing)
    End Sub
</script>
<!-- </Snippet1> -->
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
