<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        // Check to see if cookies exist in HTTP request.
        if (Request.Cookies["userName"] == null && 
            Request.Cookies["lastVist"] == null)
        {
            Response.Cookies["userName"].Value = "user name";
            Response.Cookies["userName"].Expires = DateTime.Now.AddMinutes(20d);

            HttpCookie aCookie = new HttpCookie("lastVisit");
            aCookie.Value = DateTime.Now.ToString();
            aCookie.Expires = DateTime.Now.AddMinutes(20d);
            Response.Cookies.Add(aCookie);
            sb.Append("Two cookies added to response. " + 
                "Refresh the page to read the cookies.");
        }
        else
        {
            HttpCookieCollection cookies = Request.Cookies;
            for (int i = 0; i < cookies.Count; i++)
            {
                sb.Append("Name: " + cookies[i].Name + "<br/>");
                sb.Append("Value: " + cookies[i].Value + "<br/>");
                sb.Append("Expires: " + cookies[i].Expires.ToString() +
                          "<br/><br/>");
            }
        }
        Label1.Text = sb.ToString();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HttpCookieCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label id="Label1" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
