         // Create an instance of MyProxy.
         MyProxy myProxyInstance = new MyProxy(typeof(CustomServer));
         // Get a CustomServer proxy.
         CustomServer myHelloServer = (CustomServer)myProxyInstance.GetTransparentProxy();