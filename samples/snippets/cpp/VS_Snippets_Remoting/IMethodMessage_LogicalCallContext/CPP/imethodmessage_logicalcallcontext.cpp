// System::Runtime::Remoting::Messaging.IMethodMessage*.LogicalCallContext
// System::Runtime::Remoting::Messaging.IMethodMessage*.Uri

/*
The program demonstrates the 'LogicalCallContext' and 'Uri' properties of 
the IMethodMessage* interface.
In the program a remote Object* is created with a method by extending 'MarshalByRefObject'.
A custom proxy is created by extending 'RealProxy' and overriding 'Invoke' 
method of 'RealProxy'. In this example custom proxy is accessed by passing message 
to the Invoke method. Then the values of 'Uri' and 'LogicalCallContext' properties
are displayed to the console.
*/

#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Proxies;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Security::Permissions;

// MyProxy extends the CLR Remoting RealProxy.
// This demonstrate the RealProxy extensiblity.
// <Snippet1>
//This sample requires full trust
[PermissionSetAttribute(SecurityAction::Demand, Name = "FullTrust")]
public ref class MyProxy: public RealProxy
{
private:
   String^ stringUri;
   MarshalByRefObject^ targetObject;

public:
   MyProxy( Type^ type )
      : RealProxy( type )
   {
      targetObject = dynamic_cast<MarshalByRefObject^>(Activator::CreateInstance( type ));
      ObjRef^ myObject = RemotingServices::Marshal( targetObject );
      stringUri = myObject->URI;
   }

   MyProxy( Type^ type, MarshalByRefObject^ targetObject )
      : RealProxy( type )
   {
      this->targetObject = targetObject;
   }

   // <Snippet2>
   virtual IMessage^ Invoke( IMessage^ message ) override
   {
      message->Properties[ "__Uri" ] = stringUri;
      IMethodMessage^ myMethodMessage = dynamic_cast<IMethodMessage^>(ChannelServices::SyncDispatchMessage( message ));
      Console::WriteLine( "---------IMethodMessage* example-------" );
      Console::WriteLine( "Method name : {0}", myMethodMessage->MethodName );
      Console::WriteLine( "LogicalCallContext has information : {0}", myMethodMessage->LogicalCallContext->HasInfo );
      Console::WriteLine( "Uri : {0}", myMethodMessage->Uri );
      return myMethodMessage;
   }
   // </Snippet2>
};
// </Snippet1>


[AttributeUsage(AttributeTargets::Class)]
[PermissionSetAttribute(SecurityAction::Demand, Name = "FullTrust")]
public ref class MyProxyAttribute: public ProxyAttribute
{
public:
   MyProxyAttribute(){}

   virtual MarshalByRefObject^ CreateInstance( Type^ serverType ) override
   {
      if ( serverType->IsMarshalByRef )
      {
         MarshalByRefObject^ targetObject = dynamic_cast<MarshalByRefObject^>(Activator::CreateInstance( serverType ));
         MyProxy^ proxy = gcnew MyProxy( serverType,targetObject );
         return dynamic_cast<MarshalByRefObject^>(proxy->GetTransparentProxy());
      }
      else
         throw gcnew Exception( "Proxies only work on MarshalByRefObject objects  and their children" );
   }
};

public ref class Zip: public MarshalByRefObject, public ILogicalThreadAffinative
{
public:
   Zip(){}

   int Method1( int i )
   {
      return i;
   }
};

int main()
{
   MyProxy^ proxy = gcnew MyProxy( Zip::typeid );
   Zip^ myZip = dynamic_cast<Zip^>(proxy->GetTransparentProxy());
   CallContext::SetData( "USER", gcnew Zip );
   myZip->Method1( 6 );
   return 0;
}
