            ' Create a RegistrationConfig object and set its attributes
            ' Create a RegistrationHelper object, and call the InstallAssemblyFromConfig
            ' method by passing the RegistrationConfiguration object to it as a 
            ' reference object
            Dim registrationConfiguration As New RegistrationConfig()
            registrationConfiguration.AssemblyFile = "C:..\..\QueuedComponent.dll"
            registrationConfiguration.Application = "MyApp"
            registrationConfiguration.InstallationFlags = InstallationFlags.CreateTargetApplication
            Dim helperFromConfig As New RegistrationHelper()
            helperFromConfig.InstallAssemblyFromConfig(registrationConfiguration)