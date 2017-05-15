<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim sb As New StringBuilder()
        ' Check to see if cookies exist in HTTP request.
        If (Request.Cookies("userName") Is Nothing AndAlso _
            Request.Cookies("lastVisit") Is Nothing) Then
            Response.Cookies("userName").Value = "user name"
            Response.Cookies("userName").Expires = DateTime.Now.AddMinutes(20D)

            Dim aCookie As HttpCookie
            aCookie = New HttpCookie("lastVisit")
            aCookie.Value = DateTime.Now.ToString()
            aCookie.Expires = DateTime.Now.AddMinutes(20D)
            Response.Cookies.Add(aCookie)
            sb.Append("Two cookies added to response. " & _
                "Refresh the page to read the cookies.")
        Else
            Dim cookies As HttpCookieCollection
            cookies = Request.Cookies
            For i As Integer = 0 To cookies.Count - 1
                sb.Append("Name: " & cookies(i).Name & "<br/>")
                sb.Append("Value: " & cookies(i).Value & "<br/>")
                sb.Append("Expires: " & cookies(i).Expires.ToString() & _
                          "<br/><br/>")
            Next

        End If
        Label1.Text = sb.ToString()
    End Sub
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