Imports System
Imports System.Web.Security

Namespace myPassportExamples
public class myPassportIdentity
public sub Main()

' <snippet1>
' Declare new PassportIdendity object as variable newPass.
Dim newPass As System.Web.Security.PassportIdentity = New System.Web.Security.PassportIdentity()
' Get the URL for the Passport Information page using the 
' GetDomainAttribute(attributeName, LocaleID, Domain) method.
' LocaleID 1033 = English-USA
' Create a string with the name of the Passport domain associated with the current UserName.
Dim sPassportDomain As String = newPass.GetDomainFromMemberName(newPass.Name)
Dim sInfoURL As String = newPass.GetDomainAttribute("PassportInformationCenter", 1033, sPassportDomain)
' </snippet1>
End Sub
End Class
End Namespace

