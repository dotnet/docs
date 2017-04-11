

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
using namespace System::Collections;
using namespace SampleNamespace;

int main()
{
   ChannelServices::RegisterChannel( gcnew HttpChannel( 0 ), false );
   RemotingConfiguration::RegisterActivatedClientType( SampleService::typeid, "http://localhost:9000/MySampleService" );
   SampleService ^ myRemoteObject = gcnew SampleService;
   bool result = myRemoteObject->SampleMethod();

   // System::Runtime::Remoting::RemotingServices.GetObjRefForProxy
   // <Snippet1>
   ObjRef^ objRefSample = RemotingServices::GetObjRefForProxy( myRemoteObject );
   Console::WriteLine( "***ObjRef Details***" );
   Console::WriteLine( "URI:\t {0}", objRefSample->URI );
   array<Object^>^channelData = objRefSample->ChannelInfo->ChannelData;
   Console::WriteLine( "Channel Info:" );
   IEnumerator^ myEnum = channelData->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ o = safe_cast<Object^>(myEnum->Current);
      Console::WriteLine( "\t {0}", o );
   }

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
   Console::WriteLine( "Can my Object* cast to a Bitmap? {0}", typeInfo->CanCastTo( System::Drawing::Bitmap::typeid, objRefSample ) );
   // </Snippet1>
}
