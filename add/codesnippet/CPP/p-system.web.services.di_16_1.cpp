   String^ myDiscoFile = "http://localhost/MathService_cs.vsdisco";
   String^ myUrlKey = "http://localhost/MathService_cs.asmx?wsdl";
   DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;
   
   // Get the discovery document.
   DiscoveryDocument^ myDiscoveryDocument = myDiscoveryClientProtocol->Discover( myDiscoFile );
   IEnumerator^ myEnumerator = myDiscoveryDocument->References->GetEnumerator();
   while ( myEnumerator->MoveNext() )
   {
      ContractReference^ myContractReference = dynamic_cast<ContractReference^>(myEnumerator->Current);
      
      // Get the DiscoveryClientProtocol from the ContractReference.
      myDiscoveryClientProtocol = myContractReference->ClientProtocol;
      myDiscoveryClientProtocol->ResolveAll();
      DiscoveryExceptionDictionary^ myExceptionDictionary = myDiscoveryClientProtocol->Errors;
      if ( myExceptionDictionary->Contains( myUrlKey ) )
      {
         Console::WriteLine( "System generated exceptions." );
         
         // Get the exception from the DiscoveryExceptionDictionary.
         Exception^ myException = myExceptionDictionary[ myUrlKey ];
         Console::WriteLine( " Source : {0}", myException->Source );
         Console::WriteLine( " Exception : {0}", myException->Message );
      }
   }
}