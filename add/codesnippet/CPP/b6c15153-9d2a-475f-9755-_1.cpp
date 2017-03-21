         myPortCollection = myService->Ports;
         Port^ myNewPort = myPortCollection[ 0 ];
         myPortCollection->Remove( myNewPort );

         // Display the number of ports.
         Console::WriteLine( "\nTotal number of ports before adding a new port : {0}", myService->Ports->Count );

         // Add a new port.
         myPortCollection->Add( myNewPort );

         // Display the number of ports after adding a port.
         Console::WriteLine( "Total number of ports after adding a new port : {0}", myService->Ports->Count );