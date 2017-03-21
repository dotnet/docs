' Declare new PassportIdendity object as variable newPass.
Dim newPass As System.Web.Security.PassportIdentity = New System.Web.Security.PassportIdentity()
' Declare and set myURL variable = the URL of the appropriate Passport SignIn/SignOut Authority.
Dim myURL As String = newPass.AuthUrl()