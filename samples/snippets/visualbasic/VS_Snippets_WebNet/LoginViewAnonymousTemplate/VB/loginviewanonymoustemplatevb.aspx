<!-- <Snippet1> -->
<%@ Page Language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <table style="text-align:center; width:300px; background-color:#fffacd">
                <tr style="background-color:#dcdcdc">
                    <td>Personal content</td>
                    <td align="right">
                        <asp:LoginStatus id="LoginStatus1" runat="Server"></asp:LoginStatus>
                    </td>
                </tr>
                <asp:LoginView id="LoginView1" runat="server">
                    <AnonymousTemplate>
                        <tr>
                            <td colspan="2">
                                <a href="createUser.aspx">Sign up</a> to personalize your account.
                            </td>
                        </tr>
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        <tr>
                            <td>
                                <asp:LoginName id="LoginName1" runat="Server" 
                                    FormatString="Welcome {0}">
                                </asp:LoginName>
                            </td>
                            <td align="right">
                                <a href="manageAccount.aspx">Edit info...</a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                * Check e-mail * Add a link * Local weather *
                            </td>
                        </tr>
                    </LoggedInTemplate>
                </asp:LoginView>
            </table>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
