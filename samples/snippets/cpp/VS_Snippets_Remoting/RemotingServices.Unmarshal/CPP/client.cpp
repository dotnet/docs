// System::Runtime::Remoting::RemotingServices.GetLifetimeService
// This sample is of a remote client for a group coffee timer.
// Since the client must stay connected to a stateful server Object*
// for minutes with->Item[Out] calling* it, it needs to register as a sponsor
// of the lease to prevent the server from being collected.
// Multiple clients can connect to the same timer Object*, and receive
// notification when the timer expires.

#using <system.dll>
#using <system.runtime.remoting.dll>
#using "service.dll"

using namespace System;
using namespace System::Net::Sockets;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Remoting::Lifetime;
using namespace SampleNamespace;

int main()
{
   // System::Runtime::Remoting::RemotingServices.Unmarshal
   // <Snippet2>
   ChannelServices::RegisterChannel( gcnew HttpChannel );

   SampleService ^ objectSample = (SampleService^)( Activator::GetObject( SampleService::typeid,
      "http://localhost:9000/MySampleService/SampleService.soap" ) );
   
   // The GetManuallyMarshaledObject() method uses RemotingServices::Marshal()
   // to create an ObjRef object for a SampleTwo object.
   ObjRef^ objRefSampleTwo = objectSample->GetManuallyMarshaledObject();

   SampleTwo ^ objectSampleTwo = (SampleTwo^)( RemotingServices::Unmarshal( objRefSampleTwo ) );

   objectSampleTwo->PrintMessage( "ObjRef successfuly unmarshaled." );
   // </Snippet2>
}
