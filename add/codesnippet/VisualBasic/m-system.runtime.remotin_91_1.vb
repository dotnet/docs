         ' Create an instance of MyProxy.
         Dim myProxyInstance As New MyProxy(GetType(CustomServer))
         ' Get a CustomServer proxy.
         Dim myHelloServer As CustomServer = _
                     CType(myProxyInstance.GetTransparentProxy(), CustomServer)