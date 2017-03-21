   // Overriding the Invoke method of RealProxy.
   virtual IMessage^ Invoke( IMessage^ message ) override
   {
      IMethodMessage^ myMethodMessage = dynamic_cast<IMethodMessage^>(message);
      Console::WriteLine( "**** Begin Invoke ****" );
      Console::WriteLine( "\tType is : {0}", myType );
      Console::WriteLine( "\tMethod name : {0}", myMethodMessage->MethodName );
      for ( int i = 0; i < myMethodMessage->ArgCount; i++ )
      {
         Console::WriteLine( "\tArgName is : {0}", myMethodMessage->GetArgName( i ) );
         Console::WriteLine( "\tArgValue is: {0}", myMethodMessage->GetArg( i ) );

      }
      if ( myMethodMessage->HasVarArgs )
            Console::WriteLine( "\t The method have variable arguments!!" );
      else
            Console::WriteLine( "\t The method does not have variable arguments!!" );

      
      // Dispatch the method call to the real Object*.
      Object^ returnValue = myType->InvokeMember( myMethodMessage->MethodName, BindingFlags::InvokeMethod, nullptr, myObjectInstance, myMethodMessage->Args );
      Console::WriteLine( "**** End Invoke ****" );
      
      // Build the return message to pass back to the transparent proxy.
      ReturnMessage^ myReturnMessage = gcnew ReturnMessage( returnValue,nullptr,0,nullptr,dynamic_cast<IMethodCallMessage^>(message) );
      return myReturnMessage;
   }