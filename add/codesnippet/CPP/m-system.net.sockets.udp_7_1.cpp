         //Creates an instance of the UdpClient class with a remote host name and a port number.
         try
         {
            UdpClient^ udpClient = gcnew UdpClient( "www.contoso.com",11000 );
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( e->ToString() );
         }