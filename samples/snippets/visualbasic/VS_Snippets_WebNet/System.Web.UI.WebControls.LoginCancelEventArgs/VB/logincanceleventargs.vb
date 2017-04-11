' <snippet2>
Partial Class LoginCancelEventArgsvb_aspx
    Inherits System.Web.UI.Page

    Function IsValidEmail(ByVal strIn As String) As Boolean
        ' Return true if strIn is in valid e-mail format.
        Return Regex.IsMatch(strIn, _
            ("^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
    End Function

    Protected Sub OnLoggingIn(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs)
        If Not IsValidEmail(Login1.UserName) Then
            Login1.InstructionText = "You must enter a valid e-mail address."
            e.Cancel = True
        Else
            Login1.InstructionText = String.Empty
        End If
    End Sub

End Class
' </snippet2>
