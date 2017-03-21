      Service^ myService;
      PortCollection^ myPortCollection;
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathServiceItem_cs.wsdl" );
      Console::WriteLine( "Total number of services : {0}", myServiceDescription->Services->Count );
      for ( int i = 0; i < myServiceDescription->Services->Count; ++i )
      {
         myService = myServiceDescription->Services[ i ];
         Console::WriteLine( "Name : {0}", myService->Name );
         myPortCollection = myService->Ports;

         // Create an array of ports.
         Console::WriteLine( "\nPort collection :" );
         for ( int i1 = 0; i1 < myService->Ports->Count; ++i1 )
         {
            Console::WriteLine( "Port[{0}] : {1}", i1, myPortCollection[ i1 ]->Name );
         }