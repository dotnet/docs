<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, _
        ByVal e As EventArgs)

        Dim txt As TextBox

        ' Find the server name on the previous page
        txt = CType(Page.PreviousPage.FindControl _
            ("serverNameText"), TextBox)
        If Not IsNothing(txt) Then
            prevServerName.Text = Server.HtmlEncode(txt.Text)
        Else
            prevServerName.Text = "[Name Not available]"
        End If
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Page A</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Database Server is Not Available</h2>

    <p>This page appears if the named database server is not 
    available, but the URL displays as the main target page.</p>
    
    <p>Server Name (From Page.PreviousPage): 
        <asp:Label ID="prevServerName" runat="server" /></p>
    
    <p>Refresh the page to see if the server is now available.</p>
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
