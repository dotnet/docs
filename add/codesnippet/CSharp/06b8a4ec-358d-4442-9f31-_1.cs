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