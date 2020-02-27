<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie MyCookie = new HttpCookie("TestCookieCS");
        // <Snippet2>
        MyCookie.Expires = DateTime.Now.AddMinutes(10.0);
        // </Snippet2>
        Response.Cookies.Add(MyCookie);
    }
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
