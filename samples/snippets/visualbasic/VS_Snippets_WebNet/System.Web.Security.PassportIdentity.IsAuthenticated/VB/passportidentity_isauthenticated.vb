Imports System
Imports System.Web.Security

Namespace myPassportExamples
public class myPassportIdentity
public sub Main()

' <snippet1>
' Declare new PassportIdendity object as variable newPass.
Dim newPass As System.Web.Security.PassportIdentity = New System.Web.Security.PassportIdentity()
' Set the string sIsAuth to the users SignIn status (a boolean) converted to a string.
Dim sIsAuth As String = newPass.IsAuthenticated.ToString()
' </snippet1>
End Sub
End Class
End Namespace

