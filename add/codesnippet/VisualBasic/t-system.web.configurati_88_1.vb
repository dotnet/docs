      ' Get the current PasswordFormat property value.
        Dim currentPasswordFormat _
        As FormsAuthPasswordFormat = _
        formsAuthenticationCredentials.PasswordFormat
      
      
      ' Set the PasswordFormat property value.
        formsAuthenticationCredentials.PasswordFormat = _
        FormsAuthPasswordFormat.SHA1
      