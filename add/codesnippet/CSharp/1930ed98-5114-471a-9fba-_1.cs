      public override IMessage Invoke(IMessage myMessage)
      {
         Console.WriteLine("MyProxy 'Invoke method' Called...");
         if (myMessage is IMethodCallMessage)
         {
            Console.WriteLine("IMethodCallMessage");
         }
         if (myMessage is IMethodReturnMessage)
         {
            Console.WriteLine("IMethodReturnMessage");
         }
         if (myMessage is IConstructionCallMessage)
         {  
            // Initialize a new instance of remote object
            IConstructionReturnMessage myIConstructionReturnMessage = 
               this.InitializeServerObject((IConstructionCallMessage)myMessage);
            ConstructionResponse constructionResponse = new 
               ConstructionResponse(null,(IMethodCallMessage) myMessage);
            return constructionResponse;
         }
         IDictionary myIDictionary = myMessage.Properties;
         IMessage returnMessage;
         myIDictionary["__Uri"] = myUri;

         // Synchronously dispatch messages to server.
         returnMessage = ChannelServices.SyncDispatchMessage(myMessage);
         // Pushing return value and OUT parameters back onto stack.
         IMethodReturnMessage myMethodReturnMessage = (IMethodReturnMessage)returnMessage;
         return returnMessage;
      }