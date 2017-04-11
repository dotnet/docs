<!-- <Snippet9> -->

<%@ Page Language="VB" %>

<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Public Sub ChangePasswordQuestion_OnClick(ByVal sender As Object, ByVal args As EventArgs)
    Try
      Dim u As MembershipUser = Membership.GetUser(User.Identity.Name)
      Dim result As Boolean
      result = u.ChangePasswordQuestionAndAnswer(PasswordTextbox.Text, _
                                      QuestionTextbox.Text, _
                                      AnswerTextbox.Text)
  
      If (result = True) Then
        Msg.Text = "Password Question and Answer changed."
      Else
        Msg.Text = "Password Question and Answer change failed."
      End If
      
    Catch e As Exception
      Msg.Text = "Change failed. Please re-enter your values and try again."
    End Try
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
  <title>Sample: Change Password Question and Answer</title>
</head>
<body>
  <form id="form1" runat="server">
    <h3>
      Change Password Question and Answer for
      <%=User.Identity.Name%>
    </h3>
    <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
    <table cellpadding="3" border="0">
      <tr>
        <td>
          Password:</td>
        <td>
          <asp:TextBox ID="PasswordTextbox" runat="server" TextMode="Password" /></td>
        <td>
          <asp:RequiredFieldValidator ID="OldPasswordRequiredValidator" runat="server" ControlToValidate="PasswordTextbox"
            ForeColor="red" Display="Static" ErrorMessage="Required" /></td>
      </tr>
      <tr>
        <td>
          New Password Question:</td>
        <td>
          <asp:TextBox ID="QuestionTextbox" MaxLength="256" Columns="60" runat="server" /></td>
        <td>
          <asp:RequiredFieldValidator ID="QuestionRequiredValidator" runat="server" ControlToValidate="QuestionTextbox"
            ForeColor="red" Display="Static" ErrorMessage="Required" /></td>
      </tr>
      <tr>
        <td>
          New Password Answer:</td>
        <td>
          <asp:TextBox ID="AnswerTextbox" MaxLength="128" Columns="60" runat="server" /></td>
        <td>
          <asp:RequiredFieldValidator ID="AnswerRequiredValidator" runat="server" ControlToValidate="AnswerTextbox"
            ForeColor="red" Display="Static" ErrorMessage="Required" /></td>
      </tr>
      <tr>
        <td>
        </td>
        <td>
          <asp:Button ID="ChangePasswordQuestionButton" Text="Change Password Question and Answer"
            OnClick="ChangePasswordQuestion_OnClick" runat="server" /></td>
      </tr>
    </table>
  </form>
</body>
</html>
<!-- </Snippet9> -->
