#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;
using namespace System::Threading;

void main()
{
   const int portNumber = 13;
   
   //<Snippet1>  
   try
   {
      // Use the Pending method to poll the underlying socket instance for client connection requests.
      TcpListener^ tcpListener = gcnew TcpListener( portNumber );
      tcpListener->Start();

      if ( !tcpListener->Pending() )
      {
         Console::WriteLine( "Sorry, no connection requests have arrived" );
      }
      else
      {
         //Accept the pending client connection and return a TcpClient object^ initialized for communication.
         TcpClient^ tcpClient = tcpListener->AcceptTcpClient();
         
         // Using the RemoteEndPoint property.
         Console::WriteLine( "I am listening for connections on {0} on port number {1}",
            IPAddress::Parse( ( (IPEndPoint^)(tcpListener->LocalEndpoint) )->Address->ToString() ),
            ( (IPEndPoint^)(tcpListener->LocalEndpoint) )->Port );
         //</Snippet1>

         //Close the tcpListener and tcpClient instances
         tcpClient->Close();
      }
      tcpListener->Stop();
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->ToString() );
   }
}
