         // Create an instance of MyProxy.
         MyProxy myProxyInstance = new MyProxy(typeof(CustomServer));
         // Get a CustomServer proxy.
         CustomServer myHelloServer = (CustomServer)myProxyInstance.GetTransparentProxy();
         // Get stubdata.
         Console.WriteLine("GetStubData = " + RealProxy.GetStubData(myProxyInstance).ToString()); 
         // Get ProxyType.
         Console.WriteLine("Type of object represented by RealProxy is :" 
                           + myProxyInstance.GetProxiedType());