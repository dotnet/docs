

// File name:ipendpoint.cs.
// <Internal>
// This program contains snippets applicable to the following:
// System.Net.IPEndPoint (Snippet1);  
// System.Net.IPEndPoint.IPEndPoint(IPAddress, int) (Snippet2);
// System.Net.IPEndPoint.Address (Snippet3);
// System.Net.IPEndPoint.AddressFamily (Snippet3);
// System.Net.IPEndPoint.Port (Snippet3);
// System.Net.IPEndPoint.Serialize (Snippet4);
// System.Net.IPEndPoint.Create (Snippet5);
// </Internal>
//<Snippet1>
// This example uses the IPEndPoint class and its members to display the home page 
// of the server selected by the user.
#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text::RegularExpressions;

// The getPage function gets the server's home page content by 
// recreating the server's endpoint from the original serialized endpoint.
// Then it creates a new socket and connects it to the endpoint.
String^ getPage( String^ server, SocketAddress^ socketAddress )
{
   //Set up variables and string to write to the server.
   Encoding^ ASCII = Encoding::ASCII;
   String^ Get = String::Format( "GET / HTTP/1.1\r\nHost: {0}\r\nConnection: Close\r\n\r\n", server );
   array<Byte>^ByteGet = ASCII->GetBytes( Get );
   array<Byte>^RecvBytes = gcnew array<Byte>(256);
   String^ strRetPage = nullptr;
   Socket^ socket = nullptr;

   //<Snippet5>
   // Recreate the connection endpoint from the serialized information.
   IPEndPoint^ endpoint = gcnew IPEndPoint( (__int64)0,0 );
   IPEndPoint^ clonedIPEndPoint = dynamic_cast<IPEndPoint^>(endpoint->Create( socketAddress ));
   Console::WriteLine( "clonedIPEndPoint: {0}", clonedIPEndPoint );
   //</Snippet5>

   Console::WriteLine( "Press any key to continue." );
   Console::ReadLine();
   try
   {
      // Create a socket object to establish a connection with the server.
      socket = gcnew Socket( endpoint->AddressFamily,SocketType::Stream,ProtocolType::Tcp );

      // Connect to the cloned end point.
      socket->Connect( clonedIPEndPoint );
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }

   if ( socket == nullptr )
      return ("Connection to cloned endpoint failed");

   // Send request to the server.
   socket->Send( ByteGet, ByteGet->Length, static_cast<SocketFlags>(0) );

   // Receive the server  home page content.
   Int32 bytes = socket->Receive( RecvBytes, RecvBytes->Length, static_cast<SocketFlags>(0) );

   // Read the first 256 bytes.
   strRetPage = String::Format( "Default HTML page on {0}:\r\n", server );
   strRetPage = String::Concat( strRetPage, ASCII->GetString( RecvBytes, 0, bytes ) );
   while ( bytes > 0 )
   {
      bytes = socket->Receive( RecvBytes, RecvBytes->Length, static_cast<SocketFlags>(0) );
      strRetPage = String::Concat( strRetPage, ASCII->GetString( RecvBytes, 0, bytes ) );
   }

   socket->Close();
   return strRetPage;
}

//<Snippet4>
// The serializeEndpoint function serializes the endpoint and returns the 
// SocketAddress containing the serialized endpoint data.
SocketAddress^ serializeEndpoint( IPEndPoint^ endpoint )
{
   // Serialize IPEndPoint details to a SocketAddress instance.
   SocketAddress^ socketAddress = endpoint->Serialize();

   // Display the serialized endpoint information.
   Console::WriteLine( "Endpoint.Serialize() : {0}", socketAddress );
   Console::WriteLine( "Socket->Family : {0}", socketAddress->Family );
   Console::WriteLine( "Socket->Size : {0}", socketAddress->Size );
   Console::WriteLine( "Press any key to continue." );
   Console::ReadLine();
   return socketAddress;
}
//</Snippet4>

//<Snippet3>
void displayEndpointInfo( IPEndPoint^ endpoint )
{
   Console::WriteLine( "Endpoint->Address : {0}", endpoint->Address );
   Console::WriteLine( "Endpoint->AddressFamily : {0}", endpoint->AddressFamily );
   Console::WriteLine( "Endpoint->Port : {0}", endpoint->Port );
   Console::WriteLine( "Endpoint.ToString() : {0}", endpoint );
   Console::WriteLine( "Press any key to continue." );
   Console::ReadLine();
}
//</Snippet3>

// The serializeEndpoint function determines the server endpoint and then 
// serializes it to obtain the related SocketAddress object.
// Note that in the for loop a temporary socket is created to ensure that 
// the current IP address format matches the AddressFamily type.
// In fact, in the case of servers supporting both IPv4 and IPv6, an exception 
// may arise if an IP address format does not match the address family type.
SocketAddress^ getSocketAddress( String^ server, int port )
{
   Socket^ tempSocket = nullptr;
   IPHostEntry^ host = nullptr;
   SocketAddress^ serializedSocketAddress = nullptr;
   try
   {
      // Get the object containing Internet host information.
      host = Dns::Resolve( server );

      // <Snippet2>
      // Obtain the IP address from the list of IP addresses associated with the server.
      System::Collections::IEnumerator^ myEnum = host->AddressList->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         IPAddress^ address = safe_cast<IPAddress^>(myEnum->Current);
         IPEndPoint^ endpoint = gcnew IPEndPoint( address,port );
         tempSocket = gcnew Socket( endpoint->AddressFamily,SocketType::Stream,ProtocolType::Tcp );
         tempSocket->Connect( endpoint );
         if ( tempSocket->Connected )
         {
            // Display the endpoint information.
            displayEndpointInfo( endpoint );

            // Serialize the endpoint to obtain a SocketAddress object.
            serializedSocketAddress = serializeEndpoint( endpoint );
            break;
         }
         else
                  continue;
      }
      // </Snippet2>

      // Close the temporary socket.
      tempSocket->Close();
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }

   return serializedSocketAddress;
}


// The requestServerHomePage function obtains the server's home page and returns
// its content.
String^ requestServerHomePage( String^ server, int port )
{
   String^ strRetPage = nullptr;

   // Get a socket address using the specified server and port.
   SocketAddress^ socketAddress = getSocketAddress( server, port );
   if ( socketAddress == nullptr )
      strRetPage = "Connection failed"; // Obtain the server's home page content.
   else
      strRetPage = getPage( server, socketAddress );

   return strRetPage;
}


// Show to the user how to use this program when wrong input parameters are entered.
void showUsage()
{
   Console::WriteLine( "Enter the server name as follows:" );
   Console::WriteLine( "\tcs_ipendpoint servername" );
}


// This is the program entry point. It allows the user to enter 
// a server name that is used to locate its current homepage.
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   String^ host = nullptr;
   int port = 80;

   // Define a regular expression to parse user's input.
   // This is a security check. It allows only
   // alphanumeric input string between 2 to 40 character long.
   Regex^ rex = gcnew Regex( "^[a-zA-Z]\\w{1,39}$" );
   if ( args->Length < 2 )
      showUsage();
   else
   {
      String^ message = args[ 1 ];
      if ( (rex->Match(message))->Success )
      {
         host = args[ 1 ];
         
         // Get the specified server home_page and display its content.
         String^ result = requestServerHomePage( host, port );
         Console::WriteLine( result );
      }
      else
            Console::WriteLine( "Input string format not allowed." );
   }
}
//</Snippet1>
