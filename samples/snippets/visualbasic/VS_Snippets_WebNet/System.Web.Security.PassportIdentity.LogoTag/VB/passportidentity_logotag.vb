Imports System
Imports System.Web.Security

Namespace myPassportExamples
public class myPassportIdentity
public sub Main()
' <snippet1>
' Declare new PassportIdendity object as variable newPass.
Dim newPass As System.Web.Security.PassportIdentity = New System.Web.Security.PassportIdentity()
' Set a string to the URL of the appropriate Passport 
' SignIn/SignOut Authority.
Dim sPassportlink As String = newPass.LogoTag()
' </snippet1>
End Sub
End Class
End Namespace

