   static ManualResetEvent^ connectDone = gcnew ManualResetEvent( false );
   static void ConnectCallback( IAsyncResult^ ar )
   {
      connectDone->Set();
      TcpClient^ t = safe_cast<TcpClient^>(ar->AsyncState);
      t->EndConnect( ar );
   }