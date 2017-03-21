        ' GetRealProxy, GetObjectUri, GetEnvoyChainForProxy
        Dim proxy As RealProxy = RemotingServices.GetRealProxy(obj)
        Console.WriteLine("Real proxy type: {0}", proxy.GetProxiedType().ToString())

        Console.WriteLine("Object URI: {0}", RemotingServices.GetObjectUri(obj).ToString())

        Dim msgSink As IMessageSink = RemotingServices.GetEnvoyChainForProxy(obj).NextSink