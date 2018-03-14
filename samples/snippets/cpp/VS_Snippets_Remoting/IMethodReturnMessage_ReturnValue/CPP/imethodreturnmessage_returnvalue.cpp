// System::Runtime::Remoting::Messaging.IMethodReturnMessage*
// System::Runtime::Remoting::Messaging.IMethodReturnMessage*.OutArgs
// System::Runtime::Remoting::Messaging.IMethodReturnMessage*.ReturnValue
// System::Runtime::Remoting::Messaging.IMethodReturnMessage*.OutArgCount
// System::Runtime::Remoting::Messaging.IMethodReturnMessage*.GetOutArg
// System::Runtime::Remoting::Messaging.IMethodReturnMessage*.GetOutArgName

/*
The following example demonstrates 'ReturnValue', 'OutArgCount' properties,
'GetOutArg', 'GetOutArgName' methods of 'IMethodReturnMessage*' interface 
and 'IMethodReturnMessage*' interface.
A custom proxy is created by extending 'RealProxy' and overriding 'Invoke' method of
'RealProxy'. The custom proxy is accessed by passing message to the Invoke method.
The Invoke method calls properties of 'IMethodReturnMessage*' interface and
prints the values to the console.
*/

#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Proxies;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::InteropServices;

public ref class CustomServer: public MarshalByRefObject
{
public:
   String^ HelloMethod( String^ myString, interior_ptr<double> myDoubleValue,
      [Out]interior_ptr<int> myIntValue )
   {
       *myIntValue = 100;
      return myString;
   }
};

// <Snippet1>
[System::Security::Permissions::SecurityPermissionAttribute
(System::Security::Permissions::SecurityAction::LinkDemand, 
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
[System::Security::Permissions::SecurityPermissionAttribute
(System::Security::Permissions::SecurityAction::InheritanceDemand, 
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
public ref class MyProxy: public RealProxy
{
private:
   String^ stringUri;
   MarshalByRefObject^ myMarshalByRefObject;

public:
   MyProxy( Type^ myType ) : RealProxy( myType )
   {
      myMarshalByRefObject = dynamic_cast<MarshalByRefObject^>(Activator::CreateInstance( myType ));
      ObjRef^ myObject = RemotingServices::Marshal( myMarshalByRefObject );
      stringUri = myObject->URI;
   }

   // <Snippet2>
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
   // </Snippet2>
};
// </Snippet1>

int main()
{
   // Create an instance of MyProxy.
   MyProxy^ myCustomProxy = gcnew MyProxy( CustomServer::typeid );
   // Get an instance of remote class.
   CustomServer^ myHelloServer =
      (CustomServer^)( myCustomProxy->GetTransparentProxy() );
   double myDoubleValue = 10.5;
   int myIntValue = 200;
   // Invoke the remote method.
   myHelloServer->HelloMethod( "Hello", &myDoubleValue, &myIntValue );
}
