<!-- <Snippet1> -->
<%@ Page Language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
void changeClick(object sender, EventArgs e)
{
    Login1.TitleText = newTitle.Text;
}

void OnLoginError(object sender, EventArgs e)
{
    Login1.TitleTextStyle.BackColor = System.Drawing.Color.Red;
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
                    <td>
                        Title Text:
                    </td>
                    <td>
                        <asp:TextBox id="newTitle" runat="server">Login</asp:TextBox></td>
                    <td>
                        <asp:Button id="change" runat="server" onClick="changeClick" Text="Change"></asp:Button></td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Login id="Login1" runat="server" 
                            TitleText="Log In Now"
                            OnLoginError="OnLoginError">
                            <TitleTextStyle 
                                Font-Bold="True" 
                                ForeColor="#0000C0" 
                                BackColor="#E0E0E0">
                        </TitleTextStyle>
                        </asp:Login>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
