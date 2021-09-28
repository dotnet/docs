

// System::Runtime::Remoting::Proxies.ProxyAttribute::CreateInstance;
// System::Runtime::Remoting::Proxies.ProxyAttribute::CreateProxy;
// System::Runtime::Remoting::Proxies.RealProxy::SetStubData;
// System::Runtime::Remoting::Proxies.RealProxy::Invoke;
// System::Runtime::Remoting::Proxies.RealProxy::InitializeServerObject;
// System::Runtime::Remoting::Proxies.RealProxy::CreateObjRef;
// System::Runtime::Remoting::Proxies.RealProxy::GetObjectData;
// System::Runtime::Remoting::Proxies.RealProxy::GetTransparentProxy;
// System::Runtime::Remoting::Proxies.RealProxy::GetStubData;
// System::Runtime::Remoting::Proxies.RealProxy::GetProxiedType;
// System::Runtime::Remoting::Proxies.ProxyAttribute;
// System::Runtime::Remoting::Proxies.RealProxy;

/* The following example demonstrates implementation of methods
'CreateInstance' and 'CreateProxy' of System::Runtime::Remoting::Proxies.ProxyAttribute and methods
'SetStubData', 'Invoke', 'InitializeServerObject', 'CreateObjRef', 'GetStubData', 'GetObjectData',
'GetTransparentProxy', 'GetProxiedType' of System::Runtime::Remoting::Proxies.RealProxy.

The following program has derived from'ProxyAttribute', 'RealProxy' classes. CustomProxy is implemented by deriving 
from 'RealProxy' and overriding 'Invoke' method. The new statement for 'CustomServer' class is intercepted to
derived 'CustomProxyAttribute' by setting 'ProxyAttribute' on the CustomServer class. Implementation of
'RealProxy' and 'ProxyAttribute' methods are shown.
*/

// <Snippet12>
using namespace System;
using namespace System::Collections;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Activation;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Proxies;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Remoting::Contexts;
using namespace System::Security::Permissions;

ref class CustomServer;

[SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::Infrastructure)]
public ref class MyProxy: public RealProxy
{
private:
   String^ myUri;
   MarshalByRefObject^ myMarshalByRefObject;

public:
   MyProxy()
      : RealProxy()
   {
      Console::WriteLine( "MyProxy Constructor Called..." );
      myMarshalByRefObject = dynamic_cast<MarshalByRefObject^>(Activator::CreateInstance( CustomServer::typeid ));
      ObjRef^ myObjRef = RemotingServices::Marshal( myMarshalByRefObject );
      myUri = myObjRef->URI;
   }

        MyProxy( Type^ type1 )
      : RealProxy( type1 )
   {
      Console::WriteLine( "MyProxy Constructor Called..." );
      myMarshalByRefObject = dynamic_cast<MarshalByRefObject^>(Activator::CreateInstance( type1 ));
      ObjRef^ myObjRef = RemotingServices::Marshal( myMarshalByRefObject );
      myUri = myObjRef->URI;
   }

   MyProxy( Type^ type1, MarshalByRefObject^ targetObject )
      : RealProxy( type1 )
   {
      Console::WriteLine( "MyProxy Constructor Called..." );
      myMarshalByRefObject = targetObject;
      ObjRef^ myObjRef = RemotingServices::Marshal( myMarshalByRefObject );
      myUri = myObjRef->URI;
   }

   // <Snippet4>
   // <Snippet5>
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
   // </Snippet5>
   // </Snippet4>

   // <Snippet6>
   virtual ObjRef^ CreateObjRef( Type^ ServerType ) override
   {
      Console::WriteLine( "CreateObjRef Method Called ..." );
      CustomObjRef ^ myObjRef = gcnew CustomObjRef( myMarshalByRefObject,ServerType );
      myObjRef->URI = myUri;
      return myObjRef;
   }
   // </Snippet6>

   // <Snippet7>
   [System::Security::Permissions::SecurityPermissionAttribute(
   System::Security::Permissions::SecurityAction::LinkDemand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual void GetObjectData( SerializationInfo^ info, StreamingContext context ) override
   {
      // Add your custom data if any here.
      RealProxy::GetObjectData( info, context );
   }
   // </Snippet7>

   [System::Security::Permissions::SecurityPermissionAttribute(
   System::Security::Permissions::SecurityAction::Demand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::SerializationFormatter)]
   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::InheritanceDemand, 
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   ref class CustomObjRef: public ObjRef
   {
   public:
      CustomObjRef( MarshalByRefObject^ myMarshalByRefObject, Type^ serverType )
         : ObjRef( myMarshalByRefObject, serverType )
      {
         Console::WriteLine( "ObjRef 'Constructor' called" );
      }

      // Override this method to store custom data.
      virtual void GetObjectData( SerializationInfo^ info, StreamingContext context ) override
      {
         ObjRef::GetObjectData( info, context );
      }
   };
};

// <Snippet11>
[AttributeUsageAttribute(AttributeTargets::Class)]
[System::Security::Permissions::SecurityPermissionAttribute
(System::Security::Permissions::SecurityAction::LinkDemand,
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
[System::Security::Permissions::SecurityPermissionAttribute
(System::Security::Permissions::SecurityAction::InheritanceDemand,
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
public ref class MyProxyAttribute: public ProxyAttribute
{
public:
   MyProxyAttribute(){}

   // <Snippet1>
   // Create an instance of ServicedComponentProxy
   virtual MarshalByRefObject^ CreateInstance( Type^ serverType ) override
   {
      return ProxyAttribute::CreateInstance( serverType );
   }
   // </Snippet1>

   // <Snippet2>
   // <Snippet3>
   virtual RealProxy^ CreateProxy( ObjRef^ objRef1, Type^ serverType, Object^ serverObject, Context^ serverContext ) override
   {
      MyProxy^ myCustomProxy = gcnew MyProxy( serverType );
      if ( serverContext != nullptr )
      {
         RealProxy::SetStubData( myCustomProxy, serverContext );
      }

      if ( ( !serverType->IsMarshalByRef) && (serverContext == nullptr) )
      {
         throw gcnew RemotingException( "Bad Type for CreateProxy" );
      }

      return myCustomProxy;
   }
   // </Snippet3>
   // </Snippet2>
};

[MyProxyAttribute]
ref class CustomServer: public ContextBoundObject
{
public:
   CustomServer()
   {
      Console::WriteLine( "CustomServer Base Class constructor called" );
   }

   void HelloMethod( String^ str )
   {
      Console::WriteLine( "HelloMethod of Server is invoked with message : {0}", str );
   }
};
// </Snippet11>

// Acts as a custom proxy user.
int main()
{
   Console::WriteLine( "" );
   Console::WriteLine( "CustomProxy Sample" );
   Console::WriteLine( "================" );
   Console::WriteLine( "" );
   
   // <Snippet8>
   // <Snippet9>
   // <Snippet10>
   // Create an instance of MyProxy.
   MyProxy^ myProxyInstance = gcnew MyProxy( CustomServer::typeid );
   
   // Get a CustomServer proxy.
   CustomServer^ myHelloServer = static_cast<CustomServer^>(myProxyInstance->GetTransparentProxy());
   // </Snippet10>

   // Get stubdata.
   Console::WriteLine( "GetStubData = {0}", RealProxy::GetStubData( myProxyInstance ) );
   // </Snippet9>

   // Get ProxyType.
   Console::WriteLine( "Type of object represented by RealProxy is : {0}", myProxyInstance->GetProxiedType() );
   // </Snippet8>

   myHelloServer->HelloMethod( "RealProxy Sample" );
   Console::WriteLine( "" );

   // Get a reference object from server.
   Console::WriteLine( "Create an objRef object to be marshalled across Application Domains..." );
   ObjRef^ CustomObjRef = myProxyInstance->CreateObjRef( CustomServer::typeid );
   Console::WriteLine( "URI of 'ObjRef' object = {0}", CustomObjRef->URI );
   return 0;
}
// </Snippet12>
