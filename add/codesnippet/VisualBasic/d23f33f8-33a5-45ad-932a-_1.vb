        Dim errorMessage As String = "The current operation is not supported."
        Dim nullException As New NullReferenceException
        Dim cryptographicException As _
            New CryptographicException(errorMessage, nullException)