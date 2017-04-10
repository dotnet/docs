<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Password Recovery All Templates Sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div title="All Templates Sample">
      <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
<%--<Snippet3>--%>
        <QuestionTemplate>
          <table border="0" cellpadding="1">
            <tr>
              <td>
                <table border="0" cellpadding="0">
                  <tr>
                    <td align="center" colspan="2">
                      Identity Confirmation</td>
                  </tr>
                  <tr>
                    <td align="center" colspan="2">
                      Answer the following question to receive your password.</td>
                  </tr>
                  <tr>
                    <td align="right">
                      User Name:</td>
                    <td>
                      <asp:Literal ID="UserName" runat="server"></asp:Literal>
                    </td>
                  </tr>
                  <tr>
                    <td align="right">
                      Question:</td>
                    <td>
                      <asp:Literal ID="Question" runat="server"></asp:Literal>
                    </td>
                  </tr>
                  <tr>
                    <td align="right">
                      <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Answer:</asp:Label></td>
                    <td>
                      <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                        ErrorMessage="Answer is required." ToolTip="Answer is required." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                    </td>
                  </tr>
                  <tr>
                    <td align="center" colspan="2" style="color: red">
                      <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </td>
                  </tr>
                  <tr>
                    <td align="right" colspan="2">
                      <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Submit" ValidationGroup="PasswordRecovery1" />
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </QuestionTemplate>
<%--</Snippet3>--%>
<%--<Snippet2>--%>
        <UserNameTemplate>
          <table border="0" cellpadding="1">
            <tr>
              <td>
                <table border="0" cellpadding="0">
                  <tr>
                    <td align="center" colspan="2">
                      Forgot Your Password?</td>
                  </tr>
                  <tr>
                    <td align="center" colspan="2">
                      Enter your User Name to receive your password.</td>
                  </tr>
                  <tr>
                    <td align="right">
                      <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label></td>
                    <td>
                      <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                    </td>
                  </tr>
                  <tr>
                    <td align="center" colspan="2" style="color: red">
                      <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </td>
                  </tr>
                  <tr>
                    <td align="right" colspan="2">
                      <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Submit" ValidationGroup="PasswordRecovery1" />
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </UserNameTemplate>
<%--</Snippet2>--%>
        <SuccessTemplate>
          <table border="0" cellpadding="1">
            <tr>
              <td>
                <table border="0" cellpadding="0">
                  <tr>
                    <td>
                      Your password has been sent to you.</td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </SuccessTemplate>
      </asp:PasswordRecovery>
    
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->