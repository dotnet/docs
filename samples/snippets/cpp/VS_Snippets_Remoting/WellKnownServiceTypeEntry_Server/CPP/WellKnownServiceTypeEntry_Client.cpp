// This is the client program for the 'WellKnownServiceTypeEntry_Server.cs' program.

using namespace System;
using namespace System::Runtime::Remoting;
#using <System.Runtime.Remoting.dll>
#using <WellKnownServiceTypeEntry_Share.dll>

using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;

public ref class MyClient 
{
public:
   static void Run()
   {
      ChannelServices::RegisterChannel(gcnew HttpChannel());
      Console::WriteLine(" Start calling from Client One.......");
      WellKnownClientTypeEntry^ myWellKnownClientTypeEntry = 
                     gcnew WellKnownClientTypeEntry(HelloServer::typeid,
                                     "http://localhost:8086/SayHello");
      myWellKnownClientTypeEntry->ApplicationUrl="http://localhost:8086/SayHello";
      RemotingConfiguration::RegisterWellKnownClientType(myWellKnownClientTypeEntry);
      HelloServer^ myHelloServerObject = gcnew HelloServer();
      for (int i = 0; i < 5; i++) 
         Console::WriteLine(myHelloServerObject->HelloMethod(" Client One"));
   }
};

int main()
{
   MyClient::Run();
}