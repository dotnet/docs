/*
This program demonstrates the 'AcceptList' property  of 'SocketPermission' class.

This program provides a class called 'DateServer' that functions as a server
for a 'DateClient'. A 'DateServer' is a server that provides the current date on
the server in response to a request from a client. The 'DateServer' class
provides a method called 'Create' which waits for client connections and sends
the current date on that socket connection. Within the 'Create' method of
'DateServer' class an instance of 'SocketPermission' is created with the
'SocketPermission(NetworkAccess, TransportType, String*, int)' constructor.
If the calling method has the requisite permissions the 'Create' method waits
for client connections and sends the current date on the socket connection.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;
using namespace System::Security;
using namespace System::Collections;

void PrintUsage()
{
   Console::WriteLine( "Usage : DateServer_SocketPermission" );
   Console::WriteLine( "\tDateServer_SocketPermission <port>" );
   Console::WriteLine( "\tport is the port on which the DateServer is listening" );
}

public ref class DateServer
{
private:

   // Client connecting to the date server.
   Socket^ clientSocket;
   Socket^ serverSocket;
   Encoding^ asciiEncoding;

public:
   const int serverBacklog;
   DateServer()
      : serverBacklog( 10 )
   {
      asciiEncoding = Encoding::ASCII;
      serverSocket = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
   }


   // Return the current date on the client connection.
   bool Create( String^ portString )
   {
      
      // Create another 'SocketPermission' Object* with two ip addresses.
      // First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and
      // for 'All' ports for the ip-address.
      SocketPermission^ socketPermission = gcnew SocketPermission( NetworkAccess::Accept,TransportType::All,"192.168.144.238",SocketPermission::AllPorts );
      
      // Second 'SocketPermission' ip-address is '192.168.144.239' for 'All' transport types and
      // for 'All' ports for the ip-address.
      socketPermission->AddPermission( NetworkAccess::Accept, TransportType::All, "192.168.144.239", SocketPermission::AllPorts );
      Console::WriteLine( "Display result of AcceptList property : " );
      IEnumerator^ enumerator = socketPermission->AcceptList;
      while ( enumerator->MoveNext() )
      {
         Console::WriteLine( "The hostname is       : {0}", dynamic_cast<EndpointPermission^>(enumerator->Current)->Hostname );
         Console::WriteLine( "The port is           : {0}", dynamic_cast<EndpointPermission^>(enumerator->Current)->Port );
         Console::WriteLine( "The Transport type is : {0}", dynamic_cast<EndpointPermission^>(enumerator->Current)->Transport );
      }

      
      // Demand for the calling method for requisite socket permissions.
      socketPermission->Demand();
      serverSocket->Bind( gcnew IPEndPoint( (Dns::Resolve( Dns::GetHostName() )->AddressList)[ 0 ],Int16::Parse( portString ) ) );
      serverSocket->Listen( serverBacklog );
      while ( true )
      {
         try
         {
            clientSocket = serverSocket->Accept();
            array<Byte>^sendByte = asciiEncoding->GetBytes( DateTime::Now.ToString() );
            clientSocket->Send( sendByte, sendByte->Length, SocketFlags::None );
            clientSocket->Close();
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( "\nException raised : {0}", e->Message );
            return false;
         }

      }
   }

};

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length != 1 )
   {
      PrintUsage();
      return 0;
   }

   DateServer^ server = gcnew DateServer;
   try
   {
      server->Create( args[ 0 ] );
   }
   catch ( SecurityException^ securityException ) 
   {
      Console::WriteLine( "SecurityException caught !!!" );
      Console::WriteLine( "Message : {0}", securityException->Message );
   }
   catch ( Exception^ exception ) 
   {
      Console::WriteLine( "Exception caught !!!" );
      Console::WriteLine( "Message {0}", exception->Message );
   }

}
