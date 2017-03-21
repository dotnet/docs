   HttpChannel^ channel = gcnew HttpChannel( 9000 );
   ChannelServices::RegisterChannel( channel, false );
   RemotingConfiguration::RegisterWellKnownServiceType( SampleNamespace::SampleService::typeid, "MySampleService/SampleService::soap", WellKnownObjectMode::Singleton );
   Console::WriteLine( "** Press enter to end the server process. **" );
   Console::ReadLine();