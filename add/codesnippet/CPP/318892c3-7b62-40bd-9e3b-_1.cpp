      //GetRealProxy, GetObjectUri, GetEnvoyChainForProxy
      RealProxy^ proxy = RemotingServices::GetRealProxy( obj );
      Console::WriteLine( "Real proxy type: {0}", proxy->GetProxiedType() );
      Console::WriteLine( "Object URI: {0}", RemotingServices::GetObjectUri( obj ) );
      IMessageSink^ msgSink = RemotingServices::GetEnvoyChainForProxy( obj )->NextSink;