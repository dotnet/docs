' Declare new PassportIdendity object as variable newPass.
Dim newPass As System.Web.Security.PassportIdentity = New System.Web.Security.PassportIdentity()
' Set the string sIsAuth to the users SignIn status (a boolean) converted to a string.
Dim sIsAuth As String = newPass.IsAuthenticated.ToString()