   virtual IMessage^ Invoke( IMessage^ myMessage ) override
   {
      IMethodCallMessage^ myCallMessage = dynamic_cast<IMethodCallMessage^>(myMessage);

      IMethodReturnMessage^ myIMethodReturnMessage =
         RemotingServices::ExecuteMessage( myMarshalByRefObject, myCallMessage );
      if ( myIMethodReturnMessage->Exception != nullptr )
      {
         Console::WriteLine( "{0} raised an exception.",
            myIMethodReturnMessage->MethodName );
      }
      else
      {
         Console::WriteLine(  "{0} does not raise an exception.",
            myIMethodReturnMessage->MethodName );
      }

      return myIMethodReturnMessage;
   }