   virtual IMessage^ Invoke( IMessage^ myMessage ) override
   {
      Console::WriteLine( "MyProxy 'Invoke method' Called..." );
      if ( dynamic_cast<IMethodCallMessage^>(myMessage) )
      {
         Console::WriteLine( "IMethodCallMessage*" );
      }

      if ( dynamic_cast<IMethodReturnMessage^>(myMessage) )
      {
         Console::WriteLine( "IMethodReturnMessage*" );
      }

      if ( dynamic_cast<IConstructionCallMessage^>(myMessage) )
      {
         // Initialize a new instance of remote object
         IConstructionReturnMessage^ myIConstructionReturnMessage = this->InitializeServerObject( static_cast<IConstructionCallMessage^>(myMessage) );
         ConstructionResponse^ constructionResponse = gcnew ConstructionResponse( nullptr,static_cast<IMethodCallMessage^>(myMessage) );
         return constructionResponse;
      }

      IDictionary^ myIDictionary = myMessage->Properties;
      IMessage^ returnMessage;
      myIDictionary[ "__Uri" ] = myUri;

      // Synchronously dispatch messages to server.
      returnMessage = ChannelServices::SyncDispatchMessage( myMessage );

      // Pushing return value and OUT parameters back onto stack.
      IMethodReturnMessage^ myMethodReturnMessage = dynamic_cast<IMethodReturnMessage^>(returnMessage);
      return returnMessage;
   }