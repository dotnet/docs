#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;

void CreateAndListen( int port, int backlog )
{
   // <Snippet1>
   // create the socket
   Socket^ listenSocket = gcnew Socket( AddressFamily::InterNetwork,
      SocketType::Stream,
      ProtocolType::Tcp );
   
   // bind the listening socket to the port
   IPAddress^ hostIP = ( Dns::Resolve( IPAddress::Any->ToString() ) )->AddressList[ 0 ];
   IPEndPoint^ ep = gcnew IPEndPoint( hostIP,port );
   listenSocket->Bind( ep );
   
   // start listening
   listenSocket->Listen( backlog );
   // </Snippet1>
}

[STAThread]
int main()
{
   CreateAndListen( 10042, 10 );
   Console::WriteLine( "enter to exit" );
   Console::Read();
}
