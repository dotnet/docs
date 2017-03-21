   static void GetAvailable( TcpClient^ t )
   {
      // Find out how many bytes are ready to be read.
      Console::WriteLine( "Available value is {0}", t->Available.ToString() );
      ;
   }