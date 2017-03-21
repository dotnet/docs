      Console::WriteLine( "Connecting to SampleNamespace::SampleWellKnown." );
      SampleWellKnown ^ proxy = dynamic_cast<SampleWellKnown^>(RemotingServices::Connect( SampleWellKnown::typeid, const_cast<String^>(SERVER_URL) ));
      Console::WriteLine( "Connected to SampleWellKnown" );

      // Verifies that the Object* reference is to a transparent proxy.
      if ( RemotingServices::IsTransparentProxy( proxy ) )
            Console::WriteLine( "proxy is a reference to a transparent proxy." );
      else
            Console::WriteLine( "proxy is not a transparent proxy.  This is unexpected." );

      // Calls a method on the server Object*.
      Console::WriteLine( "proxy->Add returned {0}.", proxy->Add( 2, 3 ) );