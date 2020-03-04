<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="False" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
        Sub changeText_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Login1.CreateUserText = Server.HtmlEncode(createText.Text)
    End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <table>
                <tr>
                    <td>
                        Create User Text:
                    </td>
                    <td>
                        <asp:TextBox id="createText" runat="server" Text="Create user..." />
                    </td>
                    <td>
                        <asp:Button id="changeText" runat="server" Text="Change Text" OnClick="changeText_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Login id="Login1" runat="server" 
                            CreateUserText="Register new user..." 
                            CreateUserUrl="register.aspx">
                        </asp:Login>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>
<!-- </Snippet1> -->