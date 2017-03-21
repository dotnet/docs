// Displays sending with a connected socket
// using the overload that takes a buffer, message size, and socket flags.
int SendReceiveTest3( Socket^ server )
{
   array<Byte>^ msg = Encoding::UTF8->GetBytes( "This is a test" );
   array<Byte>^ bytes = gcnew array<Byte>(256);
   try
   {
      // Blocks until send returns.
      int i = server->Send( msg, msg->Length, SocketFlags::None );
      Console::WriteLine( "Sent {0} bytes.", i.ToString() );
      
      // Get reply from the server.
      int byteCount = server->Receive( bytes, server->Available,
         SocketFlags::None );
      if ( byteCount > 0 )
      {
         Console::WriteLine( Encoding::UTF8->GetString( bytes ) );
      }
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine( "{0} Error code: {1}.", e->Message, e->ErrorCode.ToString() );
      return (e->ErrorCode);
   }
   return 0;
}