        Dim errorMessage As String = "The current operation is not supported."
        Dim nullException As New NullReferenceException
        Dim cryptographicException As _
            New CryptographicUnexpectedOperationException( _
            errorMessage, nullException)