        string errorMessage = ("The current operation is not supported.");
        NullReferenceException nullException = new NullReferenceException();
        CryptographicException cryptographicException = 
            new CryptographicException(errorMessage, nullException);