   static void GetSetExclusiveAddressUse( TcpClient^ t )
   {
      // Don't allow another process to bind to this port.
      t->ExclusiveAddressUse = true;
      Console::WriteLine( "ExclusiveAddressUse value is {0}", t->ExclusiveAddressUse.ToString() );
      ;
   }