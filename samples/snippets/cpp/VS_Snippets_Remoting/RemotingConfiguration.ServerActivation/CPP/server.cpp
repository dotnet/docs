// <Snippet1>
#using <System.Runtime.Remoting.dll>
#using <System.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

public ref class HelloServer: public MarshalByRefObject
{
private:
   static int n_called = 0;

public:
   static void Main()
   {
// </Snippet1>
// <Snippet2>
      // Registers the server and waits until the user hits enter.
      TcpChannel^ chan = gcnew TcpChannel( 8084 );
      ChannelServices::RegisterChannel( chan );

      RemotingConfiguration::RegisterWellKnownServiceType(
         Type::GetType( "HelloServer,server" ),
         "SayHello",
         WellKnownObjectMode::SingleCall );
      System::Console::WriteLine( L"Hit <enter> to exit..." );
      System::Console::ReadLine();
// </Snippet2>
// <Snippet3>
   }

   HelloServer()
   {
      Console::WriteLine( "HelloServer activated" );
   }

   ~HelloServer()
   {
      Console::WriteLine( "Object Destroyed" );
   }

   String^ HelloMethod( String^ name )
   {
      // Reports that the method was called.
      Console::WriteLine();
      Console::WriteLine( "Hello.HelloMethod : {0}", name );
      n_called++;
      Console::WriteLine( "The method was called {0} times.", n_called );
      
      // Calculates and returns the result to the client.
      return String::Format( "Hi there {0}", name );
   }
};
// </Snippet3>

int main()
{
   HelloServer::Main();
}
