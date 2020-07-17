// System.Net.IPEndPoint.MaxPort; System.Net.IPEndPoint.MinPort;
// System.Net.IPEndPoint.AddressFamily; System.Net.IPEndPoint.IPEndPoint(long,int)
// System.Net.IPEndPoint.Address; System.Net.IPEndPoint.Port;

/*This program demonstrates the properties 'MaxPort', 'MinPort','Address','Port'
and 'AddressFamily' and a constructor 'IPEndPoint(long,int)' of class 'IPEndPoint'.

A procedure DoSocketGet is created which internally uses a socket to transmit http "Get" requests to a Web resource.
The program accepts a resource Url, Resolves it to obtain 'IPAddress',Constructs 'IPEndPoint' instance using this 
'IPAddress' and port 80.Invokes DoSocketGet procedure to obtain a response and displays the response to a console.

It then accepts another Url, Resolves it to obtain 'IPAddress'. Assigns this IPAddress and port to the 'IPEndPoint'
and again invokes DoSocketGet to obtain a response and display.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Text;
using namespace System::Net::Sockets;
using namespace System::Runtime::InteropServices;

String^ DoSocketGet( IPEndPoint^ hostIPEndPoint, String^ getString ); // forward reference

int main()
{
   try
   {
      Console::Write( "\nPlease enter an INTRANET Url as shown: [e.g. www.microsoft.com]:" );
      String^ hostString1 = Console::ReadLine();
      
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
      IPAddress^ hostIPAddress1 = (Dns::Resolve( hostString1 ))->AddressList[ 0 ];
      Console::WriteLine( hostIPAddress1 );
      IPEndPoint^ hostIPEndPoint = gcnew IPEndPoint( hostIPAddress1,80 );
      Console::WriteLine( "\nIPEndPoint information:{0}", hostIPEndPoint );
      Console::WriteLine( "\n\tMaximum allowed Port Address :{0}", IPEndPoint::MaxPort );
      Console::WriteLine( "\n\tMinimum allowed Port Address :{0}", (int^)IPEndPoint::MinPort );
      Console::WriteLine( "\n\tAddress Family :{0}", hostIPEndPoint->AddressFamily );
// </Snippet4>
      Console::Write( "\nPress Enter to continue" );
      Console::ReadLine();
      String^ getString = String::Format( "GET / HTTP/1.1\r\nHost: {0}\r\nConnection: Close\r\n\r\n", hostString1 );
      String^ pageContent = DoSocketGet( hostIPEndPoint, getString );
      if ( pageContent != nullptr )
      {
         Console::WriteLine( "Default HTML page on {0} is:\r\n{1}", hostString1, pageContent );
      }
// </Snippet3>
// </Snippet2>
// </Snippet1>

      Console::Write( "\n\n\nPlease enter another INTRANET Url as shown[e.g. www.microsoft.com]: " );
      String^ hostString2 = Console::ReadLine();
      
// <Snippet5>
// <Snippet6>  
      IPAddress^ hostIPAddress2 = (Dns::Resolve( hostString2 ))->AddressList[ 0 ];
      hostIPEndPoint->Address = hostIPAddress2;
      hostIPEndPoint->Port = 80;

      getString = String::Format( "GET / HTTP/1.1\r\nHost: {0}\r\nConnection: Close\r\n\r\n", hostString2 );
      pageContent = DoSocketGet( hostIPEndPoint, getString );
      if ( pageContent != nullptr )
      {
         Console::WriteLine( "Default HTML page on {0} is:\r\n{1}", hostString2, pageContent );
      }
      
// </Snippet6>
// </Snippet5>  
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine( "SocketException caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "Message : {0}", e->Message );
   }

}

String^ DoSocketGet( IPEndPoint^ hostIPEndPoint, String^ getString )
{
   try
   {
      // Set up variables and String to write to the server.
      Encoding^ ASCII = Encoding::ASCII;

      array<Byte>^ byteGet = ASCII->GetBytes( getString );
      array<Byte>^ recvBytes = gcnew array<Byte>(256);
      String^ strRetPage = nullptr;
      // Create the Socket for sending data over TCP.
      Socket^ mySocket = gcnew Socket( AddressFamily::InterNetwork,
         SocketType::Stream,ProtocolType::Tcp );
      // Connect to host using IPEndPoint.
      mySocket->Connect( hostIPEndPoint );
      // Send the GET text to the host.
      mySocket->Send( byteGet, byteGet->Length, (SocketFlags)( 0 ) );
      // Receive the page, loop until all bytes are received.
      Int32 byteCount = mySocket->Receive( recvBytes, recvBytes->Length, (SocketFlags)( 0 ) );
      strRetPage = String::Concat( strRetPage, ASCII->GetString( recvBytes, 0, byteCount ) );
      while ( byteCount > 0 )
      {
         byteCount = mySocket->Receive( recvBytes, recvBytes->Length, (SocketFlags)( 0 ) );
         strRetPage = String::Concat( strRetPage, ASCII->GetString( recvBytes, 0, byteCount ) );
      }
      return strRetPage;
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
      Console::WriteLine( "WinSock Error : {0}", Convert::ToString( Marshal::GetLastWin32Error() ) );
      return nullptr;
   }
}
