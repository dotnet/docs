// System::Runtime::Remoting::Messaging.IMethodReturnMessage*.Exception

/*
The following example demonstrates 'Exception' property of 'IMethodReturnMessage*'interface.
A 'CustomServer' class is defined extending 'MarshalByRefObject'. A custom proxy
is created by extending 'RealProxy' and overriding 'Invoke' method of 'RealProxy'.
The Invoke method calls the methods and properties of 'IMethodMessage*' interface
and display the 'Exception' property value of 'IMethodReturnMessage*' interface to
the console.
*/

#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Proxies;
using namespace System::Runtime::Remoting::Messaging;

public ref class CustomServer: public MarshalByRefObject
{
public:
   void RaiseException()
   {
      throw gcnew Exception( "Raising an exception." );
   }
};

[System::Security::Permissions::SecurityPermissionAttribute
(System::Security::Permissions::SecurityAction::LinkDemand, 
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
[System::Security::Permissions::SecurityPermissionAttribute
(System::Security::Permissions::SecurityAction::InheritanceDemand, 
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
public ref class MyProxy: public RealProxy
{
private:
   String^ _URI;
   MarshalByRefObject^ myMarshalByRefObject;

public:
   MyProxy( Type^ myType ) : RealProxy( myType )
   {
      myMarshalByRefObject = dynamic_cast<MarshalByRefObject^>(Activator::CreateInstance( myType ));
      ObjRef^ myObjRef = RemotingServices::Marshal( myMarshalByRefObject );
      _URI = myObjRef->URI;
   }

   // <Snippet1>
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
   // </Snippet1>
};

int main()
{
   // Create an instance of MyProxy.
   MyProxy^ myCustomProxy = gcnew MyProxy( CustomServer::typeid );
   // Get an instance of remote class.
   CustomServer^ myHelloServer = dynamic_cast<CustomServer^>(myCustomProxy->GetTransparentProxy());
   try
   {
      // Invoke remote method.
      myHelloServer->RaiseException();
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
