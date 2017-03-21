      // GetRealProxy, GetObjectUri, GetEnvoyChainForProxy
      RealProxy proxy = RemotingServices.GetRealProxy(obj);
      Console.WriteLine("Real proxy type: {0}", proxy.GetProxiedType().ToString());

      Console.WriteLine("Object URI: {0}", RemotingServices.GetObjectUri(obj).ToString());

      IMessageSink  msgSink = RemotingServices.GetEnvoyChainForProxy(obj).NextSink;