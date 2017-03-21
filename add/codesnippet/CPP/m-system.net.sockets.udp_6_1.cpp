         //Uses the IP address and port number to establish a socket connection.
         UdpClient^ udpClient = gcnew UdpClient;
         IPAddress^ ipAddress = Dns::Resolve( "www.contoso.com" )->AddressList[ 0 ];
         try
         {
            udpClient->Connect( ipAddress, 11003 );
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( e->ToString() );
         }