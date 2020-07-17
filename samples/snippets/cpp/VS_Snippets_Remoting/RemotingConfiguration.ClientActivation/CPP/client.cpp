

// <Snippet1>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using "service.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   ChannelServices::RegisterChannel( gcnew TcpChannel );
   RemotingConfiguration::RegisterActivatedClientType( HelloServiceClass::typeid, "tcp://localhost:8082" );
   try
   {
      HelloServiceClass ^ service = gcnew HelloServiceClass;

      // Calls the remote method.
      Console::WriteLine();
      Console::WriteLine( "Calling remote Object" );
      Console::WriteLine( service->HelloMethod( "Caveman" ) );
      Console::WriteLine( service->HelloMethod( "Spaceman" ) );
      Console::WriteLine( service->HelloMethod( "Client Man" ) );
      Console::WriteLine( "Finished remote Object call" );
    }
    catch (Exception ex)
    {
        Console::WriteLine("An exception occurred: " + ex.Message);
    }
   Console::WriteLine();
   return 0;
}
// </Snippet1>
