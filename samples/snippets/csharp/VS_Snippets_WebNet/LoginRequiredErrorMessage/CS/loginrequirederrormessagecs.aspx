<!-- <Snippet1> -->
<%@ Page Language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
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
                        <asp:Login id="Login1" runat="server" 
                            PasswordRequiredErrorMessage="You must enter a password."
                            UserNameRequiredErrorMessage="You must enter a user name.">
                        </asp:Login>
                    </td>
                    <td>
                        <asp:ValidationSummary id="ValidationSummary1" 
                            runat="server" ValidationGroup="Login1" >
                        </asp:ValidationSummary>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
