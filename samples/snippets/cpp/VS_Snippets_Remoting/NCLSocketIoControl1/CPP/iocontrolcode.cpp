#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;
using namespace System::Threading;

// <snippet1>
void DisplayPendingByteCount( Socket^ s )
{
   array<Byte>^ outValue = BitConverter::GetBytes( 0 );
   
   // Check how many bytes have been received.
   s->IOControl( IOControlCode::DataToRead, nullptr, outValue );

   UInt32 bytesAvailable = BitConverter::ToUInt32( outValue, 0 );
   Console::Write( "server has {0} bytes pending,",
      bytesAvailable );
   Console::WriteLine( "Available property says {1}.",
      s->Available );
   return;
}
// </snippet1>

int main()
{
   IPHostEntry^ localHost = Dns::Resolve( Dns::GetHostName() );
   IPEndPoint^ endPoint = gcnew IPEndPoint(
      localHost->AddressList[ 0 ],11000 );
   
   // For the purposes of this example, we will send and
   // receive on the same machine.
   //
   Socket^ s = gcnew Socket( AddressFamily::InterNetwork,
     SocketType::Stream,
     ProtocolType::Tcp );

   s->Bind( endPoint );

   s->Listen( 1 );
   Console::WriteLine(
      "Waiting to receive messages from client.." );
   Socket^ client = s->Accept();
   
   // Creates a byte buffer to receive the message.
   array<Byte>^ buffer = gcnew array<Byte>(256);
   String^ message;

   for ( ; ;  )
   {
      Thread::Sleep( 10000 );
      DisplayPendingByteCount( client );
      client->Receive( buffer );
      message = Encoding::UTF8->GetString( buffer );
      
      // Displays the information received to the screen
      Console::WriteLine(
         " Server received the following message: {0}",
         message );
      
      // Look for "<EOF>" to end session.
      if ( message->IndexOf( "<EOF>" ) != -1 )
      {
         break;
      }
   }
   client->Close();
   s->Close();
}
