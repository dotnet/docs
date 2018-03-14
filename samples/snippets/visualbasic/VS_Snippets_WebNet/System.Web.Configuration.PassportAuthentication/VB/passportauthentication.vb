
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration




Class UsingPassportAuthentication


Public Sub New() 
' <Snippet1>
' Get the configuration.
Dim configuration As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

' Get the authentication section.
Dim authenticationSection As System.Web.Configuration.AuthenticationSection = CType(configuration.GetSection("system.web/authentication"), System.Web.Configuration.AuthenticationSection)

' Get the authentication passport element.
Dim passport As PassportAuthentication = authenticationSection.Passport

' </Snippet1>

' <Snippet2>
' Create a new passport object.
Dim newPassport As New PassportAuthentication()

' </Snippet2>

' <Snippet3>
' Get the passport redirect URL
Dim redirectUrl As String = passport.RedirectUrl

' Set the passport redirect Url.
passport.RedirectUrl = "passportLogin.aspx"

If Not authenticationSection.SectionInformation.IsLocked Then
  configuration.Save()
End If

 ' </Snippet3>

End Sub 'New 
End Class 'UsingPassportAuthentication

