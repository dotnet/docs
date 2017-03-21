            Dim myNewExceptionDictionary As New DiscoveryExceptionDictionary()
            ' Add an exception with the custom error message.
            Dim myNewException As New Exception("The requested service is not available.")
            myNewExceptionDictionary.Add(myUrlKey, myNewException)
            myExceptionDictionary = myNewExceptionDictionary