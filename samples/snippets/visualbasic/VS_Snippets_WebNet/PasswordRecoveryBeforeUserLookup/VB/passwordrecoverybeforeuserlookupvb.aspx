<!-- <Snippet1> -->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Function IsValidEmail(ByVal strIn As String) As Boolean
        ' Return true if strIn is in valid e-mail format.
        Return Regex.IsMatch(strIn, ("^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
    End Function

    Sub PasswordRecovery1_VerifyingUser(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs)
        If Not IsValidEmail(PasswordRecovery1.UserName) Then
            PasswordRecovery1.UserNameInstructionText = "You must enter a valid e-mail address."
            e.Cancel = True
        Else
            PasswordRecovery1.UserNameInstructionText = "Enter your User Name to receive your password."
        End If
    End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:passwordrecovery id="PasswordRecovery1" 
        runat="server" 
        onverifyinguser="PasswordRecovery1_VerifyingUser">
      </asp:passwordrecovery>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
