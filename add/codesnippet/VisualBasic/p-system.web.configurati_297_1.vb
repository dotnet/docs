      ' Get first errorr Redirect.
        Dim currentError0 As CustomError = _
        customErrorsCollection(0)
        Dim currentRedirect As String = _
        currentError0.Redirect
      
      ' Set first error Redirect.
      currentError0.Redirect = "customError404.htm"
      