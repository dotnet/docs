      IServerChannelSink^ nextSink = nullptr;
      if ( nextProvider != nullptr )
      {
         Console::WriteLine( "The next server provider is:{0}", nextProvider );

         // Create a sink chain calling the 'SaopServerFormatterProvider'
         // 'CreateSink' method.
         nextSink = nextProvider->CreateSink( channel );
      }

      return gcnew MyServerChannelSink( nextSink );