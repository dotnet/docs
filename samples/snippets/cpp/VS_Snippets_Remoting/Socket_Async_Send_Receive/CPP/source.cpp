#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Threading;

//<Snippet11>
public ref class StateObject
{
public:
   literal int BUFFER_SIZE = 1024;
   Socket^ workSocket;
   array<Byte>^ buffer;
   StringBuilder^ sb;
   StateObject() : workSocket( nullptr )
   {
      buffer = gcnew array<Byte>(BUFFER_SIZE);
      sb = gcnew StringBuilder;
   }
};
//</Snippet11>

ref class Async_Send_Receive
{
public:
   static ManualResetEvent^ allDone = gcnew ManualResetEvent( false );
   static void Connect()
   {
//<Snippet1>
      IPHostEntry^ lipa = Dns::Resolve( "host.contoso.com" );
      IPEndPoint^ lep = gcnew IPEndPoint( lipa->AddressList[ 0 ], 11000 );

      Socket^ s = gcnew Socket( lep->Address->AddressFamily,
         SocketType::Stream,
         ProtocolType::Tcp );
      try
      {
         while ( true )
         {
            allDone->Reset();

            Console::WriteLine( "Establishing Connection" );
            s->BeginConnect( lep, gcnew AsyncCallback(
               &Async_Send_Receive::Connect_Callback ), s );

            allDone->WaitOne();
         }
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e );
      }
//</Snippet1>
   }

   static void Listen()
   {
//<Snippet2>
      IPHostEntry^ lipa = Dns::Resolve( "host.contoso.com" );
      IPEndPoint^ lep = gcnew IPEndPoint( lipa->AddressList[ 0 ], 11000 );

      Socket^ s = gcnew Socket( lep->Address->AddressFamily,
         SocketType::Stream,
         ProtocolType::Tcp );
      try
      {
         s->Bind( lep );
         s->Listen( 1000 );

         while ( true )
         {
            allDone->Reset();

            Console::WriteLine( "Waiting for a connection..." );
            s->BeginAccept( gcnew AsyncCallback( &Async_Send_Receive::Connect_Callback ), s );

            allDone->WaitOne();
         }
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e );
      }
//</Snippet2>
   }

   static void SendTo()
   {
//<Snippet3>
      IPHostEntry^ lipa = Dns::Resolve( "host.contoso.com" );
      IPEndPoint^ lep = gcnew IPEndPoint( lipa->AddressList[ 0 ], 11000 );

      Socket^ s = gcnew Socket( lep->Address->AddressFamily,
         SocketType::Stream,
         ProtocolType::Tcp );
      try
      {
         while ( true )
         {
            allDone->Reset();

            array<Byte>^ buff = Encoding::ASCII->GetBytes( "This is a test" );

            Console::WriteLine( "Sending Message Now.." );
            s->BeginSendTo( buff, 0, buff->Length, SocketFlags::None, lep,
               gcnew AsyncCallback( &Async_Send_Receive::Connect_Callback ), s );

            allDone->WaitOne();
         }
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e );
      }
//</Snippet3>
   }

   static void ReceiveFrom()
   {
//<Snippet4>
      IPHostEntry^ lipa = Dns::Resolve( "host.contoso.com" );
      IPEndPoint^ lep = gcnew IPEndPoint( lipa->AddressList[ 0 ], 11000 );

      Socket^ s = gcnew Socket( lep->Address->AddressFamily,
         SocketType::Stream,
         ProtocolType::Tcp );

      IPEndPoint^ sender = gcnew IPEndPoint( IPAddress::Any, 0 );
      EndPoint^ tempRemoteEP = (EndPoint^)( sender );
      s->Connect( sender );

      try
      {
         while ( true )
         {
            allDone->Reset();
            StateObject^ so2 = gcnew StateObject;
            so2->workSocket = s;
            Console::WriteLine( "Attempting to Receive data from host.contoso.com" );

            s->BeginReceiveFrom( so2->buffer, 0, StateObject::BUFFER_SIZE, SocketFlags::None, tempRemoteEP,
               gcnew AsyncCallback( &Async_Send_Receive::ReceiveFrom_Callback ), so2 );
            allDone->WaitOne();
         }
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e );
      }
