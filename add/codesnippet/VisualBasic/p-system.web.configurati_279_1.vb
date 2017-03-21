' Get the passport redirect URL
Dim redirectUrl As String = passport.RedirectUrl

' Set the passport redirect Url.
passport.RedirectUrl = "passportLogin.aspx"

If Not authenticationSection.SectionInformation.IsLocked Then
  configuration.Save()
End If
