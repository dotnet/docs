      ' Get second error StatusCode.
        Dim currentError1 As CustomError = _
        customErrorsCollection(1)
        Dim currentStatusCode As Integer = _
        currentError1.StatusCode
      
      ' Set the second error StatusCode.
        currentError1.StatusCode = 404