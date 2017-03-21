   virtual IMessage^ Invoke( IMessage^ myIMessage ) override
   {
      Console::WriteLine( "MyProxy::Invoke Start" );
      Console::WriteLine( "" );
      ReturnMessage^ myReturnMessage = nullptr;
      if ( dynamic_cast<IMethodCallMessage^>(myIMessage) )
      {
         Console::WriteLine( "Message is of type 'IMethodCallMessage*'." );
         Console::WriteLine( "" );
         IMethodCallMessage^ myIMethodCallMessage;
         myIMethodCallMessage = dynamic_cast<IMethodCallMessage^>(myIMessage);
         Console::WriteLine( "InArgCount is  : {0}", myIMethodCallMessage->InArgCount );
         IEnumerator^ myEnum = myIMethodCallMessage->InArgs->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Object^ myObj = safe_cast<Object^>(myEnum->Current);
            Console::WriteLine( "InArgs is : {0}", myObj );
         }

         for ( int i = 0; i < myIMethodCallMessage->InArgCount; i++ )
         {
            Console::WriteLine( "GetArgName({0}) is : {1}", i, myIMethodCallMessage->GetArgName( i ) );
            Console::WriteLine( "GetInArg({0}) is : {0}", i, myIMethodCallMessage->GetInArg( i ) );

         }
         Console::WriteLine( "" );
      }
      else
      if ( dynamic_cast<IMethodReturnMessage^>(myIMessage) )
            Console::WriteLine( "Message is of type 'IMethodReturnMessage*'." );

      // Build Return Message 
      myReturnMessage = gcnew ReturnMessage( 5,nullptr,0,nullptr,dynamic_cast<IMethodCallMessage^>(myIMessage) );
      Console::WriteLine( "MyProxy::Invoke - Finish" );
      return myReturnMessage;
   }
};

// The class used to obtain Metadata.
public ref class MyMarshalByRefClass: public MarshalByRefObject
{
public:
   int MyMethod( String^ str, double dbl, int i )
   {
      Console::WriteLine( "MyMarshalByRefClass::MyMethod {0} {1} {2}", str, dbl, i );
      return 0;
   }

};