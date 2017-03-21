   // Display registered authentication modules.
   static void displayRegisteredModules()
   {
      
      // The AuthenticationManager calls all authentication modules sequentially
      // until one of them responds with an authorization instance.  Show
      // the current registered modules, for testing purposes.
      IEnumerator^ registeredModules = AuthenticationManager::RegisteredModules;
      Console::WriteLine( "\r\nThe following authentication modules are now registered with the system" );
      while ( registeredModules->MoveNext() )
      {
         Console::WriteLine( "\r \n Module : {0}", registeredModules->Current );
         IAuthenticationModule^ currentAuthenticationModule = dynamic_cast<IAuthenticationModule^>(registeredModules->Current);
         Console::WriteLine( "\t  CanPreAuthenticate : {0}", currentAuthenticationModule->CanPreAuthenticate );
      }
   }

