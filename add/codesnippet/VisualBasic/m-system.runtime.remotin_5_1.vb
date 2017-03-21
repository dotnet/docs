         ' Create an instance of MyProxy.
         Dim myProxyInstance As New MyProxy(GetType(CustomServer))
         ' Get a CustomServer proxy.
         Dim myHelloServer As CustomServer = _
                     CType(myProxyInstance.GetTransparentProxy(), CustomServer)
         ' Get stubdata.
         Console.WriteLine("GetStubData = " + RealProxy.GetStubData(myProxyInstance).ToString())
         ' Get ProxyType.
         Console.WriteLine("Type of object represented by RealProxy is :" + _
                                                myProxyInstance.GetProxiedType().ToString())