// System::Runtime::Remoting::Messaging.IMethodMessage*
// System::Runtime::Remoting::Messaging.IMethodMessage*.MethodName
// System::Runtime::Remoting::Messaging.IMethodMessage*.ArgCount
// System::Runtime::Remoting::Messaging.IMethodMessage*.GetArgName
// System::Runtime::Remoting::Messaging.IMethodMessage*.GetArg
// System::Runtime::Remoting::Messaging.IMethodMessage*.HasVarArgs
// System::Runtime::Remoting::Messaging.IMethodMessage*.Args

/*
The following program demonstrates the 'MethodName', 'ArgCount', 'HasVarArgs',
'Args' properties, 'GetArgName', 'GetArg' methods of 'IMethodMessage*' interface and
'IMethodMessage*' interface.
In this example custom proxy is accessed by passing message to the Invoke method.
The Invoke method calls the methods and properties of 'IMethodMessage*' interface
and displays the result to the console.
*/

using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::Remoting::Proxies;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Security::Permissions;

public ref class Reverser: public MarshalByRefObject
{
private:
   String^ stringReversed;

public:
   String^ GetReversedString()
   {
      return stringReversed;
   }

   void SetString( String^ temp )
   {
      DoReverse( temp );
   }

private:

   // Exposed reverse as a method to reverse a String*.
   void DoReverse( String^ argString )
   {
      stringReversed = "";
      for ( int i = argString->Length - 1; i >= 0; i-- )
      {
         stringReversed += argString[i];
      }
   }
};

// <Snippet1>
// This class requires full trust
[PermissionSetAttribute(SecurityAction::Demand, Name = "FullTrust")]
public ref class MyProxyClass: public RealProxy
{
private:
   Object^ myObjectInstance;
   Type^ myType;

public:
   MyProxyClass( Type^ argType )
      : RealProxy( argType )
   {
      myType = argType;
      myObjectInstance = Activator::CreateInstance( argType );
   }

   // <Snippet2>
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
   // </Snippet2>
};
// </Snippet1>

int main()
{
   MyProxyClass^ myProxy = gcnew MyProxyClass( Reverser::typeid );
   
   // The real proxy dynamically creates a transparent proxy.
   Reverser^ myReverser = dynamic_cast<Reverser^>(myProxy->GetTransparentProxy());
   myReverser->SetString( "Hello World!" );
   Console::WriteLine( "The [Out] result is : {0}", myReverser->GetReversedString() );
   return 0;
}
