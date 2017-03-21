        Dim registeredModules As IEnumerator = AuthenticationManager.RegisteredModules
        DisplayAllModules()
        
        registeredModules.Reset()
        registeredModules.MoveNext()
        
        'Get the first Authentication module registered with the system
        Dim authenticationModule1 As IAuthenticationModule = CType(registeredModules.Current, IAuthenticationModule)
        
        'Call the UnRegister method to unregister the first authentication module from the system.
        Dim authenticationScheme As [String] = authenticationModule1.AuthenticationType
        AuthenticationManager.Unregister(authenticationScheme)
        Console.WriteLine(ControlChars.Cr + "Successfully unregistered {0}", authenticationModule1)
        'Display all modules to see that the module was unregistered.
        DisplayAllModules()
        'Call the Register method to register authenticationModule1 module again.
        AuthenticationManager.Register(authenticationModule1)
        Console.WriteLine(ControlChars.Cr + "Successfully re-registered {0}", authenticationModule1)
        'Display the modules to verify that 'authenticationModule1' has been registered again.
        DisplayAllModules()