<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim MyCookie As New HttpCookie("TestCookieVB")
        ' <Snippet2>
        MyCookie.Expires = DateTime.Now.AddMinutes(10.0)
        ' </Snippet2>
        Response.Cookies.Add(MyCookie)
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HttpCookie.Expires Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Setting cookie expiration. 
    </div>
    </form>
</body>
</html>
