        string dateFormat = "{0:t}";
        string timeStamp = (DateTime.Now.ToString());
        CryptographicException cryptographicException = 
            new CryptographicException(dateFormat, timeStamp);