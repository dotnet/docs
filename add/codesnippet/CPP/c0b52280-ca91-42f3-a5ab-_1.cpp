   static ManualResetEvent^ allDone = gcnew ManualResetEvent( false );

   // handles the completion of the prior asynchronous 
   // connect call. the socket is passed via the objectState 
   // paramater of BeginConnect().
   static void ConnectCallback1( IAsyncResult^ ar )
   {
      allDone->Set();
      Socket^ s = dynamic_cast<Socket^>(ar->AsyncState);
      s->EndConnect( ar );
   }

