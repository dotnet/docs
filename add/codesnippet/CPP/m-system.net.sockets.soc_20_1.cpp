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