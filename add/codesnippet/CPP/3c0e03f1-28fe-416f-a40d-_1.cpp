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