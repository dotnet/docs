<%--<snippet1>--%>
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Label1.Text = Request.ApplicationPath
        Image1.ImageUrl = Request.ApplicationPath + "/images/Image1.gif"
        Label2.Text = Image1.ImageUrl
        
        Label3.Text = Request.AppRelativeCurrentExecutionFilePath
        If (VirtualPathUtility.GetDirectory( _
            Request.AppRelativeCurrentExecutionFilePath).Equals( _
            "~/Members/")) _
        Then
            Image2.ImageUrl = Request.ApplicationPath & _
                "/memberimages/Image1.gif"
        Else
            Image2.ImageUrl = Request.ApplicationPath & _
                "/guestimages/Image1.gif"
        End If
        Label4.Text = Image2.ImageUrl
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HttpRequest.ApplicationPath Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        This is the ApplicationPath from the current page:<br />
        <asp:Label ID="Label1" runat="server" ForeColor="Brown" /><br />
        Use it to link to resources at fixed locations in the application.<br />
        <asp:Image ID="Image1" runat="server" />
        <asp:Label ID="Label2" runat="server" ForeColor="Brown" />
        <br /><br />
        This is the AppRelativeCurrentExecutionFilePath to the current page:<br />
        <asp:Label ID="Label3" runat="server" ForeColor="Brown" /><br />
        Use it to help programatically construct links to resources based on the location of the current page.<br />
        <asp:Image ID="Image2" runat="server" />
        <asp:Label ID="Label4" runat="server" ForeColor="Brown" />
        </div>
    </form>
</body>
</html>
<%--</snippet1>--%>