      ' Get the current SlidingExpiration.
        Dim currentSlidingExpiration As Boolean = _
        formsAuthentication.SlidingExpiration
      
      ' Set the SlidingExpiration.
      formsAuthentication.SlidingExpiration = False
      
      