      allDone->Set();
      Socket^ s = safe_cast<Socket^>(ar->AsyncState);
      s->EndConnect( ar );
      StateObject^ so2 = gcnew StateObject;
      so2->workSocket = s;
      array<Byte>^ buff = Encoding::ASCII->GetBytes( "This is a test" );
      s->BeginSend( buff, 0, buff->Length, SocketFlags::None,
         gcnew AsyncCallback( &Async_Send_Receive::Send_Callback ), so2 );