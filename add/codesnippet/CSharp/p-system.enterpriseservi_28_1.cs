                // Check whether the ErrorInfo property of the RegistrationException object is null. 
                // If there is no extended error information about 
                // methods related to multiple COM+ objects ErrorInfo will be null.
                if(e.ErrorInfo != null)
                {
                    // Gets an array of RegistrationErrorInfo objects describing registration errors
                    RegistrationErrorInfo[] registrationErrorInfos = e.ErrorInfo;
                    
                    // Iterate through the array of RegistrationErrorInfo objects and disply the 
                    // ErrorString for each object.

                    foreach (RegistrationErrorInfo registrationErrorInfo in registrationErrorInfos) 
                    {
                        Console.WriteLine(registrationErrorInfo.ErrorString);
                    }
                }