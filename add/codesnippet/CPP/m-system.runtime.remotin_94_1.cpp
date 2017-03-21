      // Registers the server and waits until the user hits enter.
      TcpChannel^ chan = gcnew TcpChannel( 8084 );
      ChannelServices::RegisterChannel( chan );

      RemotingConfiguration::RegisterWellKnownServiceType(
         Type::GetType( "HelloServer,server" ),
         "SayHello",
         WellKnownObjectMode::SingleCall );
      System::Console::WriteLine( L"Hit <enter> to exit..." );
      System::Console::ReadLine();