   virtual IMessage^ Invoke( IMessage^ myMessage ) override
   {
      IMethodCallMessage^ myCallMessage = (IMethodCallMessage^)( myMessage );

      IMethodReturnMessage^ myIMethodReturnMessage =
         RemotingServices::ExecuteMessage( myMarshalByRefObject, myCallMessage );

      Console::WriteLine( "Method name : {0}", myIMethodReturnMessage->MethodName );
      Console::WriteLine( "The return value is : {0}", myIMethodReturnMessage->ReturnValue );

      // Get number of 'ref' and 'out' parameters.
      int myArgOutCount = myIMethodReturnMessage->OutArgCount;
      Console::WriteLine( "The number of 'ref', 'out' parameters are : {0}",
         myIMethodReturnMessage->OutArgCount );
      // Gets name and values of 'ref' and 'out' parameters.
      for ( int i = 0; i < myArgOutCount; i++ )
      {
         Console::WriteLine( "Name of argument {0} is '{1}'.",
            i, myIMethodReturnMessage->GetOutArgName( i ) );
         Console::WriteLine( "Value of argument {0} is '{1}'.",
            i, myIMethodReturnMessage->GetOutArg( i ) );
      }
      Console::WriteLine();
      array<Object^>^myObjectArray = myIMethodReturnMessage->OutArgs;
      for ( int i = 0; i < myObjectArray->Length; i++ )
         Console::WriteLine( "Value of argument {0} is '{1}' in OutArgs",
            i, myObjectArray[ i ] );
      return myIMethodReturnMessage;
   }