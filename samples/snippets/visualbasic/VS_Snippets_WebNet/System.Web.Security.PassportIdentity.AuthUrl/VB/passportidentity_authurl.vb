Imports System
Imports System.Web.Security

Namespace myPassportExamples
public class myPassportIdentity
public sub Main()

' <snippet1>
' Declare new PassportIdendity object as variable newPass.
Dim newPass As System.Web.Security.PassportIdentity = New System.Web.Security.PassportIdentity()
' Declare and set myURL variable = the URL of the appropriate Passport SignIn/SignOut Authority.
Dim myURL As String = newPass.AuthUrl()
' </snippet1>
End Sub
End Class
End Namespace

