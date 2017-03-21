      ' Using method Add.
      ' Define the SHA1 encrypted password.
        Dim password As String = _
        "5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8"
      ' Define the user name.
      Dim userName As String = "newUser"
      
      ' Create the new user.
        Dim currentUser _
        As New FormsAuthenticationUser(userName, password)
      
      ' Execute the Add method.
      formsAuthenticationCredentials.Users.Add(currentUser)
      
      ' Update if not locked
      If Not authenticationSection.SectionInformation.IsLocked Then
         configuration.Save()
      End If
      