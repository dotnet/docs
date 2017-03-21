      IEnumerator^ registeredModules = AuthenticationManager::RegisteredModules;
      // Display all the modules that are already registered with the system.
      DisplayAllModules();
      registeredModules->Reset();
      registeredModules->MoveNext();
      // Get the first Authentication module registered with the system.
      IAuthenticationModule^ authenticationModule1 = dynamic_cast<IAuthenticationModule^>(registeredModules->Current);
      // Call the UnRegister() method to unregister the first authentication module from the system.
      String^ authenticationScheme = authenticationModule1->AuthenticationType;
      AuthenticationManager::Unregister( authenticationScheme );
      Console::WriteLine(  "\nSuccessfully unregistered '{0}'.", authenticationModule1 );
      // Display all modules to see that the module was unregistered.
      DisplayAllModules();