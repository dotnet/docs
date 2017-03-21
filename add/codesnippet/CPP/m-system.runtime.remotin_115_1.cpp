   // Register the channel.
   TcpChannel^ myChannel = gcnew TcpChannel;
   ChannelServices::RegisterChannel( myChannel );
   RemotingConfiguration::RegisterActivatedClientType( HelloService::typeid, "Tcp://localhost:8082" );

   GenericIdentity^ myIdentity = gcnew GenericIdentity( "Bob" );
   array<String^>^ idStr = gcnew array<String^>(1);
   idStr[ 0 ] = "Level1";
   GenericPrincipal^ myPrincipal = gcnew GenericPrincipal( myIdentity, idStr );
   MyLogicalCallContextData ^ myData = gcnew MyLogicalCallContextData( myPrincipal );

   // Set DataSlot with name parameter.
   CallContext::SetData( "test data", myData );

   // Create a remote Object*.
   HelloService ^ myService = gcnew HelloService;
   if ( myService == nullptr )
   {
      Console::WriteLine( "Cannot locate server." );
      return  -1;
   }

   // Call the Remote methods.
   Console::WriteLine( "Remote method output is {0}", myService->HelloMethod( "Microsoft" ) );

   MyLogicalCallContextData ^ myReturnData =
      (MyLogicalCallContextData^)( CallContext::GetData( "test data" ) );
   if ( myReturnData == nullptr )
   {
      Console::WriteLine( "Data is 0." );
   }
   else
   {
      Console::WriteLine( "Data is ' {0}'", myReturnData->numOfAccesses );
   }

   // DataSlot with same Name Parameter which was Set is Freed.
   CallContext::FreeNamedDataSlot( "test data" );
   MyLogicalCallContextData ^ myReturnData1 =
      (MyLogicalCallContextData^)( CallContext::GetData( "test data" ) );
   if ( myReturnData1 == nullptr )
   {
      Console::WriteLine( "FreeNamedDataSlot Successful for test data" );
   }
   else
   {
      Console::WriteLine( "FreeNamedDataSlot Failed  for test data" );
   }