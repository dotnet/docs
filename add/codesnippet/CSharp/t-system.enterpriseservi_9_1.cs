            try
            {
                string applicationName = "Queued Component";			
                string typeLibraryName = null;
                RegistrationHelper helper = new RegistrationHelper(); 
                // Call the InstallAssembly method passing it the name of the assembly to 
                // install as a COM+ application, the COM+ application name, and 
                // the name of the type library file.
                // Setting the application name and the type library to NULL (nothing in Visual Basic .NET
                // allows you to use the COM+ application name that is given in the assembly and 
                // the default type library name. The application name in the assembly metadata 
                // takes precedence over the application name you provide to InstallAssembly. 
                helper.InstallAssembly(@"C:..\..\QueuedComponent.dll", ref applicationName, ref typeLibraryName, InstallationFlags.CreateTargetApplication);
                Console.WriteLine("Registration succeeded: Type library {0} created.", typeLibraryName);
                Console.Read();

                // Create a RegistrationConfig object and set its attributes
                // Create a RegistrationHelper object, and call the InstallAssemblyFromConfig
                // method by passing the RegistrationConfiguration object to it as a 
                // reference object
                RegistrationConfig registrationConfiguration = new RegistrationConfig();
                registrationConfiguration.AssemblyFile=@"C:..\..\QueuedComponent.dll";
                registrationConfiguration.Application = "MyApp";
                registrationConfiguration.InstallationFlags = InstallationFlags.CreateTargetApplication;
                RegistrationHelper helperFromConfig = new RegistrationHelper();
                helperFromConfig.InstallAssemblyFromConfig(ref registrationConfiguration); 
                            
            }
            
            catch(RegistrationException e)
            {
                Console.WriteLine(e.Message); 
                
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
                Console.Read();
            }