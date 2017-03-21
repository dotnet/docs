      ' Get the current EnableCrossAppRedirects.
        Dim currentEnableCrossAppRedirects As Boolean = _
        formsAuthentication.EnableCrossAppRedirects
      
      ' Set the EnableCrossAppRedirects.
      formsAuthentication.EnableCrossAppRedirects = False
      
      