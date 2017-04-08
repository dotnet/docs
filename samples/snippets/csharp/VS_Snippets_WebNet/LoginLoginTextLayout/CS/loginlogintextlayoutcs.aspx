<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="False" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

void changeOrientation_Click(object sender, EventArgs e)
{
    if (Login1.Orientation == Orientation.Vertical)
        Login1.Orientation = Orientation.Horizontal;
    else
        Login1.Orientation = Orientation.Vertical;
}

void changeTextLayout_Click(object sender, EventArgs e)
{
    if (Login1.TextLayout == LoginTextLayout.TextOnLeft)
        Login1.TextLayout = LoginTextLayout.TextOnTop;
    else
        Login1.TextLayout = LoginTextLayout.TextOnLeft;
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <table style="text-align:center; border:1">
                <tr>
                    <td align="center">
                        <asp:Login id="Login1" runat="server"
                            Orientation="Vertical" TextLayout="TextOnLeft">
                        </asp:Login>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button id="changeTextLayout" runat="Server" Text="Change Text Layout" onClick="changeTextLayout_Click" ></asp:Button>&nbsp;
                        <asp:Button id="changeOrientation" runat="server" Text="Change Orientation" onClick="changeOrientation_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
