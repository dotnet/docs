   [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
   public void ProcessMessageStart(IMessage requestMessage, bool bClientSide, bool bAsyncCall) {
      
      Console.WriteLine("\nProcessMessageStart");
      Console.WriteLine("requestMessage = {0}", requestMessage);
      
      try {
         Console.WriteLine("SessionId = {0}.",
             RemotingServices.GetSessionIdForMethodMessage((IMethodMessage)requestMessage));
      }
      catch (InvalidCastException) {
         Console.WriteLine("The requestMessage is not an IMethodMessage.");
      }

      IMethodCallMessage requestMethodCallMessage;
      
      try {
         requestMethodCallMessage = (IMethodCallMessage)requestMessage;
         // Prints the details of the IMethodCallMessage to the console.
         Console.WriteLine("\nMethodCall details");
         Console.WriteLine("Uri = {0}", requestMethodCallMessage.Uri);
         Console.WriteLine("TypeName = {0}", requestMethodCallMessage.TypeName);
         Console.WriteLine("MethodName = {0}", requestMethodCallMessage.MethodName);
         Console.WriteLine("ArgCount = {0}", requestMethodCallMessage.ArgCount);
         
         Console.WriteLine("MethodCall.Args");
         foreach(object o in requestMethodCallMessage.Args)
             Console.WriteLine("\t{0}", o);
         
         // Sends this method call message to another server to replicate
         // the call at the second server.
         if (requestMethodCallMessage.Uri == replicatedServiceUri) {
            
            SampleService replicationService = 
               (SampleService)Activator.GetObject(typeof(SampleService), 
               replicationServerUrl + replicatedServiceUri);
            
            IMethodReturnMessage returnMessage = 
               RemotingServices.ExecuteMessage(replicationService, requestMethodCallMessage);
            
            // Prints the results of the method call stored in the IMethodReturnMessage.
            Console.WriteLine("\nMessage returned by ExecuteMessage.");
            Console.WriteLine("\tException = {0}", returnMessage.Exception);
            Console.WriteLine("\tReturnValue = {0}", returnMessage.ReturnValue);
            Console.WriteLine("\tOutArgCount = {0}", returnMessage.OutArgCount);
            Console.WriteLine("Return message OutArgs");
            
            foreach(object o in requestMethodCallMessage.Args)
               Console.WriteLine("\t{0}", o);
         }
      }
      catch (InvalidCastException) {
          Console.WriteLine("The requestMessage is not a MethodCall");
      }
   }