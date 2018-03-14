<!-- <Snippet1> -->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<form id="form1" runat="server">
    <asp:passwordrecovery id="PasswordRecovery1" runat="server">
        <questiontemplate>
            <table border="0">
                <tr>
                    <td align="Center" colspan="2">Identity Confirmation</td>
                </tr>
                <tr>
                    <td align="Center" colspan="2">Answer the following question to receive your password.</td>
                </tr>
                <tr>
                    <td align="Right">User Name:</td>
                    <td>
                        <asp:literal runat="server" id="UserName"></asp:literal>
                    </td>
                </tr>
                <tr>
                    <td align="Right">Question:</td>
                    <td>
                        <asp:literal runat="server" id="Question"></asp:literal>
                    </td>
                </tr>
                <tr>
                    <td align="Right">Answer:</td>
                    <td>
                        <asp:textbox runat="server" id="Answer"></asp:textbox>
                        <asp:requiredfieldvalidator runat="server" controltovalidate="Answer" errormessage="Answer." id="AnswerRequired">*</asp:requiredfieldvalidator>
                    </td>
                </tr>
                <tr>
                    <td align="Right" colspan="2">
                        <asp:button runat="server" commandname="Submit" text="Submit" id="Button"></asp:button>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="color:Red;">
                        <asp:literal runat="server" id="FailureText"></asp:literal>
                    </td>
                </tr>
            </table>
        </questiontemplate>
    </asp:passwordrecovery>

</form>
</body>
</html>
<!-- </Snippet1> -->
