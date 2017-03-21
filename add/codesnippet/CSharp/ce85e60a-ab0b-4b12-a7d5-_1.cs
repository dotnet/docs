            DiscoveryExceptionDictionary myNewExceptionDictionary =
                                       new DiscoveryExceptionDictionary();
            // Add an exception with the custom error message.
            Exception myNewException = 
                 new Exception("The requested service is not available.");
            myNewExceptionDictionary.Add(myUrlKey, myNewException);
            myExceptionDictionary = myNewExceptionDictionary;