        string errorMessage = ("The current operation is not supported.");
        NullReferenceException nullException = new NullReferenceException();
        CryptographicUnexpectedOperationException cryptographicException = 
            new CryptographicUnexpectedOperationException(
            errorMessage, nullException);