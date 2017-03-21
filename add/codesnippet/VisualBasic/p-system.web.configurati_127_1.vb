      ' Using the Password property.
      ' Get current password.
        Dim currentPassword As String = _
        formsAuthenticationUsers(0).Password
      
      ' Set a SHA1 encrypted password.
        formsAuthenticationUsers(0).Password = _
        "5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8"
      