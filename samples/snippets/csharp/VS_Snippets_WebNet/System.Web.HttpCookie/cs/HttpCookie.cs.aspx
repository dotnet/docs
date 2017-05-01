<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        // Get cookie from the current request.
        HttpCookie cookie = Request.Cookies.Get("DateCookieExample");
        
        // Check if cookie exists in the current request.
        if (cookie == null)
        {
            sb.Append("Cookie was not received from the client. ");
            sb.Append("Creating cookie to add to the response. <br/>");
            // Create cookie.
            cookie = new HttpCookie("DateCookieExample");
            // Set value of cookie to current date time.
            cookie.Value = DateTime.Now.ToString();
            // Set cookie to expire in 10 minutes.
            cookie.Expires = DateTime.Now.AddMinutes(10d);
            // Insert the cookie in the current HttpResponse.
            Response.Cookies.Add(cookie);
        }
        else
        {
            sb.Append("Cookie retrieved from client. <br/>");
            sb.Append("Cookie Name: " + cookie.Name + "<br/>");
            sb.Append("Cookie Value: " + cookie.Value + "<br/>");
            sb.Append("Cookie Expiration Date: " + 
                cookie.Expires.ToString() + "<br/>");
        }
        Label1.Text = sb.ToString();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HttpCookie Example</title>
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