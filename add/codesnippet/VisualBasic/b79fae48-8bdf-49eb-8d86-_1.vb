        Dim dateFormat As String = "{0:t}"
        Dim timeStamp As String = DateTime.Now.ToString()
        Dim cryptographicException As _
            New CryptographicException(dateFormat, timeStamp)