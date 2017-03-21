      ' Using method Clear.
      formsAuthenticationCredentials.Users.Clear()
      ' Update if not locked
      If Not authenticationSection.SectionInformation.IsLocked Then
         configuration.Save()
      End If