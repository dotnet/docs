/*
This program demonstrates the 'ToXml' and 'IsUnrestricted' method and 'ConnectList' property of
'SocketPermission' class.

This program provides a class called 'DateClient' that functions as a client
for a 'DateServer'. A 'DateServer' is a server that provides the current date on
the server in response to a request from a client. The 'DateClient' class
provides a method called 'GetDate' which returns the current date on the server.
The 'GetDate' is the method that shows the use of 'SocketPermission' class. An
instance of 'SocketPermission' is obtained using the 'FromXml' method. Another
instance of 'SocketPermission' is created with the 'SocketPermission(NetworkAccess,
TransportType, String*, int)' constructor. A third 'SocketPermission' Object* is
formed from the union of the above two 'SocketPermission' objects with the use of the
'Union' method of 'SocketPermission' class . This 'SocketPermission' Object* is used by
the 'GetDate' method to verify the permissions of the calling method. If the calling
method has the requisite permissions the 'GetDate' method connects to the 'DateServer'
and returns the current date that the 'DateServer' sends. If any exception occurs
the 'GetDate' method returns an empty String*.

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
   Console::WriteLine( "Usage : DateClient_SocketPermission_ToXml" );
   Console::WriteLine( "\tDateClient_SocketPermission_ToXml <ipaddress> <port>" );
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

   // The constructor takes the address and port of the remote server.
public:
   DateClient( IPAddress^ serverIpAddress, int port )
   {
      serverAddress = serverIpAddress;
      serverPort = port;
      serverSocket = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
      asciiEncoding = Encoding::ASCII;
   }

private:

   // Print a security element and all its children, in a depth-first manner.
   void PrintSecurityElement( SecurityElement^ securityElementObj, int depth )
   {
      Console::WriteLine( "Depth    : {0}", depth );
      Console::WriteLine( "Tag      : {0}", securityElementObj->Tag );
      Console::WriteLine( "Text     : {0}", securityElementObj->Text );
      if ( securityElementObj->Children != nullptr )
            Console::WriteLine( "Children : {0}", securityElementObj->Children->Count );

      if ( securityElementObj->Attributes != nullptr )
      {
         IEnumerator^ attributeEnumerator = securityElementObj->Attributes->GetEnumerator();
         while ( attributeEnumerator->MoveNext() )
                  Console::WriteLine( "Attribute - \" {0}\" , Value - \" {1}\"", (dynamic_cast<IDictionaryEnumerator^>(attributeEnumerator))->Key, (dynamic_cast<IDictionaryEnumerator^>(attributeEnumerator))->Value );
      }

      Console::WriteLine( "" );
      if ( securityElementObj->Children != nullptr )
      {
         depth += 1;
         for ( int i = 0; i < securityElementObj->Children->Count; i++ )
            PrintSecurityElement( dynamic_cast<SecurityElement^>(securityElementObj->Children[ i ]), depth );
      }
   }


public:
   String^ GetDate()
   {
      // <Snippet1>
      // <Snippet2>
      // <Snippet3>
      SocketPermission^ socketPermission1 = gcnew SocketPermission( PermissionState::Unrestricted );
      
      // Create a 'SocketPermission' Object* for two ip addresses.
      SocketPermission^ socketPermission2 = gcnew SocketPermission( PermissionState::None );
      SecurityElement^ securityElement4 = socketPermission2->ToXml();
      
      // 'SocketPermission' Object* for 'Connect' permission
      SecurityElement^ securityElement1 = gcnew SecurityElement( "ConnectAccess" );
      
      // Format to specify ip address are <ip-address>#<port>#<transport-type>
      // First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
      SecurityElement^ securityElement2 = gcnew SecurityElement( "URI","192.168.144.238#-1#3" );
      
      // Second 'SocketPermission' ip-address is '192.168.144.240' for 'All' transport types and for 'All' ports for the ip-address.
      SecurityElement^ securityElement3 = gcnew SecurityElement( "URI","192.168.144.240#-1#3" );
      securityElement1->AddChild( securityElement2 );
      securityElement1->AddChild( securityElement3 );
      securityElement4->AddChild( securityElement1 );
      
      // Obtain a 'SocketPermission' Object* using 'FromXml' method.
      socketPermission2->FromXml( securityElement4 );
      
      // Create another 'SocketPermission' Object* with two ip addresses.
      // First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
      SocketPermission^ socketPermission3 = gcnew SocketPermission( NetworkAccess::Connect,TransportType::All,"192.168.144.238",SocketPermission::AllPorts );
      
      // Second 'SocketPermission' ip-address is '192.168.144.239' for 'All' transport types and for 'All' ports for the ip-address.
      socketPermission3->AddPermission( NetworkAccess::Connect, TransportType::All, "192.168.144.239", SocketPermission::AllPorts );
      Console::WriteLine( "\nChecks the Socket permissions using IsUnrestricted method : " );
      if ( socketPermission1->IsUnrestricted() )
            Console::WriteLine( "Socket permission is unrestricted" );
      else
            Console::WriteLine( "Socket permission is restricted" );

      Console::WriteLine();
      Console::WriteLine( "Display result of ConnectList property : \n" );
      IEnumerator^ enumerator = socketPermission3->ConnectList;
      while ( enumerator->MoveNext() )
      {
         Console::WriteLine( "The hostname is       : {0}", dynamic_cast<EndpointPermission^>(enumerator->Current)->Hostname );
         Console::WriteLine( "The port is           : {0}", dynamic_cast<EndpointPermission^>(enumerator->Current)->Port );
         Console::WriteLine( "The Transport type is : {0}", dynamic_cast<EndpointPermission^>(enumerator->Current)->Transport );
      }

      Console::WriteLine( "" );
      Console::WriteLine( "Display Security Elements :\n " );
      PrintSecurityElement( socketPermission2->ToXml(), 0 );
      
      // Get a 'SocketPermission' Object* which is a union of two other 'SocketPermission' objects.
      socketPermission1 = dynamic_cast<SocketPermission^>(socketPermission3->Union( socketPermission2 ));
      
      // Demand that the calling method have the socket permission.
      socketPermission1->Demand();
      // </Snippet3>
      // </Snippet2>
      // </Snippet1>

      // Get the current date from the remote date server.
      try
      {
         int bytesReceived;
         array<Byte>^getByte = gcnew array<Byte>(100);
         serverSocket->Connect( gcnew IPEndPoint( serverAddress,serverPort ) );
         bytesReceived = serverSocket->Receive( getByte, getByte->Length, static_cast<SocketFlags>(0) );
         return asciiEncoding->GetString( getByte, 0, bytesReceived );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "\nException raised : {0}", e->Message );
         return "";
      }
   }
};

// This class is used to demonstrate the caller of the 'GetDate' method for the 'DateClient' Object*.
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
