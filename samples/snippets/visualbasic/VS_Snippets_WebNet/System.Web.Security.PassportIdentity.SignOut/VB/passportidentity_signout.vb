Imports System
Imports System.Web.Security

Namespace myPassportExamples
public class myPassportIdentity
public sub Main()
' <snippet1>
' This example demonstrates how to sign a user out of Passport.
' local GIF file that the user is redirected to.
Dim signOutGifFile As String = "signout.gif"
' Signs the user out of their Passport Profile and displays the SignOut.gif file.
System.Web.Security.PassportIdentity.SignOut(signOutGifFile)
' </snippet1>
End Sub
End Class
End Namespace

