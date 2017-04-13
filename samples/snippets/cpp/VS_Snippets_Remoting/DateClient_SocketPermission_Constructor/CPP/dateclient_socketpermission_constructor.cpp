/*
This program demonstrates the 'SocketPermission(PermissionState)',
'SocketPermission(NetworkAccess, TransportType, String*, int) constructors,
'FromXml', 'Intersect', 'AddPermission' methods and 'AllPorts' field
of 'SocketPermission' class.

This program provides a class called 'DateClient' that functions as a client
for a 'DateServer'. A 'DateServer' is a server that provides the current date on
the server in response to a request from a client. The 'DateClient' class
provides a method called 'GetDate' which returns the current date on the server.
The 'GetDate' is the method that shows the use of 'SocketPermission' class. An
instance of 'SocketPermission' is obtained using the 'FromXml' method. Another
instance of 'SocketPermission' is created with the 'SocketPermission(NetworkAccess,
TransportType, String*, int)' constructor. A third 'SocketPermission' Object* is
formed from the intersection of the above two 'SocketPermission' objects with the
use of the 'Intersect' method of 'SocketPermission' class. This 'SocketPermission'
Object* is used by the 'GetDate' method to verify the permissions of the calling
method. If the calling method has the requisite permissions the 'GetDate' method
connects to the 'DateServer' and returns the current date that the 'DateServer'
sends. If any exception occurs the 'GetDate' method returns an empty String*.

Note: This program requires 'DateServer_SocketPermission' program executing.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;
using namespace System::Collections;
using namespace System::Security;
using namespace System::Security::Permissions;

void PrintUsage()
{
   Console::WriteLine( "Usage : DateClient_SocketPermission_Constructor" );
   Console::WriteLine( "\tDateClient_SocketPermission_Constructor <ipaddress> <port>" );
   Console::WriteLine( "\tThe ipaddress argument is the ip address of the Date server." );
   Console::WriteLine( "\tThe port argument is the port of the Date server." );
}

public ref class DateClient
{
private:
   Socket^ serverSocket;
   Encoding^ asciiEncoding;
   IPAddress^ serverAddress;

   int serverPort;

public:
   // The constructor takes the address and port of the remote server.
   DateClient( IPAddress^ ipAddress, int port )
   {
      serverAddress = ipAddress;
      serverPort = port;
      serverSocket = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
      asciiEncoding = Encoding::ASCII;
   }

   String^ GetDate()
   {
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
// <Snippet5>
// <Snippet6>
      SocketPermission^ socketPermission1 = gcnew SocketPermission( PermissionState::Unrestricted );
      
      // Create a 'SocketPermission' Object* for two ip addresses.
      SocketPermission^ socketPermission2 = gcnew SocketPermission( PermissionState::None );
      SecurityElement^ securityElement1 = socketPermission2->ToXml();
      // 'SocketPermission' Object* for 'Connect' permission
      SecurityElement^ securityElement2 = gcnew SecurityElement( "ConnectAccess" );
      // Format to specify ip address are <ip-address>#<port>#<transport-type>
      // First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and
      // for 'All'ports for the ip-address.
      SecurityElement^ securityElement3 = gcnew SecurityElement( "URI","192.168.144.238#-1#3" );
      // Second 'SocketPermission' ip-address is '192.168.144.240' for 'All' transport types and
      // for 'All' ports for the ip-address.
      SecurityElement^ securityElement4 = gcnew SecurityElement( "URI","192.168.144.240#-1#3" );
      securityElement2->AddChild( securityElement3 );
      securityElement2->AddChild( securityElement4 );
      securityElement1->AddChild( securityElement2 );
      
      // Obtain a 'SocketPermission' Object* using 'FromXml' method.
      socketPermission2->FromXml( securityElement1 );

      Console::WriteLine( "\nDisplays the result of FromXml method : \n" );
      Console::WriteLine( socketPermission2 );
      
      // Create another 'SocketPermission' Object* with two ip addresses.
      // First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
      SocketPermission^ socketPermission3 =
         gcnew SocketPermission( NetworkAccess::Connect,
            TransportType::All,
            "192.168.144.238",
            SocketPermission::AllPorts );
      
      // Second 'SocketPermission' ip-address is '192.168.144.239' for 'All' transport types and for 'All' ports for the ip-address.
      socketPermission3->AddPermission( NetworkAccess::Connect,
         TransportType::All,
         "192.168.144.239",
         SocketPermission::AllPorts );

      Console::WriteLine( "Displays the result of AddPermission method : \n" );
      Console::WriteLine( socketPermission3 );
      
      // Find the intersection between two 'SocketPermission' objects.
      socketPermission1 = dynamic_cast<SocketPermission^>(socketPermission2->Intersect( socketPermission3 ));

      Console::WriteLine( "Displays the result of Intersect method :\n " );
      Console::WriteLine( socketPermission1 );
      
      // Demand that the calling method have the requsite socket permission.
      socketPermission1->Demand();
// </Snippet6>
// </Snippet5>
// </Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>
      // Get the current date from the remote date server.
      try
      {
         int bytesReceived;
         array<Byte>^getByte = gcnew array<Byte>(100);
         serverSocket->Connect( gcnew IPEndPoint( serverAddress,serverPort ) );
         bytesReceived = serverSocket->Receive( getByte, getByte->Length, SocketFlags::None );
         return asciiEncoding->GetString( getByte, 0, bytesReceived );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "\nException raised : {0}", e->Message );
         return "";
      }
   }
};

// demonstrates the caller of the 'GetDate' method for the 'DateClient' object.
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length != 2 )
   {
      PrintUsage();
      return 0;
   }

   try
   {
      DateClient^ myDateClient = gcnew DateClient( IPAddress::Parse( args[ 0 ] ),Int32::Parse( args[ 1 ] ) );
      String^ currentDate = myDateClient->GetDate();
      Console::WriteLine( "The current date and time is : " );
      Console::WriteLine( " {0}", currentDate );
   }
   // This exception is thrown by the called method in the context of improper permissions.
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "\nSecurityException raised : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nException raised : {0}", e->Message );
   }
}
