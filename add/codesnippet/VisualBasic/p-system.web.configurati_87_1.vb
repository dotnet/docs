      ' Get the current Timeout.
        Dim currentTimeout As System.TimeSpan = _
        formsAuthentication.Timeout
      
      ' Set the Timeout.
        formsAuthentication.Timeout = _
        System.TimeSpan.FromMinutes(10)
      