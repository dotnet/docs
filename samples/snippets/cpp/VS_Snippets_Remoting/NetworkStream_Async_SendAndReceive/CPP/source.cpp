

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
ref class MyNetworkStreamClass
{
public:

   //<Snippet4>

   // Example of EndWrite
   static void myWriteCallBack( IAsyncResult^ ar )
   {
      NetworkStream^ myNetworkStream = safe_cast<NetworkStream^>(ar->AsyncState);
      myNetworkStream->EndWrite( ar );
   }
   //</Snippet4>

   //<Snippet5>
   // Example of EndRead, DataAvailable and BeginRead.
   static void myReadCallBack( IAsyncResult^ ar )
   {
      NetworkStream^ myNetworkStream = safe_cast<NetworkStream^>(ar->AsyncState);
      array<Byte>^myReadBuffer = gcnew array<Byte>(1024);
      String^ myCompleteMessage = "";
      int numberOfBytesRead;
      numberOfBytesRead = myNetworkStream->EndRead( ar );
      myCompleteMessage = String::Concat( myCompleteMessage, Encoding::ASCII->GetString( myReadBuffer, 0, numberOfBytesRead ) );
      
      // message received may be larger than buffer size so loop through until you have it all.
      while ( myNetworkStream->DataAvailable )
      {
         AsyncCallback^ pasync = gcnew AsyncCallback( &myReadCallBack );
         myNetworkStream->BeginRead( myReadBuffer, 0, myReadBuffer->Length, pasync, myNetworkStream );
      }

      // Print out the received message to the console.
      Console::WriteLine( "You received the following message : {0}", myCompleteMessage );
   }
   //</Snippet5>

   static void MySample( bool networkStreamOwnsSocket )
   {
      ManualResetEvent^ allDone = gcnew ManualResetEvent( false );

      // Create a socket and connect with a remote host.
      IPHostEntry^ myIpHostEntry = Dns::GetHostEntry( "www.contoso.com" );
      IPEndPoint^ myIpEndPoint = gcnew IPEndPoint( myIpHostEntry->AddressList[ 0 ],1001 );
      Socket^ mySocket = gcnew Socket( myIpEndPoint->Address->AddressFamily,SocketType::Stream,ProtocolType::Tcp );
      try
      {
         //<Snippet1>
         // Example for creating a NetworkStreams
         mySocket->Connect( myIpEndPoint );

         // Create the NetworkStream for communicating with the remote host.
         NetworkStream^ myNetworkStream;
         if ( networkStreamOwnsSocket )
         {
            myNetworkStream = gcnew NetworkStream( mySocket,FileAccess::ReadWrite,true );
         }
         else
         {
            myNetworkStream = gcnew NetworkStream( mySocket,FileAccess::ReadWrite );
         }
         //</Snippet1>

         //<Snippet2>
         // Example of CanWrite, and BeginWrite.
         // Check to see if this NetworkStream is writable.
         if ( myNetworkStream->CanWrite )
         {
            array<Byte>^myWriteBuffer = Encoding::ASCII->GetBytes( "Are you receiving this message?" );
            myNetworkStream->BeginWrite( myWriteBuffer, 0, myWriteBuffer->Length, gcnew AsyncCallback( &MyNetworkStreamClass::myWriteCallBack ), myNetworkStream );
            allDone->WaitOne();
         }
         else
         {
            Console::WriteLine( "Sorry.  You cannot write to this NetworkStream." );
         }
         //</Snippet2>
         
         //<Snippet3>
         // Example of CanRead, and BeginRead.
         // Check to see if this NetworkStream is readable.
         if ( myNetworkStream->CanRead )
         {
            array<Byte>^myReadBuffer = gcnew array<Byte>(1024);
            myNetworkStream->BeginRead( myReadBuffer, 0, myReadBuffer->Length, gcnew AsyncCallback( &MyNetworkStreamClass::myReadCallBack ), myNetworkStream );
            allDone->WaitOne();
         }
         else
         {
            Console::WriteLine( "Sorry.  You cannot read from this NetworkStream." );
         }
         //</Snippet3>

         // Close the NetworkStream
         myNetworkStream->Close();
      }
      catch ( Exception^ exception ) 
      {
         Console::WriteLine( "Exception Thrown: {0}", exception );
      }
   }
};

int main( int argc, char *argv[] )
{
   if ( "yes" == gcnew String(argv[1]) )
   {
      MyNetworkStreamClass::MySample( true );
   }
   else
   if ( "no" == gcnew String(argv[1]) )
   {
      MyNetworkStreamClass::MySample( false );
   }
   else
   {
      Console::WriteLine( "Must use 'yes' to allow the NetworkStream to own the Socket or {0}", "\n 'no' to prohibit NetworkStream from owning the Socket." );
   }
}

//Output:
//-1, 234.00
//(-)1, 234.00
