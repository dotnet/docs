      ' Using method Set.
      ' Define the SHA1 encrypted password.
        Dim newPassword As String = _
        "5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8"
      ' Define the user name.
      Dim currentUserName As String = "userName"
      
      ' Create the new user.
        Dim theUser _
        As New FormsAuthenticationUser(currentUserName, newPassword)
      
      formsAuthenticationCredentials.Users.Set(theUser)
      
      If Not authenticationSection.SectionInformation.IsLocked Then
         configuration.Save()
      End If