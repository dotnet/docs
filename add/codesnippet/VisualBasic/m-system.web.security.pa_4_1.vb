' Declare new PassportIdendity object as variable newPass.
Dim newPass As System.Web.Security.PassportIdentity = New System.Web.Security.PassportIdentity()
' Set a string to the URL of the appropriate Passport 
' SignIn/SignOut Authority.
Dim sPassportlink As String = newPass.LogoTag()