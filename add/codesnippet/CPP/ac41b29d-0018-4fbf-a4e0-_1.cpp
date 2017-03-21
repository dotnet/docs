   virtual RealProxy^ CreateProxy( ObjRef^ objRef1, Type^ serverType, Object^ serverObject, Context^ serverContext ) override
   {
      MyProxy^ myCustomProxy = gcnew MyProxy( serverType );
      if ( serverContext != nullptr )
      {
         RealProxy::SetStubData( myCustomProxy, serverContext );
      }

      if ( ( !serverType->IsMarshalByRef) && (serverContext == nullptr) )
      {
         throw gcnew RemotingException( "Bad Type for CreateProxy" );
      }

      return myCustomProxy;
   }