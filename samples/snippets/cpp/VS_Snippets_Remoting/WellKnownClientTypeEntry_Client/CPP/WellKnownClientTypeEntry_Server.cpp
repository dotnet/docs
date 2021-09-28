// This is the server program for the 'WellKnownClientTypeEntry_Client.cpp' program.

#using <system.runtime.remoting.dll>
#using <WellKnownClientTypeEntry_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;

using namespace System::Runtime::Remoting::Channels::Http;

public ref class MyServer 
{
public:
   static void Run() 
   {
      ChannelServices::RegisterChannel(gcnew HttpChannel(8086));
      // Record the 'HelloServer' type as 'Singleton' well-known type.
      WellKnownServiceTypeEntry^ myWellKnownServiceTypeEntry= 
          gcnew WellKnownServiceTypeEntry(HelloServer::typeid,
                                        "SayHello",
                                        WellKnownObjectMode::Singleton);
      RemotingConfiguration::RegisterWellKnownServiceType(
                                          myWellKnownServiceTypeEntry);
      Console::WriteLine("Started the Server, Hit <enter> to exit...");
      Console::ReadLine();
   }
};

int main()
{
   MyServer::Run();
}