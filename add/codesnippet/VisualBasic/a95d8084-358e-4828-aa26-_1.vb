      ' Using method Remove.
      ' Execute the Remove method.
      formsAuthenticationCredentials.Users.Remove("userName")
      
      ' Update if not locked
      If Not authenticationSection.SectionInformation.IsLocked Then
         configuration.Save()
      End If