<!-- <Snippet1> -->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    ' This custom Login control checks the user name
    ' entered by the user is a valid e-mail address.
    Class CustomLogin
        Inherits Login
        
        Function IsValidEmail(ByVal strIn As String) As Boolean
            ' Return true if strIn is in valid e-mail format.
            Return Regex.IsMatch(strIn, ("^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
        End Function

        Overrides Protected Sub OnLoggingIn(ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs)
            If Not IsValidEmail(UserName) Then
                InstructionText = "You must enter a valid e-mail address."
                e.Cancel = True
            Else
                InstructionText = String.Empty
            End If
        End Sub
    End Class
    
    ' Add the custom login control to the page.
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim loginControl As New CustomLogin

        loginControl.ID = "loginControl"

        PlaceHolder1.Controls.Add(loginControl)
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<form id="Form1" runat="server">
    <asp:placeholder id="Placeholder1" runat="Server"></asp:placeholder>
</form>
</body>
</html>
<!-- </Snippet1> -->
