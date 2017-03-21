      ' Get the current Credentials.
        Dim currentCredentials _
        As FormsAuthenticationCredentials = _
        formsAuthentication.Credentials
      
      Dim credentials As New StringBuilder()
      ' Get all the credentials.
      Dim i As System.Int32
      For i = 0 To currentCredentials.Users.Count - 1
            credentials.Append(("Name: " + _
            currentCredentials.Users(i).Name + _
            " Password: " + _
            currentCredentials.Users(i).Password))
         credentials.Append(Environment.NewLine)
        Next i