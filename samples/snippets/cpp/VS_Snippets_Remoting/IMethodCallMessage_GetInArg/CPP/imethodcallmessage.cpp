

// System::Runtime::Remoting::IMethodCallMessage
// System::Runtime::Remoting::IMethodCallMessage.InArgCount
// System::Runtime::Remoting::IMethodCallMessage.InArgs
// System::Runtime::Remoting::IMethodCallMessage.GetArgName(int)
// System::Runtime::Remoting::IMethodCallMessage.GetInArg(int)
/*
The following example demonstrates 'GetInArg', 'GetArgName', 'InArgCount' and 'InArgs' 
members of 'IMethodCallMessage*' interface.
In this example custom proxy is accessed by passing message to the Invoke method.  
In invoke method check the type of message. If the type is IMethodCallMessage*, then
InArgCount, InArgs, GetArgName(int) and GetInArg(int) of the interface are displayed. 
This example also shows how to create a custom proxy.
*/
// <Snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Proxies;
using namespace System::Runtime::Remoting::Messaging;

// MyProxy extends the CLR Remoting RealProxy.
// In the same class, in the Invoke method, the methods and properties of the 
// IMethodCallMessage are demonstrated.

[System::Security::Permissions::SecurityPermissionAttribute
(System::Security::Permissions::SecurityAction::LinkDemand, 
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
[System::Security::Permissions::SecurityPermissionAttribute
(System::Security::Permissions::SecurityAction::InheritanceDemand, 
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]

public ref class MyProxy: public RealProxy
{
public:
   MyProxy( Type^ myType )
      : RealProxy( myType )
   {
      // This constructor forwards the call to base RealProxy.
      // RealProxy uses the Type to generate a transparent proxy.
   }

   // <Snippet2>
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
// </Snippet2>

// Main routine that drives the whole sample.
int main()
{
   Console::WriteLine( "Generate a new MyProxy." );
   MyProxy^ myProxy = gcnew MyProxy( MyMarshalByRefClass::typeid );
   Console::WriteLine( "Obtain the transparent proxy from myProxy." );
   MyMarshalByRefClass^ myMarshalByRefClassObj = dynamic_cast<MyMarshalByRefClass^>(myProxy->GetTransparentProxy());
   Console::WriteLine( "Calling the Proxy." );
   Object^ myReturnValue = myMarshalByRefClassObj->MyMethod( "Microsoft", 1.2, 6 );
   Console::WriteLine( "Sample Done." );
   return 0;
}
// </Snippet1>
