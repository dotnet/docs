         ServiceController^ sc = gcnew ServiceController(  "Event Log" );
         array<ServiceController^>^scServices = nullptr;
         if ( sc )
         {
            scServices = sc->DependentServices;
         }

         if ( sc && scServices )
         {
            // Display the list of services dependent on the Event Log service.
            if ( scServices->Length == 0 )
            {
               Console::WriteLine(  "There are no services dependent on {0}", sc->ServiceName );
            }
            else
            {
               Console::WriteLine(  "Services dependent on {0}:", sc->ServiceName );
               for each (ServiceController^ scTemp in scServices)
               {
                  Console::WriteLine(" {0}", scTemp->DisplayName);
               }
            }
         }