#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Threading;

public ref class Sync_Send_Receive
{
public:
   static void SetSocketOptions()
   {
      IPHostEntry^ lipa = Dns::Resolve(  "host.contoso.com" );
      IPEndPoint^ lep = gcnew IPEndPoint( lipa->AddressList[ 0 ],11000 );
      Socket^ s = gcnew Socket( lep->Address->AddressFamily, SocketType::Stream,ProtocolType::Tcp );
      
//<Snippet1>
      // Specifies that send operations will time-out 
      // if confirmation is not received within 1000 milliseconds.
      s->SetSocketOption( SocketOptionLevel::Socket, SocketOptionName::SendTimeout, 1000 );
      
      // Specifies that the Socket will linger for 10 seconds after Close is called.
      LingerOption^ lingerOption = gcnew LingerOption( true,10 );

      s->SetSocketOption( SocketOptionLevel::Socket, SocketOptionName::Linger, lingerOption );
//</Snippet1>                                  

      s->Connect( lep );

      array<Byte>^ msg = Encoding::ASCII->GetBytes( "This is a test" );
      
//<Snippet2>
      Console::Write(  "This application will timeout if Send does not return within " );
      Console::WriteLine( Encoding::ASCII->GetString( s->GetSocketOption( SocketOptionLevel::Socket, SocketOptionName::SendTimeout, 4 ) ) );
      
      // Blocks until send returns.
      int i = s->Send( msg );
      
      // Blocks until read returns.
      array<Byte>^ bytes = gcnew array<Byte>(1024);

      s->Receive( bytes );
      
      //Displays to the screen.
      Console::WriteLine( Encoding::ASCII->GetString( bytes ) );
      s->Shutdown( SocketShutdown::Both );
      Console::Write(  "If data remains to be sent, this application will stay open for " );
      Console::WriteLine( safe_cast<LingerOption^>(s->GetSocketOption( SocketOptionLevel::Socket, SocketOptionName::Linger ))->LingerTime.ToString() );
      s->Close();
//</Snippet2>
   }

   static void CheckProperties()
   {
      IPHostEntry^ lipa = Dns::Resolve(  "host.contoso.com" );
      IPEndPoint^ lep = gcnew IPEndPoint( lipa->AddressList[ 0 ],11000 );

//<Snippet3>
      Socket^ s = gcnew Socket( lep->Address->AddressFamily,SocketType::Stream,ProtocolType::Tcp );
      
      //Uses the AddressFamily, SocketType, and ProtocolType properties.
      Console::Write(  "I just set the following properties of socket: \n" );
      Console::Write(  "Address Family = {0}", s->AddressFamily.ToString() );
      Console::Write(  "\nSocketType = {0}", s->SocketType.ToString() );
      Console::WriteLine(  "\nProtocolType = {0}", s->ProtocolType.ToString() );
//</Snippet3>

//<Snippet4>
      s->Connect( lep );
      
      // Uses the RemoteEndPoint property.
      Console::WriteLine(  "I am connected to {0} on port number {1}",
         IPAddress::Parse( ( ( (IPEndPoint^)(s->RemoteEndPoint) )->Address)->ToString() ),
         ( (IPEndPoint^)(s->RemoteEndPoint) )->Port.ToString() );
      
      // Uses the LocalEndPoint property.
      Console::Write(  "My local IpAddress is : {0}\nI am connected on port number {1}",
         IPAddress::Parse( ( ( (IPEndPoint^)(s->LocalEndPoint) )->Address)->ToString() ),
         ( (IPEndPoint^)(s->LocalEndPoint) )->Port.ToString() );
//</Snippet4>

//<Snippet5>
      //Uses low level method IOControl to set this socket to blocking mode.
      int code = 0x8004667E;
      array<Byte>^ inBuf = gcnew array<Byte>(4);

      inBuf[ 0 ] = 0;

      array<Byte>^ outBuf = gcnew array<Byte>(4);

      s->IOControl( code, inBuf, outBuf );
      
      //Checks to see that this worked.
      if ( s->Blocking )
      {
         Console::WriteLine(  "Socket was set to Blocking mode successfully" );
      }
//</Snippet5>
   }
};

int main(){}
