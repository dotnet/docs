public:
   void DisplayLocalHostName()
   {
      try
      {
         // Get the local computer host name.
         String^ hostName = Dns::GetHostName();
         Console::WriteLine( "Computer name : {0}", hostName );
      }
      catch ( SocketException^ e ) 
      {
         Console::WriteLine( "SocketException caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }
   }