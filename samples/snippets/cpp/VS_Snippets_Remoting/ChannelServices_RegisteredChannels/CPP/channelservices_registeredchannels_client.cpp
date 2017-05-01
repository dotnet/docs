

// System.Runtime.Remoting.Channels.ChannelServices.GetUrlsForObject(MarshalByRefObject)
/*
The following example demonstrates the method 'GetUrlsForObject' 
of the class 'ChannelServices'. The example is just a client, it 
locates and connects to the server, retrieves a proxy for the remote 
object, and calls the 'HelloMethod' on the remote object, passing the 
string 'Caveman' as a parameter. The server returns the string
'Hi there Caveman'.  
*/
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <ChannelServices_RegisteredChannels_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Channels::Http;

int main()
{
   try
   {
      TcpChannel^ myTcpChannel = gcnew TcpChannel( 8084 );
      ChannelServices::RegisterChannel( myTcpChannel );
      RemotingSamples::HelloServer ^ myHelloServer = dynamic_cast<RemotingSamples::HelloServer^>(Activator::GetObject( RemotingSamples::HelloServer::typeid, "tcp://localhost:8080/SayHello" ));
      if ( myHelloServer == nullptr )
            System::Console::WriteLine( "Could not locate server" );
      else
      {
         
         // <Snippet4>
         array<String^>^myURLArray = ChannelServices::GetUrlsForObject( myHelloServer );
         Console::WriteLine( "Number of URLs for the specified Object: {0}", myURLArray->Length );
         for ( int iIndex = 0; iIndex < myURLArray->Length; iIndex++ )
            Console::WriteLine( "URL: {0}", myURLArray[ iIndex ] );
         // </Snippet4>

         Console::WriteLine( myHelloServer->HelloMethod( "Caveman" ) );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "The source of exception: {0}", e->Source );
      Console::WriteLine( "The Message of exception: {0}", e->Message );
   }
}
