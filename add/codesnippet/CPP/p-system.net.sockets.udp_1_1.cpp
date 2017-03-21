   static void GetAvailable( UdpClient^ u )
   {
      // Get the number of bytes available for reading.
      Console::WriteLine(  "Available value is {0}", u->Available );
   }