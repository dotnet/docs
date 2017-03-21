         ServiceController^ sc = gcnew ServiceController(  "Messenger" );
         array<ServiceController^>^scServices = nullptr;
         if ( sc )
         {
            scServices = sc->ServicesDependedOn;
         }

         if ( sc && scServices )
         {
            // Display the services that the Messenger service is dependent on.
            if ( scServices->Length == 0 )
            {
               Console::WriteLine(  "{0} service is not dependent on any other services.", sc->ServiceName );
            }
            else
            {
               Console::WriteLine(  "{0} service is dependent on the following:", sc->ServiceName );
               for each (ServiceController^ scTemp in scServices)
               {
                  Console::WriteLine(" {0}", scTemp->DisplayName);
               }
            }
         }