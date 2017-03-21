      ' Get the current LoginUrl.
        Dim currentLoginUrl As String = _
        formsAuthentication.LoginUrl
      
      ' Set the LoginUrl. 
      formsAuthentication.LoginUrl = "newLoginUrl"
      