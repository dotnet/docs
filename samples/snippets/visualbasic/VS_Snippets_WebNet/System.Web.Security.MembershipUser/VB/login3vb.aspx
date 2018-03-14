<!-- <Snippet10> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub Login_OnClick(sender As Object, args As EventArgs)

  Dim returnMessage As String
  Dim u As MembershipUser = Membership.GetUser(UsernameTextbox.Text)

  If u Is Nothing Then
    Msg.Text = "Invalid user name. Please check your user name and try again."
    Return
  End If

  If ValidateUser(u, PasswordTextbox.Text, returnMessage) Then
    FormsAuthentication.RedirectFromLoginPage(UsernameTextbox.Text, NotPublicCheckBox.Checked)
  Else
    Msg.Text = returnMessage
  End If
End Sub

Public Function ValidateUser(u As MembershipUser, password As String, _
                             ByRef returnMessage As String) As Boolean

  Dim maxInvalidAttempts As Integer = 3
  Dim validated As Boolean = False

  If Membership.ValidateUser(u.UserName, password) Then
      u.Comment = "0"            ' Reset count of invalid validation attempts.
      validated = True
      returnMessage = "Validated"
  Else
    ' Increment the count of invalid validation attempts.

    Dim invalidAttempts As Integer = Convert.ToInt32(u.Comment)
    invalidAttempts += 1
    u.Comment = invalidAttempts.ToString()


    ' Determine the cause of the validation failure and disable the account if
    ' there have been too many failed validation attempts.

    If Not u.IsApproved Then
      returnMessage = "Your account has been disabled. " & _
                      "Please contact your administrator to re-enable your user name."
    Else
      If invalidAttempts >= maxInvalidAttempts Then
        returnMessage = "Too many invalid login attempts. Your account has been disabled. " & _
                        "Please contact your administrator to re-enable your user name."
        u.IsApproved = False
      Else
        returnMessage = "Invalid Password. Please check your password and try again."
      End If
    End If
  End If

  Try
    Membership.UpdateUser(u)
  Catch e As HttpException
    returnMessage = "An error occurred communicating with the data source. Please contact your administrator."
  End Try

  Return validated
End Function


</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
  <title>Login</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Login</h3>

  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />

  Username: <asp:Textbox id="UsernameTextbox" runat="server" /><br />
  Password: <asp:Textbox id="PasswordTextbox" runat="server" TextMode="Password" /><br />
 
  <asp:Button id="LoginButton" Text="Login" OnClick="Login_OnClick" runat="server" />
  <asp:CheckBox id="NotPublicCheckBox" runat="server" /> Check here if this is <span style="text-decoration:underline">not</span> a public computer.

</form>
<br />

</body>
</html>
<!-- </Snippet10> -->
