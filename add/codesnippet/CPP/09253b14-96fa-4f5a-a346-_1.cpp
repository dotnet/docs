   static void SendTo4()
   {
      IPHostEntry^ hostEntry = Dns::Resolve( Dns::GetHostName() );
      IPEndPoint^ endPoint = gcnew IPEndPoint( hostEntry->AddressList[ 0 ],11000 );

      Socket^ s = gcnew Socket( endPoint->Address->AddressFamily,
         SocketType::Dgram,
         ProtocolType::Udp );

      array<Byte>^ msg = Encoding::ASCII->GetBytes( "This is a test" );
      Console::WriteLine( "Sending data." );
      // This call blocks. 
      s->SendTo( msg, 0, msg->Length, SocketFlags::None, endPoint );
      s->Close();
   }