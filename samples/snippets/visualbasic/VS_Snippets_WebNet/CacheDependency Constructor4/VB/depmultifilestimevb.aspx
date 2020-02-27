<%@ Page language="VB" debug="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Public Sub Page_Load(sender As Object, e As EventArgs)
        If (Not IsNothing(Cache("key1"))) Then
            text1.InnerHtml = Cache("key1").ToString()
        Else
            text1.InnerHtml = "No value..."
' <Snippet1>
            ' Create a DateTime object that determines
            '  when dependency monitoring begins.
            Dim dt As DateTime = DateTime.Now

            ' Make key1 dependent on several files.
            Dim files(2) as String
            files(0) = Server.MapPath("isbn.xml")
            files(1) = Server.MapPath("customer.xml")
            Dim dependency as new CacheDependency(files, dt)

            Cache.Insert("key1", "Value 1", dependency)
        End If
' </Snippet1>
    End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Cache key dependency example:<br />
        Key 1: <b id="text1" runat="server"/><br />    
    </div>
    </form>
</body>
</html>

