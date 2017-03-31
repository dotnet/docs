<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="False" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Sub changeOrientation_Click(ByVal sender As Object, ByVal e As EventArgs)
    If Login1.Orientation = Orientation.Vertical Then
        Login1.Orientation = Orientation.Horizontal
    Else
        Login1.Orientation = Orientation.Vertical
    End If
End Sub

Sub changeTextLayout_Click(ByVal sender As Object, ByVal e As EventArgs)
    If Login1.TextLayout = LoginTextLayout.TextOnLeft Then
        Login1.TextLayout = LoginTextLayout.TextOnTop
    Else
        Login1.TextLayout = LoginTextLayout.TextOnLeft
    End If
End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <table style="text-align:center; border-width:1">
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
