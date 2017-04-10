<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If (Not String.IsNullOrEmpty(TextBox1.Text)) Then
            
            ' Access the HttpServerUtility methods through
            ' the intrinsic Server object.
            Label1.Text = "Welcome, " & _
                Server.HtmlEncode(TextBox1.Text) & _
                ".<br/> The url is " & _
                Server.UrlEncode(Request.Url.ToString())
        End If
        
        
        
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>HttpServerUtility Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Enter your name:<br />

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        <br />
        <asp:Label ID="Label1" runat="server"/>
        </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->