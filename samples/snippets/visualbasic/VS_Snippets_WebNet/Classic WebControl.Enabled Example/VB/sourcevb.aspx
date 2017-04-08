<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Sub SubmitBtn1_Click(ByVal sender As Object, ByVal e As EventArgs)
        TextBox1.Enabled = Not (TextBox1.Enabled)
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title>Enabled Property Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Enabled Property of a Web Control</h3>
            <p>
                <asp:TextBox id="TextBox1" BackColor="LightBlue" 
                    runat="server">Light Blue</asp:TextBox>
            </p>
            <p>
                <asp:TextBox id="TextBox2" BackColor="LightGreen" 
                    runat="server">Light Green</asp:TextBox>
            </p>
            <asp:Button id="SubmitBtn1" runat="server"
                Text="Click to disable or enable the light blue text box" 
                OnClick="SubmitBtn1_Click" />
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
