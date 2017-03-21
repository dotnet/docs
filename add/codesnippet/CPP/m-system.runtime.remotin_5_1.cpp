   // Create an instance of MyProxy.
   MyProxy^ myProxyInstance = gcnew MyProxy( CustomServer::typeid );
   
   // Get a CustomServer proxy.
   CustomServer^ myHelloServer = static_cast<CustomServer^>(myProxyInstance->GetTransparentProxy());

   // Get stubdata.
   Console::WriteLine( "GetStubData = {0}", RealProxy::GetStubData( myProxyInstance ) );

   // Get ProxyType.
   Console::WriteLine( "Type of object represented by RealProxy is : {0}", myProxyInstance->GetProxiedType() );