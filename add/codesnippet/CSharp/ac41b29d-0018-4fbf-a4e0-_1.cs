      public override RealProxy CreateProxy(ObjRef objRef1,
         Type serverType,
         object serverObject,
         Context serverContext)
      {
         MyProxy myCustomProxy = new MyProxy(serverType);
         if(serverContext != null)
         {
            RealProxy.SetStubData(myCustomProxy,serverContext);
         }
         if((!serverType.IsMarshalByRef)&&(serverContext == null))
         {
            throw new RemotingException("Bad Type for CreateProxy");
         }
         return myCustomProxy;
      }