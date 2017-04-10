#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;

static void ConnectAndCheck( Socket^ client, EndPoint^ anEndPoint )
{
   // <Snippet1>
   client->Connect( anEndPoint );
   if (  !client->Connected )
   {
      Console::WriteLine( "Winsock error: {0}", Convert::ToString(
         System::Runtime::InteropServices::Marshal::GetLastWin32Error() ) );
   }
      
   // This is how you can determine whether a socket is still connected.
   bool blockingState = client->Blocking;
   try
   {
      array<Byte>^tmp = gcnew array<Byte>(1);
      client->Blocking = false;
      client->Send( tmp, 0, static_cast<SocketFlags>(0) );
      Console::WriteLine( L"Connected!" );
   }
   catch ( SocketException^ e ) 
   {
      // 10035 == WSAEWOULDBLOCK
      if ( e->NativeErrorCode.Equals( 10035 ) )
      {
         Console::WriteLine( "Connected from an exception!" );
      }
      else
      {
         Console::WriteLine( "Disconnected: {0}!", e->NativeErrorCode );
      }
   }
   finally
   {
      client->Blocking = blockingState;
   }

   Console::WriteLine( "Connected: {0}", client->Connected );
   // </Snippet1>
}

[STAThread]
int main()
{
   Socket^ s = gcnew Socket( AddressFamily::InterNetwork,
      SocketType::Stream,
      ProtocolType::Tcp );

   String^ host = "localhost";
   int port = 80;

   IPHostEntry^ hostEntry = Dns::Resolve( host );
   IPEndPoint^ EPHost = gcnew IPEndPoint( hostEntry->AddressList[ 0 ],port );

   ConnectAndCheck( s, EPHost );
}
