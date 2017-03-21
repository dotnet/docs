// Displays sending with a connected socket
// using the overload that takes a buffer, offset, message size, and socket flags.
int SendReceiveTest4( Socket^ server )
{
   array<Byte>^ msg = Encoding::UTF8->GetBytes( "This is a test" );
   array<Byte>^ bytes = gcnew array<Byte>(256);
   try
   {
      
      // Blocks until send returns.
      int byteCount = server->Send( msg, 0, msg->Length, SocketFlags::None );
      Console::WriteLine( "Sent {0} bytes.", byteCount.ToString() );
      
      // Get reply from the server.
      byteCount = server->Receive( bytes, 0, server->Available,
         SocketFlags::None );
      if ( byteCount > 0 )
      {
         Console::WriteLine( Encoding::UTF8->GetString( bytes ) );
      }
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine(  "{0} Error code: {1}.", e->Message, e->ErrorCode.ToString() );
      return (e->ErrorCode);
   }
   return 0;
}