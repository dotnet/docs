        string dateFormat = "{0:t}";
        string timeStamp = (DateTime.Now.ToString());
        CryptographicUnexpectedOperationException cryptographicException = 
            new CryptographicUnexpectedOperationException(
            dateFormat, timeStamp);