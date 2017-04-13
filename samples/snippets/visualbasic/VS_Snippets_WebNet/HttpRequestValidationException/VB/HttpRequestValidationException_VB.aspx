<!--<snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Label1.Text = txt1.Text
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox id="txt1" Runat="server" />
        <asp:Button ID="Button1" Runat="server" Text="Button" OnClick="Button1_Click" />
        <br /><br />You entered: <asp:Label ID="Label1" Runat="server" Text="Label" />.
    </div>
    </form>
</body>
</html>
<!--</snippet1> -->
