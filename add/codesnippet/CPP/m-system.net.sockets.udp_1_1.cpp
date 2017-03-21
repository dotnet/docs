         //Uses a remote endpoint to establish a socket connection.
         UdpClient^ udpClient = gcnew UdpClient;
         IPAddress^ ipAddress = Dns::Resolve( "www.contoso.com" )->AddressList[ 0 ];
         IPEndPoint^ ipEndPoint = gcnew IPEndPoint( ipAddress,11004 );
         try
         {
            udpClient->Connect( ipEndPoint );
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( e->ToString() );
         }