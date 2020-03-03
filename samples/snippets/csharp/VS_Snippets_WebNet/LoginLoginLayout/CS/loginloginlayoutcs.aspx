<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="False"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    void changeOrientation_Click(object sender, EventArgs e) 
    {
        if (Login1.Orientation == Orientation.Vertical)
            Login1.Orientation = Orientation.Horizontal;
        else
            Login1.Orientation = Orientation.Vertical;
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <table style="text-align:center; border-width:1">
                <tr>
                    <td>
                        <asp:Login id="Login1" runat="server" Orientation="Vertical" CreateUserText="Create a new user..."
                            CreateUserUrl="newUser.aspx" HelpPageText="Help logging in..." HelpPageUrl="help.aspx"
                            PasswordRecoveryText="Recover your password..." PasswordRecoveryUrl="getPass.aspx"></asp:Login>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button id="changeOrientation" Text="Change Orientration" runat="Server" OnClick="changeOrientation_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
