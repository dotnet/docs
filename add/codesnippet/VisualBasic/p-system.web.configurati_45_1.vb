      ' Get current DefaultUrl.
        Dim currentDefaultUrl As String = _
        formsAuthentication.DefaultUrl
      
      ' Set current DefaultUrl.
      formsAuthentication.DefaultUrl = "newDefaultUrl"
      