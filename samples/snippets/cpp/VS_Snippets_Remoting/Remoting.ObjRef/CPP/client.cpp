

#using <system.dll>
#using <system.runtime.remoting.dll>
#using <system.drawing.dll>
#using "service.dll"

using namespace System;
using namespace System::Net::Sockets;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Remoting::Lifetime;
using namespace System::Runtime::Remoting::Contexts;
using namespace System::Runtime::Serialization;
using namespace System::Collections;
using namespace SampleNamespace;

int main()
{
   ChannelServices::RegisterChannel( gcnew HttpChannel( 0 ) );
   RemotingConfiguration::RegisterActivatedClientType( SampleService::typeid, "http://localhost:9000/MySampleService" );
   SampleService ^ myRemoteObject = gcnew SampleService;
   bool result = myRemoteObject->SampleMethod();

   // System::Runtime::Remoting::ObjRef
   // <Snippet1>
   ObjRef^ objRefSample = RemotingServices::GetObjRefForProxy( myRemoteObject );
   Console::WriteLine( "***ObjRef Details***" );
   Console::WriteLine( "URI:\t {0}", objRefSample->URI );
   array<Object^>^channelData = objRefSample->ChannelInfo->ChannelData;
   Console::WriteLine( "Channel Info:" );
   for each(Object^ o in channelData)
      Console::WriteLine("\t{0}", o->ToString());
   IEnvoyInfo^ envoyInfo = objRefSample->EnvoyInfo;
   if ( envoyInfo == nullptr )
   {
      Console::WriteLine( "This ObjRef does not have envoy information." );
   }
   else
   {
      IMessageSink^ envoySinks = envoyInfo->EnvoySinks;
      Console::WriteLine( "Envoy Sink Class: {0}", envoySinks );
   }
   IRemotingTypeInfo^ typeInfo = objRefSample->TypeInfo;
   Console::WriteLine( "Remote type name: {0}", typeInfo->TypeName );
   Console::WriteLine( "Can my Object cast to a Bitmap? {0}", typeInfo->CanCastTo( System::Drawing::Bitmap::typeid, objRefSample ) );
   Console::WriteLine( "Is this Object from this AppDomain? {0}", objRefSample->IsFromThisAppDomain() );
   Console::WriteLine( "Is this Object from this process? {0}", objRefSample->IsFromThisProcess() );
   // </Snippet1>

   return 0;
}