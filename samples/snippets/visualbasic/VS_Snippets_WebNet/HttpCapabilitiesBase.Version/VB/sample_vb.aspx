<!-- <Snippet1> -->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        CheckBrowserCaps()
    End Sub

    Function CheckBrowserCaps()

        Dim labelText As String = ""
        Dim myBrowserCaps As System.Web.HttpBrowserCapabilities = Request.Browser
        If Double.Parse((CType(myBrowserCaps, System.Web.Configuration.HttpCapabilitiesBase)).Version, System.Globalization.CultureInfo.InvariantCulture) > 5.01 Then
            labelText = "Browser version is greater than 5.01."
        Else
            labelText = "Browser version is less than or equal to 5.01."
        End If

        Label1.Text = labelText

    End Function 'CheckBrowserCaps
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Browser Capabilities Sample</title>
</head>
<body>
    <form runat="server" id="form1">
        <div>
            Browser Capabilities:
            <p/><asp:Label ID="Label1" Runat="server" />
        </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->