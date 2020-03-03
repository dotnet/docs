<!-- <Snippet1> -->
<%@ Page Language="VB" autoEventWireup="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
        Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            login1.DestinationPageUrl = _
                String.Format("terms.aspx?{0}", Request.QueryString.ToString())
        End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:Login id="Login1" runat="server" 
                DestinationPageUrl="terms.aspx">
            </asp:Login>
        </form>
    </body>
</html>
<!-- </Snippet1> -->