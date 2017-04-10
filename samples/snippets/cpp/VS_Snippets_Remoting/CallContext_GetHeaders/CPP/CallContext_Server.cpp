#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using <callcontext_share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

namespace RemotingSamples
{
   ref class HelloServer
   {
   public:
      static void Main()
      {
         TcpChannel^ myChannel = gcnew TcpChannel( 8082 );
         ChannelServices::RegisterChannel( myChannel );
         RemotingConfiguration::RegisterActivatedServiceType( HelloService::typeid );
         Console::WriteLine( "Server started." );
         Console::WriteLine( "Hit enter to terminate..." );
         Console::Read();
      }
   };
}

int main()
{
   RemotingSamples::HelloServer::Main();
}

