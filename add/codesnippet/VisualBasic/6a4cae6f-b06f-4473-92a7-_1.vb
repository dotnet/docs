      ' Using method RemoveAt.
      formsAuthenticationCredentials.Users.RemoveAt(0)
      
      If Not authenticationSection.SectionInformation.IsLocked Then
         configuration.Save()
      End If