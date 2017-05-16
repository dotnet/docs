<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sb As New StringBuilder()
        ' Get cookie from current request.
        Dim cookie As HttpCookie
        cookie = Request.Cookies.Get("DateCookieExample")
        
        ' Check if cookie exists in the current request
        If (cookie Is Nothing) Then
            sb.Append("Cookie was not received from the client. ")
            sb.Append("Creating cookie to add to the response. <br/>")
            ' Create cookie.
            cookie = New HttpCookie("DateCookieExample")
            ' Set value of cookie to current date time.
            cookie.Value = DateTime.Now.ToString()
            ' Set cookie to expire in 10 minutes.
            cookie.Expires = DateTime.Now.AddMinutes(10D)
            ' Insert the cookie in the current HttpResponse.
            Response.Cookies.Add(cookie)
        Else
            sb.Append("Cookie retrieved from client. <br/>")
            sb.Append("Cookie Name: " + cookie.Name + "<br/>")
            sb.Append("Cookie Value: " + cookie.Value + "<br/>")
            sb.Append("Cookie Expiration Date: " & _
                cookie.Expires.ToString() & "<br/>")
        End If
        Label1.Text = sb.ToString()

    End Sub
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