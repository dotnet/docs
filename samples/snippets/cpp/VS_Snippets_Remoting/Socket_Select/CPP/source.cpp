

#using <System.dll>
#define NULL 0

using namespace System;
using namespace System::Text;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Threading;
using namespace System::Collections;
public ref class Sync_Send_Receive
{
public:

   //Displays sending and receiving with a connected socket -- buffer only
   static void SendReceive1()
   {
      
      //<Snippet1>
      IPHostEntry^ lipa = Dns::Resolve( Dns::GetHostName() );
      
      //Gets three separate local endpoints.
      IPEndPoint^ lep1 = gcnew IPEndPoint( lipa->AddressList[ 0 ],11000 );
      IPEndPoint^ lep2 = gcnew IPEndPoint( lipa->AddressList[ 0 ],11001 );
      IPEndPoint^ lep3 = gcnew IPEndPoint( lipa->AddressList[ 0 ],11002 );
      
      //creates an array of endpoints.
      array<IPEndPoint^>^ipendpoints = gcnew array<IPEndPoint^>(3);
      ipendpoints[ 0 ] = lep1;
      ipendpoints[ 1 ] = lep2;
      ipendpoints[ 2 ] = lep3;
      
      //Creates three separate sockets.
      Socket^ s1 = gcnew Socket( lep1->Address->AddressFamily,SocketType::Stream,ProtocolType::Tcp );
      Socket^ s2 = gcnew Socket( lep2->Address->AddressFamily,SocketType::Stream,ProtocolType::Tcp );
      Socket^ s3 = gcnew Socket( lep3->Address->AddressFamily,SocketType::Stream,ProtocolType::Tcp );
      array<Socket^>^socketList = gcnew array<Socket^>(3);
      socketList[ 0 ] = s1;
      socketList[ 1 ] = s2;
      socketList[ 2 ] = s3;
      
      //Binds and Listens on all sockets in the array of sockets.
      for ( int i = 0; i < 3; i++ )
      {
         socketList[ i ]->Bind( ipendpoints[ i ] );
         socketList[ i ]->Listen( 1000 );

      }
      
      //Calls Select to determine which sockets are ready for reading.
      Socket::Select( safe_cast<IList^>(socketList), nullptr, nullptr, 1000 );
      
      //Reads on the sockets returned by Select.
      array<Byte>^buffer = gcnew array<Byte>(1024);
      String^ outString;
      for ( Int32 j = 0; j < (socketList->Length - 1); j++ )
      {
         socketList[ j ]->Receive( buffer );
         outString =  "Socket ";
         outString->Concat( j.ToString(),  " has the message", Encoding::ASCII->GetString( buffer ) );
         Console::WriteLine( outString );

      }
   }

};

int main()
{
   return 0;
}

// </Snippet1>
