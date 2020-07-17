

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::Net;
using namespace System::Net::Sockets;
int main()
{
   
   // Create a client that will connect to a 
   // server listening on the contoso1 computer
   // at port 11000.
   TcpClient^ tcpClient = gcnew TcpClient;
   tcpClient->Connect( "contosoServer", 11000 );
   
   // Get the stream used to read the message sent by the server.
   NetworkStream^ networkStream = tcpClient->GetStream();
   
   // Set a 10 millisecond timeout for reading.
   networkStream->ReadTimeout = 10;
   
   // Read the server message into a byte buffer.
   array<Byte>^bytes = gcnew array<Byte>(1024);
   networkStream->Read( bytes, 0, 1024 );
   
   //Convert the server's message into a string and display it.
   String^ data = Encoding::UTF8->GetString( bytes );
   Console::WriteLine( "Server sent message: {0}", data );
   networkStream->Close();
   tcpClient->Close();
}

// </Snippet1>
