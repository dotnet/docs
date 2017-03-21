protected:
   void AcceptMethod( Socket^ listeningSocket )
   {
      Socket^ mySocket = listeningSocket->Accept();
   }