//</Snippet4>
   }

   static void ReceiveFrom1(){
//<Snippet41>
	IPHostEntry^ lipa = Dns::Resolve( "host.contoso.com" );
	IPEndPoint^ lep = gcnew IPEndPoint( lipa->AddressList[ 0 ], 11000);

       Socket^ s = gcnew Socket( lep->Address->AddressFamily,
       	  SocketType::Dgram,
          ProtocolType::Udp);
       
       IPEndPoint^ sender = gcnew IPEndPoint( IPAddress::Any, 0 );
       EndPoint^ tempRemoteEP = (EndPoint^)( sender );
       s->Connect( sender );
       
       try{
          while(true){
             allDone->Reset();
             StateObject^ so2 = gcnew StateObject();
                 so2->workSocket = s;
                 Console::WriteLine( "Attempting to Receive data from host.contoso.com" );
             
                 s->BeginReceiveFrom( so2->buffer, 0, StateObject::BUFFER_SIZE, SocketFlags::None, tempRemoteEP,
	            gcnew AsyncCallback( &Async_Send_Receive::ReceiveFrom_Callback), so2);	
                 allDone->WaitOne();
            }
       }
       catch ( Exception^ e )
       {
            Console::WriteLine( e );
       }
//</Snippet41>
   }

   static void Connect_Callback( IAsyncResult^ ar )
   {
//<Snippet5>
      allDone->Set();
      Socket^ s = safe_cast<Socket^>(ar->AsyncState);
      s->EndConnect( ar );
      StateObject^ so2 = gcnew StateObject;
      so2->workSocket = s;
      array<Byte>^ buff = Encoding::ASCII->GetBytes( "This is a test" );
      s->BeginSend( buff, 0, buff->Length, SocketFlags::None,
         gcnew AsyncCallback( &Async_Send_Receive::Send_Callback ), so2 );
//</Snippet5>
   }

   static void Send_Callback( IAsyncResult^ ar )
   {
//<Snippet6>
      StateObject^ so = safe_cast<StateObject^>(ar->AsyncState);
      Socket^ s = so->workSocket;

      int send = s->EndSend( ar );

      Console::WriteLine( "The size of the message sent was : {0}", send );

      s->Close();
//</Snippet6>    
   }

//<Snippet7>
   static void Listen_Callback( IAsyncResult^ ar )
   {
      allDone->Set();
      Socket^ s = safe_cast<Socket^>(ar->AsyncState);
      Socket^ s2 = s->EndAccept( ar );
      StateObject^ so2 = gcnew StateObject;
      so2->workSocket = s2;
      s2->BeginReceive( so2->buffer, 0, StateObject::BUFFER_SIZE, SocketFlags::None,
         gcnew AsyncCallback( &Async_Send_Receive::Read_Callback ), so2 );
   }
//</Snippet7>

//<Snippet8>
   static void Read_Callback( IAsyncResult^ ar )
   {
      StateObject^ so = safe_cast<StateObject^>(ar->AsyncState);
      Socket^ s = so->workSocket;

      int read = s->EndReceive( ar );

      if ( read > 0 )
      {
         so->sb->Append( Encoding::ASCII->GetString( so->buffer, 0, read ) );
         s->BeginReceive( so->buffer, 0, StateObject::BUFFER_SIZE, SocketFlags::None,
            gcnew AsyncCallback( &Async_Send_Receive::Read_Callback ), so );
      }
      else
      {
         if ( so->sb->Length > 1 )
         {
            //All of the data has been read, so displays it to the console
            String^ strContent = so->sb->ToString();
            Console::WriteLine( String::Format( "Read {0} byte from socket" +
               " data = {1} ", strContent->Length, strContent ) );
         }
         s->Close();
      }
   }
   //</Snippet8>

   static void SendTo_Callback( IAsyncResult^ ar )
   {
//<Snippet9>
      StateObject^ so = safe_cast<StateObject^>(ar->AsyncState);
      Socket^ s = so->workSocket;

      int send = s->EndSendTo( ar );

      Console::WriteLine( "The size of the message sent was : {0}", send );

      s->Close();
//</Snippet9>
   }

   static void ReceiveFrom_Callback( IAsyncResult^ ar )
   {
//<Snippet10>
      StateObject^ so = safe_cast<StateObject^>(ar->AsyncState);
      Socket^ s = so->workSocket;
      
      // Creates a temporary EndPoint to pass to EndReceiveFrom.
      IPEndPoint^ sender = gcnew IPEndPoint( IPAddress::Any,0 );
      EndPoint^ tempRemoteEP = safe_cast<EndPoint^>(sender);

      int read = s->EndReceiveFrom( ar, tempRemoteEP );

      if ( read > 0 )
      {
         so->sb->Append( Encoding::ASCII->GetString( so->buffer, 0, read ) );
         s->BeginReceiveFrom( so->buffer, 0, StateObject::BUFFER_SIZE, SocketFlags::None,
            tempRemoteEP, gcnew AsyncCallback( &Async_Send_Receive::ReceiveFrom_Callback ), so );
      }
      else
      {
         if ( so->sb->Length > 1 )
         {
            //All the data has been read, so displays it to the console.
            String^ strContent = so->sb->ToString();
            Console::WriteLine( "Read {0} byte from socket" +
               " data = {1}", strContent->Length, strContent );
         }
         s->Close();
      }
//</Snippet10>
   }
};

void main(){}
