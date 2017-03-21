         DiscoveryExceptionDictionary myExceptionDictionary 
                                      = myDiscoveryClientProtocol2.Errors;
         if ( myExceptionDictionary.Contains(myUrlKey) == true )
         {
            Console.WriteLine("'myExceptionDictionary' contains " +
                      " a discovery exception for the key '" + myUrlKey + "'");
         }
         else
         {
            Console.WriteLine("'myExceptionDictionary' does not contain" +
                      " a discovery exception for the key '" + myUrlKey + "'");
         }