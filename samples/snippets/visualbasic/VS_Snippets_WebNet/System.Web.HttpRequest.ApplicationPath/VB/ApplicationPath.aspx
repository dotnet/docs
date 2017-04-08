<%--<snippet2>--%>
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Label1.Text = Request.ApplicationPath
        Image1.ImageUrl = Request.ApplicationPath + "/images/Image1.gif"
        Label2.Text = Image1.ImageUrl
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HttpRequest.ApplicationPath Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ApplicationPath:<br />
        <asp:Label ID="Label1" runat="server" ForeColor="Brown" /><br />

        <asp:Image ID="Image1" runat="server" />

        ImageUrl:<br />
        <asp:Label ID="Label2" runat="server" ForeColor="Brown" />
        <br />
     </div>
    </form>
</body>
</html>
<%--</snippet2>--%>