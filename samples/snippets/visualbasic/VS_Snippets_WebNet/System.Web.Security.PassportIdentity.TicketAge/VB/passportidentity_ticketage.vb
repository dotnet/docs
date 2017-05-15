Imports System
Imports System.Web.Security

Namespace myPassportExamples
public class myPassportIdentity
public sub Main()
' <snippet1>
' Declare new PassportIdendity object as variable newPass.
Dim newPass As System.Web.Security.PassportIdentity = New System.Web.Security.PassportIdentity()
' Build a string with the elapsed time since the user's ticket was last refreshed 
' with the Passport Authority.
Dim sElapsedTime As String = "Elapsed time since ticket refresh: " + newPass.TicketAge.ToString() + " seconds."
' </snippet1>
End Sub
End Class
End Namespace

