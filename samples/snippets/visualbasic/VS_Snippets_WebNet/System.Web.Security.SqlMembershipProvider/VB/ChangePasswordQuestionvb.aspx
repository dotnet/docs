<!-- <Snippet10> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub ChangePasswordQuestion_OnClick(sender As Object, args As EventArgs)

  Try
    If Membership.Provider.ChangePasswordQuestionAndAnswer(User.Identity.Name, _
                                                          PasswordTextbox.Text, _ 
                                                          QuestionTextbox.Text, _
                                                          AnswerTextbox.Text) Then
      Msg.Text = "Password question and answer changed."
    Else
      Msg.Text = "Change failed. Please reenter your values and try again."
    End If
  Catch e As System.Configuration.Provider.ProviderException
    Msg.Text = "Change failed. Please reenter your values and try again."
  End Try

End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Change Password Question and Answer</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Change Password Question and Answer for <%=User.Identity.Name%></h3>

  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />

  <table cellpadding="3" border="0">
    <tr>
      <td>Password:</td>
      <td><asp:Textbox id="PasswordTextbox" runat="server" TextMode="Password" /></td>
      <td><asp:RequiredFieldValidator id="OldPasswordRequiredValidator" runat="server"
                                    ControlToValidate="PasswordTextbox" ForeColor="red"
                                    Display="Static" ErrorMessage="Required" /></td>
    </tr>
    <tr>
      <td>New Password Question:</td>
      <td><asp:Textbox id="QuestionTextbox" MaxLength="256" Columns="60" runat="server" /></td>
      <td><asp:RequiredFieldValidator id="QuestionRequiredValidator" runat="server"
                                    ControlToValidate="QuestionTextbox" ForeColor="red"
                                    Display="Static" ErrorMessage="Required" /></td>
    </tr>
    <tr>
      <td>New Password Answer:</td>
      <td><asp:Textbox id="AnswerTextbox" MaxLength="128" Columns="60" runat="server" /></td>
      <td><asp:RequiredFieldValidator id="AnswerRequiredValidator" runat="server"
                                    ControlToValidate="AnswerTextbox" ForeColor="red"
                                    Display="Static" ErrorMessage="Required" /></td>
    </tr>
    <tr>
      <td></td>
      <td><asp:Button id="ChangePasswordQuestionButton" 
                      Text="Change Password Question and Answer" 
                      OnClick="ChangePasswordQuestion_OnClick" 
                      runat="server" /></td>
    </tr>
  </table>
</form>

</body>
</html>
<!-- </Snippet10> -->