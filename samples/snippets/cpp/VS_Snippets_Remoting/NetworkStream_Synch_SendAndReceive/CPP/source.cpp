// The following sample is intended to demonstrate how to use a 
//NetworkStream for synchronous communcation with a remote host
//This class uses several NetworkStream members that would be useful
// in a synchronous communciation senario

#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Threading;

void MySample( bool networkStreamOwnsSocket )
{
   //<Snippet1>
   // This should be the classwide example.
   // Create a socket and connect with a remote host.
   IPHostEntry^ myIpHostEntry = Dns::GetHostEntry( "www.contoso.com" );
   IPEndPoint^ myIpEndPoint = gcnew IPEndPoint( myIpHostEntry->AddressList[ 0 ],1001 );

   Socket^ mySocket = gcnew Socket( myIpEndPoint->Address->AddressFamily,
      SocketType::Stream,
      ProtocolType::Tcp );
   try
   {
      mySocket->Connect( myIpEndPoint );
      
      //<Snippet2>
      // Examples for constructors that do not specify file permission.
      // Create the NetworkStream for communicating with the remote host.
      NetworkStream^ myNetworkStream;

      if ( networkStreamOwnsSocket )
      {
         myNetworkStream = gcnew NetworkStream( mySocket,true );
      }
      else
      {
         myNetworkStream = gcnew NetworkStream( mySocket );
      }
      //</Snippet2>

      //<Snippet3>  
      // Examples for CanWrite, and CanWrite  
      // Check to see if this NetworkStream is writable.
      if ( myNetworkStream->CanWrite )
      {
         array<Byte>^ myWriteBuffer = Encoding::ASCII->GetBytes(
            "Are you receiving this message?" );
         myNetworkStream->Write( myWriteBuffer, 0, myWriteBuffer->Length );
      }
      else
      {
         Console::WriteLine( "Sorry.  You cannot write to this NetworkStream." );
      }
      //</Snippet3>

      //<Snippet4>   
      // Examples for CanRead, Read, and DataAvailable.
      // Check to see if this NetworkStream is readable.
      if ( myNetworkStream->CanRead )
      {
         array<Byte>^ myReadBuffer = gcnew array<Byte>(1024);
         String^ myCompleteMessage = "";
         int numberOfBytesRead = 0;
         
         // Incoming message may be larger than the buffer size.
         do
         {
            numberOfBytesRead = myNetworkStream->Read( myReadBuffer, 0,
               myReadBuffer->Length );
            myCompleteMessage = String::Concat( myCompleteMessage,
               Encoding::ASCII->GetString( myReadBuffer, 0, numberOfBytesRead ) );
         }
         while ( myNetworkStream->DataAvailable );
         
         // Print out the received message to the console.
         Console::WriteLine( "You received the following message : {0}",
            myCompleteMessage );
      }
      else
      {
         Console::WriteLine( "Sorry.  You cannot read from this NetworkStream." );
      }
      //</Snippet4>

      //<Snippet5>  
      // Example for closing the NetworkStream.
      // Close the NetworkStream
      myNetworkStream->Close();
      //</Snippet5>

   }
   catch ( Exception^ exception ) 
   {
      Console::WriteLine( "Exception Thrown: {0}", exception->ToString() );
   }
}
//</Snippet1>

int main( int argc, char *argv[] )
{
   if ( "yes" == gcnew String(argv[1]) )
   {
      MySample( true );
   }
   else
   if ( "no" == gcnew String(argv[1]) )
   {
      MySample( false );
   }
   else
   {
      Console::WriteLine( "Must use 'yes' to allow the NetworkStream to own the Socket or {0}", "\n 'no' to prohibit NetworkStream from owning the Socket." );
   }
}
