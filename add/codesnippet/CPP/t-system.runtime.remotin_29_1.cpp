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
      // Create and register an IPC channel
      IpcServerChannel^ serverChannel = gcnew IpcServerChannel( L"remote" );
      ChannelServices::RegisterChannel( serverChannel );

      // Expose an object
      RemotingConfiguration::RegisterWellKnownServiceType( Counter::typeid, L"counter", WellKnownObjectMode::Singleton );
      
      // Wait for calls
      Console::WriteLine( L"Listening on {0}", serverChannel->GetChannelUri() );

      Console::ReadLine();
   }
};

int main()
{
   IpcServer^ is = gcnew IpcServer;
   is->IpcServerTest();
}