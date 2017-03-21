   // Register the channel.
   TcpChannel^ myChannel = gcnew TcpChannel;
   ChannelServices::RegisterChannel( myChannel );
   RemotingConfiguration::RegisterActivatedClientType( HelloService::typeid, "Tcp://localhost:8085" );
   TimeSpan myTimeSpan = TimeSpan::FromMinutes( 10 );

   // Create a remote object.
   HelloService ^ myService = gcnew HelloService;
   ILease^ myLease;
   myLease = dynamic_cast<ILease^>(RemotingServices::GetLifetimeService( myService ));
   if ( myLease == nullptr )
   {
      Console::WriteLine( "Cannot lease." );
      return  -1;
   }

   Console::WriteLine( "Initial lease time is {0}", myLease->InitialLeaseTime );
   Console::WriteLine( "Current lease time is {0}", myLease->CurrentLeaseTime );
   Console::WriteLine( "Renew on call time is {0}", myLease->RenewOnCallTime );
   Console::WriteLine( "Sponsorship timeout is {0}", myLease->SponsorshipTimeout );
   Console::WriteLine( "Current lease state is {0}", myLease->CurrentState );