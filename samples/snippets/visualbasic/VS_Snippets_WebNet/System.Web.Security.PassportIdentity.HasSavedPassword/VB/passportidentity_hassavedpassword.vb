Imports System
Imports System.Web.Security

Namespace myPassportExamples
public class myPassportIdentity
public sub Main()

' <snippet1>
' Declare new PassportIdendity object as variable newPass.
Dim newPass As System.Web.Security.PassportIdentity = New System.Web.Security.PassportIdentity()
' Create a string variable that indicates whether the user has a valid Passport ticket.
Dim sHasTick As String = newPass.HasTicket.ToString()
' </snippet1>
End Sub
End Class
End Namespace

