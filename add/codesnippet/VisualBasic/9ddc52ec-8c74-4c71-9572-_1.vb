         Dim myExceptionDictionary As DiscoveryExceptionDictionary = myDiscoveryClientProtocol2.Errors
         If myExceptionDictionary.Contains(myUrlKey) = True Then
            Console.WriteLine("'myExceptionDictionary' contains " + _
                 "a discovery exception for the key '" + myUrlKey + "'")
         Else
            Console.WriteLine("'myExceptionDictionary' does not contain" + _
                 " a discovery exception for the key '" + myUrlKey + "'")
         End If