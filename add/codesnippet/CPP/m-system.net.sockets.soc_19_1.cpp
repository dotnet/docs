      StateObject^ so = safe_cast<StateObject^>(ar->AsyncState);
      Socket^ s = so->workSocket;

      int send = s->EndSend( ar );

      Console::WriteLine( "The size of the message sent was : {0}", send );

      s->Close();