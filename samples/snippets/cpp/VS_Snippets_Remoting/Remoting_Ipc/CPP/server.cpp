
// <snippet10>
#using <system.runtime.remoting.dll>
#using <System.dll>
#using <Counter.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Ipc;

public ref class IpcServer
{
public:
   void IpcServerTest()
   {
      // <snippet11>
      // Create and register an IPC channel
      IpcServerChannel^ serverChannel = gcnew IpcServerChannel( L"remote" );
      ChannelServices::RegisterChannel( serverChannel );
      // </snippet11>

      // Expose an object
      RemotingConfiguration::RegisterWellKnownServiceType( Counter::typeid, L"counter", WellKnownObjectMode::Singleton );
      
      // Wait for calls
      // <snippet12>
      Console::WriteLine( L"Listening on {0}", serverChannel->GetChannelUri() );
      // </snippet12>

      Console::ReadLine();
   }
};

int main()
{
   IpcServer^ is = gcnew IpcServer;
   is->IpcServerTest();
}
// </snippet10>
