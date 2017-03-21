         // Create an instance of MyProxy.
         MyProxy myProxyInstance = new MyProxy(typeof(CustomServer));
         // Get a CustomServer proxy.
         CustomServer myHelloServer = (CustomServer)myProxyInstance.GetTransparentProxy();
         // Get stubdata.
         Console.WriteLine("GetStubData = " + RealProxy.GetStubData(myProxyInstance).ToString()); 