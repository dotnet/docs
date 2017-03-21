         //Creates an instance of the UdpClient class using a local endpoint.
         IPAddress^ ipAddress = Dns::Resolve( Dns::GetHostName() )->AddressList[ 0 ];
         IPEndPoint^ ipLocalEndPoint = gcnew IPEndPoint( ipAddress,11000 );

         try
         {
            UdpClient^ udpClient = gcnew UdpClient( ipLocalEndPoint );
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( e->ToString() );
         }