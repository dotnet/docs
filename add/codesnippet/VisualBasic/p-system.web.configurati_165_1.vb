      ' Get the current Passport property.
        Dim currentPassport _
        As PassportAuthentication = _
        authenticationSection.Passport
      
      ' Get the Passport redirect URL.
        Dim passRedirectUrl As String = _
        currentPassport.RedirectUrl
      