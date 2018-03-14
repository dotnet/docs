
#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Serialization;

// <Snippet1>
// a custom ObjRef class that outputs its status
[System::Security::Permissions::SecurityPermissionAttribute(
   System::Security::Permissions::SecurityAction::Demand, 
   Flags=System::Security::Permissions::SecurityPermissionFlag::SerializationFormatter)]
[System::Security::Permissions::SecurityPermissionAttribute
(System::Security::Permissions::SecurityAction::Demand, 
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]	
[System::Security::Permissions::SecurityPermissionAttribute
(System::Security::Permissions::SecurityAction::InheritanceDemand, 
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
public ref class MyObjRef: public ObjRef
{
private:

   // only instantiate using marshaling or deserialization
   MyObjRef(){}

public:
   MyObjRef( MarshalByRefObject^ o, Type^ t )
      : ObjRef( o, t )
   {
      Console::WriteLine( "Created MyObjRef." );
      ORDump();
   }

   MyObjRef( SerializationInfo^ i, StreamingContext c )
      : ObjRef( i, c )
   {
      Console::WriteLine( "Deserialized MyObjRef." );
   }

   virtual void GetObjectData( SerializationInfo^ s, StreamingContext c ) override
   {
      // After calling the base method, change the type from ObjRef to MyObjRef
      ObjRef::GetObjectData( s, c );
      s->SetType( GetType() );
      Console::WriteLine( "Serialized MyObjRef." );
   }

   virtual Object^ GetRealObject( StreamingContext context ) override
   {
      if ( IsFromThisAppDomain() || IsFromThisProcess() )
      {
         Console::WriteLine( "Returning actual Object^ referenced by MyObjRef." );
         return ObjRef::GetRealObject( context );
      }
      else
      {
         Console::WriteLine( "Returning proxy to remote Object^." );
         return RemotingServices::Unmarshal( this );
      }
   }

   void ORDump()
   {
      Console::WriteLine( " --- Reporting MyObjRef Info --- " );
      Console::WriteLine( "Reference to {0}.", TypeInfo->TypeName );
      Console::WriteLine( "URI is {0}.", URI );
      Console::WriteLine( "\nWriting EnvoyInfo: " );
      if ( EnvoyInfo != nullptr )
      {
         IMessageSink^ EISinks = EnvoyInfo->EnvoySinks;
         while ( EISinks != nullptr )
         {
            Console::WriteLine( "\tSink: {0}", EISinks );
            EISinks = EISinks->NextSink;
         }
      }
      else
            Console::WriteLine( "\t {no sinks}" );

      Console::WriteLine( "\nWriting ChannelInfo: " );
      for ( int i = 0; i < ChannelInfo->ChannelData->Length; i++ )
         Console::WriteLine( "\tChannel: {0}", ChannelInfo->ChannelData[ i ] );
      Console::WriteLine( " ----------------------------- " );
   }

};

// a class that uses MyObjRef
public ref class LocalObject: public MarshalByRefObject
{
public:

   // overriding CreateObjRef will allow us to return a custom ObjRef
   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual ObjRef^ CreateObjRef( Type^ t ) override
   {
      return gcnew MyObjRef( this,t );
   }
};
// </Snippet1>

// <Snippet2>
#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Serialization;

public ref class RemoteObject: public MarshalByRefObject
{
public:
   void Method1( LocalObject^ param )
   {
      Console::WriteLine( "Invoked: Method1( {0})", param );
   }
};

int main()
{
   ChannelServices::RegisterChannel( gcnew HttpChannel( 8090 ) );
   WellKnownServiceTypeEntry^ wkste = gcnew WellKnownServiceTypeEntry( RemoteObject::typeid,"RemoteObject",WellKnownObjectMode::Singleton );
   RemotingConfiguration::RegisterWellKnownServiceType( wkste );
   RemoteObject^ RObj = dynamic_cast<RemoteObject^>(Activator::GetObject( RemoteObject::typeid, "http://localhost:8090/RemoteObject" ));
   LocalObject^ LObj = gcnew LocalObject;
   RObj->Method1( LObj );
   Console::WriteLine( "Press Return to exit..." );
   Console::ReadLine();
}
// </Snippet2>
