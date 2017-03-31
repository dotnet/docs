<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.ComponentModel" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
Function IsValidEmail(ByVal strIn As String) As Boolean
    ' Return true if strIn is in valid e-mail format.
    Return Regex.IsMatch(strIn, ("^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
End Function

Sub OnLoggingIn(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs)

    Dim loginControl As Login

    loginControl = CType(PlaceHolder1.FindControl("loginControl"), Login)

    If Not IsValidEmail(loginControl.UserName) Then
        loginControl.InstructionText = "You must enter a valid e-mail address."
        e.Cancel = True
    Else
        loginControl.InstructionText = String.Empty
    End If
End Sub

Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    Dim loginControl As New Login

    loginControl.ID = "loginControl"

    loginControl.HelpPageText = "Help loggin in..."
    loginControl.HelpPageUrl = "help.aspx"

    loginControl.PasswordRecoveryText = "Forgot your password?"
    loginControl.PasswordRecoveryUrl = "getPass.aspx"

    AddHandler loginControl.LoggingIn, AddressOf OnLoggingIn

    PlaceHolder1.Controls.Add(loginControl)

End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
