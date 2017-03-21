      ' Display registered authentication modules.
      Private Shared Sub displayRegisteredModules()
        ' The AuthenticationManager calls all authentication modules sequentially 
        ' until one of them responds with an authorization instance.  Show
        ' the current registered modules.
        Dim registeredModules As IEnumerator = AuthenticationManager.RegisteredModules
        Console.WriteLine(ControlChars.Cr + ControlChars.Lf + "The following authentication modules are now registered with the system:")
        While registeredModules.MoveNext()
          Console.WriteLine(ControlChars.Cr + " " + ControlChars.Lf + " Module : {0}", registeredModules.Current)
          Dim currentAuthenticationModule As IAuthenticationModule = CType(registeredModules.Current, IAuthenticationModule)
          Console.WriteLine(ControlChars.Tab + "  CanPreAuthenticate : {0}", currentAuthenticationModule.CanPreAuthenticate)
        End While
      End Sub 'displayRegisteredModules 
